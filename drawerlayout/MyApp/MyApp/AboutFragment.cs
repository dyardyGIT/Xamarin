using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using MyApp.PCL.Models;

namespace MyApp
{
    public class AboutFragment : Fragment
    {
        private ViewGroup _container;
        private MyProfile _profile;
        private Context _context;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            base.OnActivityCreated(savedInstanceState);
            

            //string[] recs = new string[2];
            //recs[0] = "my first row";
            //recs[1] = "my second row";
            //var listView = this.Activity.FindViewById<ListView>(Resource.Id.aboutListView);            
            //var adapter = new ArrayAdapter<string>(_context, Resource.Layout.TextViewItem, recs);
            //listView.Adapter = adapter;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            _container = container;
            

            //return inflater.Inflate(Resource.Layout.About, container, false);
            //return base.OnCreateView(inflater, container, savedInstanceState); //original

            //string[] recs = new string[2];
            //recs[0] = "my first row";
            //recs[1] = "my second row";


            View view = inflater.Inflate(Resource.Layout.About, container, false);
            //_context = container.Context;

            _profile = new MyProfile();

            //var adapter = new ArrayAdapter<MyDetail>(this.Activity, Resource.Layout.TextViewItem, _profile.AboutInformation);
            var listView = view.FindViewById<ListView>(Resource.Id.aboutListView);
            //listView.Adapter = adapter;

            //var aboutAdapter = new AboutScreenAdapter(this.Activity, recs);

            var aboutAdapter = new AboutScreenAdapter(this.Activity, _profile.AboutInformation);
            listView.Adapter = aboutAdapter;
                        

            return view;
        }
    }

    //public class AboutScreenAdapter : BaseAdapter<string>
    public class AboutScreenAdapter : BaseAdapter<MyDetail>
    {
        List<MyDetail> _items;
        //string[] items;
        Activity _context;
        //public AboutScreenAdapter(Activity context, string[] items) : base()
        public AboutScreenAdapter(Activity context, List<MyDetail> items) : base()
        {
            this._context = context;
            this._items = items;
        }
        public override long GetItemId(int position)
        {
            return position;
        }
        public override MyDetail this[int position]
        {
            get { return _items[position]; }            
        }

        //public override string this[int position]
        //{
        //    get { return items[position]; }
        //}
        public override int Count
        {
            //get { return items.Length; }
            get { return _items.Count; }
        }
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView; // re-use an existing view, if one is available
            if (view == null) // otherwise create a new one
                view = _context.LayoutInflater.Inflate(Resource.Layout.TextViewItem3, null);

            //view.FindViewById<TextView>(Android.Resource.Id.text).Text = items[position];

            //view.FindViewById<TextView>(Resource.Id.textItem1).Text = _items[position].Image;
            //view.FindViewById<ImageView>(Resource.Id.image).SetImageResource(Resource.Layout.pe.)

            string stringId = _items[position].Image;
            int id = _context.Resources.GetIdentifier(stringId, "drawable", _context.PackageName);

            var imageView = view.FindViewById<ImageView>(Resource.Id.imageView);
            imageView.SetImageResource(id);
            //imageView.SetImageResource(Resource.Drawable.queenslogo_colour);

            view.FindViewById<TextView>(Resource.Id.textItemTitle).Text = _items[position].Title;

            view.FindViewById<TextView>(Resource.Id.textItem2).Text = _items[position].Detail;
            return view;
        }
    }
}

//http://developer.xamarin.com/guides/android/user_interface/working_with_listviews_and_adapters/part_2_-_populating_a_listview_with_data/