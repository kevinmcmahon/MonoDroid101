using Android.Content;
using Android.Views;
using Android.Widget;
using Java.Lang;

namespace HelloGridView
{
    public class ImageAdapter : BaseAdapter
    {
        private readonly Context _context;

        private readonly int[] mThumbIds = {
                                               Resource.drawable.sample_2, Resource.drawable.sample_3,
                                               Resource.drawable.sample_4, Resource.drawable.sample_5,
                                               Resource.drawable.sample_6, Resource.drawable.sample_7,
                                               Resource.drawable.sample_0, Resource.drawable.sample_1,
                                               Resource.drawable.sample_2, Resource.drawable.sample_3,
                                               Resource.drawable.sample_4, Resource.drawable.sample_5,
                                               Resource.drawable.sample_6, Resource.drawable.sample_7,
                                               Resource.drawable.sample_0, Resource.drawable.sample_1,
                                               Resource.drawable.sample_2, Resource.drawable.sample_3,
                                               Resource.drawable.sample_4, Resource.drawable.sample_5,
                                               Resource.drawable.sample_6, Resource.drawable.sample_7
                                           };

        public ImageAdapter(Context c)
        {
            _context = c;
        }

        public override int Count
        {
            get { return mThumbIds.Length; }
        }

        public override Object GetItem(int position)
        {
            return null;
        }

        public override long GetItemId(int position)
        {
            return 0;
        }

        // create a new ImageView for each item referenced by the Adapter
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            ImageView imageView;
            if (convertView == null)
            {
                // if it's not recycled, initialize some attributes
                imageView = new ImageView(_context);
                imageView.LayoutParameters = new AbsListView.LayoutParams(85, 85);
                imageView.SetScaleType(ImageView.ScaleType.CenterCrop);
                imageView.SetPadding(8, 8, 8, 8);
            }
            else
            {
                imageView = (ImageView) convertView;
            }

            imageView.SetImageResource(mThumbIds[position]);
            return imageView;
        }
    }
}