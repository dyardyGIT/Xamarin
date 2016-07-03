using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using SupportToolbar = Android.Support.V7.Widget.Toolbar;
using Android.Support.V7.App;
using Android.Support.V4.Widget;
using System.Collections.Generic;
using AppDave.Fragments;
using SupportFragment = Android.Support.V4.App.Fragment;


namespace AppDave.Fragments
{
    public class Fragment1 : Android.Support.V4.App.Fragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);
            //return base.OnCreateView(inflater, container, savedInstanceState);

            View view = inflater.Inflate(Resource.Layout.Fragment1, container, false);

            //can findbyid stuff here
            Button btn = view.FindViewById<Button>(Resource.Id.button1) as Button;
            btn.Click += Btn_Click;

         


            return view;
        }
        private void Btn_Click(object sender, EventArgs e)
        {

            var activity = (MainActivity)this.Activity;
            activity.TestMethod();


        }

    }


}