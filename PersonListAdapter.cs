using System;
using System.Collections.Generic;
using Android.App;
using Android.Views;
using Android.Widget;

namespace MySpectrumTest
{
    public class PersonListAdapter : BaseAdapter<PersonModel>
    {
        Activity context;
        public List<PersonModel> listPersons;

        public PersonListAdapter(Activity context, List<PersonModel> lpersons) : base()
        {
            this.context = context;
            this.listPersons = lpersons;
        }

        public override PersonModel this[int position]
        {
            get
            {
                return this.listPersons[position];
            }
        }

        public override int Count
        {
            get
            {
                return this.listPersons.Count;
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var person = this.listPersons[position];
            var view = convertView;
            if (convertView == null || (convertView is LinearLayout))
            {
                view = context.LayoutInflater.Inflate(Resource.Layout.ListOfPersons, parent, false);
            }
            var UserName = view.FindViewById(Android.Resource.Id.Text1) as TextView;
            var Emailid = view.FindViewById(Android.Resource.Id.Text2) as TextView;

            UserName.SetText(person.UserName, TextView.BufferType.Normal);
            Emailid.SetText(person.EmailID, TextView.BufferType.Normal);

            return view;
        }
    }
}
