using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Accounts;
using Android.Content.PM;

namespace MonoContactManager
{
	[Activity (Label = "My Activity", MainLauncher = true)]
	public class ContactManager : Activity
	{
		int count = 1;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);


		}
	}
	
	class AccountData {
        private String mName;
        private String mType;
        private char[] mTypeLabel;
        private Android.Graphics.Drawables.Drawable mIcon;

        /**
         * @param name The name of the account. This is usually the user's email address or
         *        username.
         * @param description The description for this account. This will be dictated by the
         *        type of account returned, and can be obtained from the system AccountManager.
         */
        public AccountData(String name, AuthenticatorDescription description) {
            mName = name;
            if (description != null) {
                mType = description.Type;

                // The type string is stored in a resource, so we need to convert it into something
                // human readable.
                string packageName = description.PackageName;
                PackageManager pm = PackageManager.

                if (description.LabelId != 0) {
                    mTypeLabel = pm.GetText(packageName, description.LabelId, null);
                    if (mTypeLabel == null) {
                        throw new IllegalArgumentException("LabelID provided, but label not found");
                    }
                } else {
                    mTypeLabel = "";
                }

                if (description.iconId != 0) {
                    mIcon = pm.GetDrawable(packageName, description.iconId, null);
                    if (mIcon == null) {
                        throw new IllegalArgumentException("IconID provided, but drawable not " +
                                "found");
                    }
                } else {
                    mIcon = Android.Resource.Drawable.SymDefAppIcon;
                }
            }
        }

        public string Name {
            get { return mName; }
        }

        public string Type {
            get { return mType; }
        }

        public char[] TypeLabel {
            get { return mTypeLabel; }
        }

        public Android.Graphics.Drawables.Drawable Icon
		{
            get { return mIcon; }
        }

        public override string ToString() {
            return mName;
        }
    }
	
	class AccountAdapter : ArrayAdapter<AccountData> 
	{
        public AccountAdapter(Context context, List<AccountData> accountData) 
			: base(context, Android.Resource.Layout.SimpleSpinnerItem, accountData)
		{
			this.SetDropDownViewResource(R.layout.account_entry);
        }

        public override View GetDropDownView (int position, View convertView, ViewGroup parent)
		{
            // Inflate a view template
            if (convertView == null) {
                LayoutInflater layoutInflater = getLayoutInflater();
                convertView = layoutInflater.inflate(R.layout.account_entry, parent, false);
            }
            TextView firstAccountLine = (TextView) convertView.findViewById(R.id.firstAccountLine);
            TextView secondAccountLine = (TextView) convertView.findViewById(R.id.secondAccountLine);
            ImageView accountIcon = (ImageView) convertView.findViewById(R.id.accountIcon);

            // Populate template
            AccountData data = getItem(position);
            firstAccountLine.setText(data.getName());
            secondAccountLine.setText(data.getTypeLabel());
            Drawable icon = data.getIcon();
            if (icon == null) {
                icon = getResources().getDrawable(android.R.drawable.ic_menu_search);
            }
            accountIcon.setImageDrawable(icon);
            return convertView;
        }
    }
}