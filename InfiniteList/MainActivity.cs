using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using Android.Util;

namespace InfiniteListExample
{
    [Activity(Label = "InfiniteListExample", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : ListActivity
    {
        InfiniteListOnScrollListener scrollListener;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            var items = new List<Person>();
            for (int i = 0; i <= 25; i++)
            {
                Person p = new Person()
                {
                    Name = String.Format("Person #{0}", i)
                };
                items.Add(p);
            }

            ListAdapter = new InfiniteListAdapter(this, items.ToArray());
            scrollListener = new InfiniteListOnScrollListener((InfiniteListAdapter)ListAdapter);
            ListView.SetOnScrollListener(scrollListener);

            ListView.TextFilterEnabled = true;
            ListView.ItemClick += listView_ItemClick;
        }

        protected override void OnDestroy()
        {
            ListView.ItemClick -= listView_ItemClick;
            base.OnDestroy();
        }

        void listView_ItemClick(object sender, ItemEventArgs e)
        {
            //This is for demo purposes, you can obviously show a toast for ListView data a different way...
            //If you want to change the data for the person and have it reflect in the ListView you will
            //need to Inflate the row, Get the TextView(s) and update them manually, the only other way
            //is to refresh the entire view, if you have hundreds of rows this will not be ideal...
            Person person = ListView.GetItemAtPosition(e.Position).Cast<Person>();
            Toast.MakeText(this, person.Name, ToastLength.Long);
        }
    }
}

