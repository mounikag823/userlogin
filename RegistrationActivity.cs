
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace MySpectrumTest
{
    [Activity(Label = "RegistrationActivity", Theme = "@style/AppTheme", MainLauncher = true)]
    public class RegistrationActivity : Activity
    {
        public EditText UserName, Password, ConfirmPassword, Email;
        public Button Submit;
        public TextView UserNameError, PasswordError, ConfirmPasswordError, EmailError;
        ISharedPreferences pref = Application.Context.GetSharedPreferences("UserInfo", FileCreationMode.Private);

        private static Regex IsUserNameAllowedRegEx = new Regex("[A-Za-z][A-Za-z0-9._]{5,14}");
        private static Regex IsPassWordAlloedRegEx = new Regex("^[a-zA-Z0-9]+$");
        private static Regex IsEmailAllowedRegEx = new Regex(@" ^ ([\w\.\-] +)@([\w\-] +)((\.(\w){2, 3})+)$");

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.RegistrationForm);

            UserName = FindViewById<EditText>(Resource.Id.txtUserName);
            UserNameError = FindViewById<TextView>(Resource.Id.txtUserNameError);
            Password = FindViewById<EditText>(Resource.Id.txtPassword);
            PasswordError = FindViewById<TextView>(Resource.Id.txtPasswordError);
            ConfirmPassword = FindViewById<EditText>(Resource.Id.txtConfirmPassword);
            ConfirmPasswordError = FindViewById<TextView>(Resource.Id.txtConfirmPasswordError);
            Email = FindViewById<EditText>(Resource.Id.txtEmailId);
            EmailError = FindViewById<TextView>(Resource.Id.txtEmailError);
            Submit = FindViewById<Button>(Resource.Id.btnSubmit);

            UserName.TextChanged += UserName_TextChanged;
            UserName.FocusChange += UserName_FocusChange;

            Password.TextChanged += Password_TextChanged;
            Password.FocusChange += Password_FocusChange;

            ConfirmPassword.TextChanged += ConfirmPassword_TextChanged;

            Email.TextChanged += Email_TextChanged;
            Email.FocusChange += Email_FocusChange;

            Submit.Click += Submit_Click;
        }

        private void Email_FocusChange(object sender, View.FocusChangeEventArgs e)
        {
            if (string.IsNullOrEmpty(Email.Text))
            {
                EmailError.Visibility = Android.Views.ViewStates.Visible;
                EmailError.Text = "Email Cannot be Empty";
            }

        }

        private void Email_TextChanged(object sender, Android.Text.TextChangedEventArgs e)
        {
            if (!IsEmailAllowedRegEx.IsMatch(Email.Text))
            {
                EmailError.Visibility = Android.Views.ViewStates.Visible;
                Email.Text = "Please enter the valid Email ID";
            }
            else if (Password.Length() != 0)
            {
                EmailError.Visibility = Android.Views.ViewStates.Gone;
            }
        }

        private void ConfirmPassword_TextChanged(object sender, Android.Text.TextChangedEventArgs e)
        {
            if(UserName.Text.Count() != Password.Text.Count())
            {
                ConfirmPasswordError.Visibility = Android.Views.ViewStates.Visible;
                ConfirmPasswordError.Text = "Confirm password is not match with Password";
            }
            else
            {
                ConfirmPasswordError.Visibility = Android.Views.ViewStates.Gone;
            }
        }

        #region Password


        private void Password_FocusChange(object sender, View.FocusChangeEventArgs e)
        {
            if (string.IsNullOrEmpty(Password.Text))
            {
                PasswordError.Visibility = Android.Views.ViewStates.Visible;
                PasswordError.Text = "Password Cannot be Empty";
            }
        }

        private void Password_TextChanged(object sender, Android.Text.TextChangedEventArgs e)
        {
            if(!IsPassWordAlloedRegEx.IsMatch(Password.Text))
            {
                PasswordError.Visibility = Android.Views.ViewStates.Visible;
                PasswordError.Text = "Password must be between 6 and 20 characters and contain one uppercase letter, one lowercase letter, one digit and one special character.";
            }
            else if(Password.Length() != 0)
            {
                PasswordError.Visibility = Android.Views.ViewStates.Gone;
            }
            
        }
        #endregion

        #region UserName Validation
        private void UserName_TextChanged(object sender, Android.Text.TextChangedEventArgs e)
        {   
            if (!IsUserNameAllowedRegEx.IsMatch(UserName.Text))
            {
                UserNameError.Visibility = Android.Views.ViewStates.Visible;
                UserNameError.Text = "Please Enter the minimum  6 to 15 Characters";
            }
            else if (UserName.Length() != 0)
            {
                UserNameError.Visibility = Android.Views.ViewStates.Gone;
            }
        }

        private void UserName_FocusChange(object sender, View.FocusChangeEventArgs e)
        {
            if(string.IsNullOrEmpty(UserName.Text))
            {
                UserNameError.Visibility = Android.Views.ViewStates.Visible;
                UserNameError.Text = "User Name Cannot be Empty";
            }
        }
        #endregion

        

        private void Submit_Click(object sender, EventArgs e)
        {
            string name = pref.GetString("Name", UserName.Text);
            string email = pref.GetString("Email", Email.Text);

           

            StartActivity(typeof(ListOfPersonsActivity));
        }


    }
}
