
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace MySpectrumTest
{
    [Activity(Label = "ListOfPersonsActivity", Theme = "@style/AppTheme", MainLauncher = false)]
    public class ListOfPersonsActivity : Activity
    {
        public ListView PersonsList;
        public List<PersonModel> personModels;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.ListOfPersons);

            try
            {
                PersonsList = FindViewById<ListView>(Resource.Id.PersonList);

             personModels = new List<PersonModel>()
            {
                new PersonModel{ID=1, UserName="Mounica", EmailID="Mounica@gmail.com"},
                new PersonModel{ID=2, UserName="Reddy", EmailID="Reddy@gmail.com"},
                new PersonModel{ID=3, UserName="Vizag", EmailID="Vizag@gmail.com"},
                new PersonModel{ID=4, UserName="Friend", EmailID="friend@gmail.com"}
            };

                
                PersonsList.Adapter = new PersonListAdapter(this, personModels); 
            }
            catch(Exception ex)
            {
                string Msg = ex.Message;
            }

           
        }
    }
}
