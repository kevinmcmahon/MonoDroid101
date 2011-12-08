using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android;
using Android.Widget;
using Android.Views;
using Android.App;
using Android.Content;
using System.Threading;


namespace InfiniteListExample
{
    /// <summary>
    /// Description: Demonstrates how to create a listview that will constantly append data from a network or some other streaming source.
    /// Author: Eric Malamisura (www.elucidsoft.com)
    /// </summary>
    public class InfiniteListAdapter : BaseAdapter<Person>
    {
        //For demonstration, I would not store this in the Adapter itself your data source should be located outside the adapter in
        //case it is recreated for some reason...
        List<Person> items = new List<Person>();
        Activity activity;

        //Volatile keyword ensures that multiple threads will always receive the proper value for Adding (non-serialized), we use this
        //to protect from an instance where an OnScroll Event would trigger a network fetch and then another network fetch could be 
        //triggered (for instance if you scroll back up and then down before initial load is completed), if the second network fetch
        //comes in before the first one (which can happen, you are not gauranteed serialized order on the net) your list will not
        //be in order and it may actually cause additional issues depending on how you are using your list...You will also encounter
        //many un-needed fetches and append calls, if you check the OnScrollListenter this is actually being checked...
        public volatile bool Adding = false;
        ProgressDialog dialog;

        public InfiniteListAdapter(Activity activity, Person[] items)
            : base()
        {
            this.activity = activity; //very important that you null this out before destroying your Activity or it will prevent GC
            this.items.AddRange(items);
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View v = convertView;
            if (v == null)
            {
                LayoutInflater vi = (LayoutInflater)activity.GetSystemService(Context.LayoutInflaterService);
                v = vi.Inflate(Resource.Layout.list_item, null);
            }

            Person i = items[position];
            if (i != null)
            {
                //We are using the ViewHolder pattern that Google recommended at their I/O conference to increase perf of the ListView by
                //nearly 20-30 fps in some cases, especially in large lists.
                ViewHolder holder = v.Tag as ViewHolder;
                if (holder == null)
                {
                    holder = new ViewHolder();
                    holder.MainTextView = v.FindViewById<TextView>(Resource.Id.listViewMainText);
                    v.Tag = holder;
                }

                holder.MainTextView.Text = i.Name;
            }

            return v;
        }

        public override Person this[int position]
        {
            get { return items[position]; }
        }

        public override int Count
        {
            get { return items.Count; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        internal void AppendMoreData()
        {
            if (Adding == false)
            {
                activity.RunOnUiThread(() =>
                {
                    //This is for demonstration purposes, I would suggest using a less intrusive notification...
                    dialog = ProgressDialog.Show(activity, "Please wait...", "Loading More");
                });

                Adding = true;
                //If you are adding to a list you must do it in Async otherwise you will block UI Thread and Android may
                //terminate your application randomly if it chooses...
                new Thread(new ThreadStart(() =>
                    {
                        //This is for demo purposes...
                        var appendItems = new List<Person>();
                        for (int i = Count; i <= Count + 25; i++)
                        {
                            Person p = new Person()
                            {
                                Name = String.Format("Person #{0}", i)
                            };
                            appendItems.Add(p);
                        }

                        this.items.AddRange(appendItems.ToArray());

                        activity.RunOnUiThread(() =>
                        {
                            //You can actually get away without calling this in several circumstances, however Google recommends
                            //that you call it in all cases.
                            NotifyDataSetChanged();
                        });

                        Thread.Sleep(5000); //simulate a network download of more data that may take a couple seconds...
                        dialog.Dismiss();
                        Adding = false;
                    })).Start();
            }
        }

        //It is necessary to inherit from Java.Lang.Object in Mono so we can put ViewHolder in the Tag of the row, notice we
        //can not use the same semantics as in Java because nested static classes in .NET do not behave the same way.
        private class ViewHolder : Java.Lang.Object
        {
            public TextView MainTextView { get; set; }
        }
    }
}