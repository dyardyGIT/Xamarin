using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Support.V4.Widget;
using Android.Support.V7.App;

namespace MyApp
{    
    [Activity(Label = "MyApp", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private DrawerLayout _drawerLayout;
        private string[] _menuItems;
        private ListView _drawerList;
        private Fragment[] _fragments = new Fragment[]{ new WelcomeFragment(), new OptionsFragment(), new AboutFragment() };

        private ActionBarDrawerToggle  _drawerToggle;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            _menuItems = new string[] { "Welcome", "Options", "About" };


            _drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawerLayout);
            _drawerList = FindViewById<ListView>(Resource.Id.drawerListView);

            _drawerList.Adapter = new ArrayAdapter<string>(this, Resource.Layout.ListViewMenuRow, Resource.Id.menuRowTextView, _menuItems);
            //_drawerList.ItemClick += _drawerList_ItemClick;
            _drawerList.ItemClick += (object sender, AdapterView.ItemClickEventArgs e) => OnMenuItemClick(e.Position);

            _drawerList.SetItemChecked(0, true); //highlight the first item at startup
            OnMenuItemClick(0);


            //create an instance of actionbardrawertoggle            
            _drawerToggle = new ActionBarDrawerToggle(this, _drawerLayout, Resource.String.DrawerOpenDescription, Resource.String.DrawerCloseDescription);
            //set the actiondrawertoggle as the drawerlistener on the drawlayout so it recieves drawer state-change callbacks
            _drawerLayout.SetDrawerListener(_drawerToggle);
            //Must up-enable the home button, the ActionBarDrawerToggle will change the icon to the "hamburger"
            ActionBar.SetDisplayHomeAsUpEnabled(true);



            //ActionBar sample putting tabs in the page
            this.ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;
            
            AddTab("Tab 1", Resource.Drawable.ic_tab_white, new SampleTabFragment());
            AddTab("Tab 2", Resource.Drawable.ic_tab_white, new SampleTabFragment2());

            if (bundle != null)
                this.ActionBar.SelectTab(this.ActionBar.GetTabAt(bundle.GetInt("tab")));

            


        }

    
     

        private void OnMenuItemClick(int position)
        {
            base.FragmentManager.BeginTransaction().Replace(Resource.Id.frameLayout, _fragments[position]).Commit();
            this.Title = _menuItems[position];

            _drawerLayout.CloseDrawer(_drawerList); //closes the drawer
        }

        protected override void OnPostCreate(Bundle savedInstanceState)
        {
            //
            // Initialization and any needed Restore operation are now complete.
            // Sync the state of the ActionBarDrawerToggle to the drawer (i.e. show the "hamburger" if the drawer is closed or an arrow if it is open).
            //
            _drawerToggle.SyncState();

            base.OnPostCreate(savedInstanceState);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            //
            // Forward all ActionBar-clicks to the ActionBarDrawerToggle.
            // It will verify the click was on the "Home" button (i.e. the button at the left edge of the ActionBar).
            // If so, it will toggle the state of the drawer. It will then return "true" so you know you do not need to do any more processing.
            //
            if (_drawerToggle.OnOptionsItemSelected(item))
                return true;

            //
            // Other cases go here for other buttons in the ActionBar.
            // This sample app has no other buttons. This code is a placeholder to show what would be needed if there were other buttons.
            //
            switch (item.ItemId)
            {
                default: break;
            }

            return base.OnOptionsItemSelected(item);
        }


        //actionbar
        void AddTab(string tabText, int iconResourceId, Fragment view)
        {
            var tab = this.ActionBar.NewTab();
            tab.SetText(tabText);
            tab.SetIcon(Resource.Drawable.ic_tab_white);

            // must set event handler before adding tab

            tab.TabSelected += delegate (object sender, Android.App.ActionBar.TabEventArgs e)
            {
                //var fragment = this.FragmentManager.FindFragmentById(Resource.Id.frameLayout);
                //if (fragment != null)
                //    e.FragmentTransaction.Remove(fragment);
                //e.FragmentTransaction.Add(Resource.Id.frameLayout, view);

                base.FragmentManager.BeginTransaction().Replace(Resource.Id.frameLayout, view).Commit();
            };
            

            tab.TabUnselected += delegate (object sender, Android.App.ActionBar.TabEventArgs e) {
                e.FragmentTransaction.Remove(view);
            };

            this.ActionBar.AddTab(tab);
        }


    }

    class SampleTabFragment : Fragment
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Resource.Layout.Tab, container, false);
            var sampleTextView = view.FindViewById<TextView>(Resource.Id.sampleTextView);
            sampleTextView.Text = "sample fragment text";

            return view;
        }
    }

    class SampleTabFragment2 : Fragment
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Resource.Layout.Tab, container, false);
            var sampleTextView = view.FindViewById<TextView>(Resource.Id.sampleTextView);
            sampleTextView.Text = "sample fragment text 2";

            return view;
        }
    }
}

//http://developer.android.com/training/implementing-navigation/nav-drawer.html
//http://developer.android.com/reference/android/app/Fragment.html

//https://university.xamarin.com/classes#and205-navigation-patterns


//v7 drawerlayout
//https://www.youtube.com/watch?v=npG0Vtn0oIk