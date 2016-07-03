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

namespace AppDave
{
    //(way #2)
    //[Activity(Label = "AppDave", MainLauncher = true, Icon = "@drawable/icon", Theme = "@style/MyTheme", ConfigurationChanges=Android.Content.PM.ConfigChanges.ScreenSize | Android.Content.PM.ConfigChanges.Orientation)]
    //[Activity(Label = "AppDave", MainLauncher = true, Icon = "@drawable/icon", Theme = "@style/MyTheme")]

    [Activity(Label = "AppDave", MainLauncher = true, Icon = "@drawable/icon", Theme = "@style/MyTheme")]
    public class MainActivity : AppCompatActivity //ActionBarActivity //AppCompatActivity
    {
        private SupportToolbar _toolbar;

        private MyActionBarDrawerToggle _drawerToggle;
        private DrawerLayout _drawerLayout;
        private ListView _leftDrawer;
        private ListView _rightDrawer;
        private ArrayAdapter _leftAdapter;
        private ArrayAdapter _rightAdapter;
        private List<string> _leftDataSet;
        private List<string> _rightDataSet;

        private SupportFragment _currentFragment;
        private Fragment1 _fragment1;
        private Fragment2 _fragment2;
        private Fragment3 _fragment3;
        private Stack<SupportFragment> _stackFragment;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
                    
            SetContentView(Resource.Layout.Main);

            //keep one orientation (way #1)
            //RequestedOrientation = Android.Content.PM.ScreenOrientation.Portrait;


            //drawer
            _toolbar = FindViewById<SupportToolbar>(Resource.Id.toolbar);
            _drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            _leftDrawer = FindViewById<ListView>(Resource.Id.left_drawer);
            _rightDrawer = FindViewById<ListView>(Resource.Id.right_drawer);

            if (SupportFragmentManager.FindFragmentByTag("Fragment1") != null)
            {
                if (SupportFragmentManager.FindFragmentByTag("Fragment1") != null)
                    _fragment1 = SupportFragmentManager.FindFragmentByTag("Fragment1") as Fragment1;

                if (SupportFragmentManager.FindFragmentByTag("Fragment2") != null)
                    _fragment2 = SupportFragmentManager.FindFragmentByTag("Fragment2") as Fragment2;

                if (SupportFragmentManager.FindFragmentByTag("Fragment3") != null)
                    _fragment3 = SupportFragmentManager.FindFragmentByTag("Fragment3") as Fragment3;
            }
            else
            {
                //no fragments in the container
                _fragment1 = new Fragment1();
                
                var trans = SupportFragmentManager.BeginTransaction();
                trans.Add(Resource.Id.fragmentContainer, _fragment1, "Fragment1");                
                trans.Commit();
                _currentFragment = _fragment1;
            }
            
            _stackFragment = new Stack<SupportFragment>();
            
            //sets the actionbar to our toolbar
            SetSupportActionBar(_toolbar);

            //we can now call our toolbar via SupportActionBar
            //SupportActionBar.Title = "MyToolbar";
            
            _leftDrawer.Tag = 0;
            _rightDrawer.Tag = 1;


            //var trans = SupportFragmentManager.BeginTransaction();
            //trans.Add(Resource.Id.fragmentContainer, _fragment3, "Fragment3");
            //trans.Hide(_fragment3); //will be shown by default so we must hide

            //trans.Add(Resource.Id.fragmentContainer, _fragment2, "Fragment2");
            //trans.Hide(_fragment2);

            //trans.Add(Resource.Id.fragmentContainer, _fragment1, "Fragment1"); //first to show as last added (highest zindex)
            //trans.Commit();

            //_currentFragment = _fragment1;

            _leftDataSet = new List<string>();
            _leftDataSet.Add("About");
            _leftDataSet.Add("Blog");
            _leftDataSet.Add("Twitter");
            _leftDataSet.Add("Other");

            _leftAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, _leftDataSet);
            _leftDrawer.Adapter = _leftAdapter;
            _leftDrawer.ItemClick += _leftDrawer_ItemClick;
            
            _rightDataSet = new List<string>();
            _rightDataSet.Add("Right Item 1");
            _rightDataSet.Add("Right Item 2");
            _rightAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, _rightDataSet);
            _rightDrawer.Adapter = _rightAdapter;

            _drawerToggle = new MyActionBarDrawerToggle(
                this,                           //Host Activity
                _drawerLayout,                  //DrawerLayout
                Resource.String.openDrawer,     //Opened Message
                Resource.String.closeDrawer     //Closed Message
            );

            _drawerLayout.SetDrawerListener(_drawerToggle);
            SupportActionBar.SetHomeButtonEnabled(true);
            SupportActionBar.SetDisplayShowTitleEnabled(true);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            _drawerToggle.SyncState();



          


            //a bundle is passed in when a configuration change occurs (i.e. portrait to landscape)
            if (bundle != null)
            {
                if (bundle.GetString("DrawerState") == "Opened")
                {
                    SupportActionBar.SetTitle(Resource.String.openDrawer);
                }
                else
                {
                    //this is the first time the activity is ran
                    SupportActionBar.SetTitle(Resource.String.closeDrawer);
                }
            }
            else
            {
                //This is the first the time the activity is ran
                SupportActionBar.SetTitle(Resource.String.closeDrawer);
            }
        }

       public void TestMethod()
        {
            if (_fragment2 == null)
                _fragment2 = new Fragment2();

            ReplaceFragment(_fragment2, "Fragment2");
        }

        private void _leftDrawer_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var position = e.Position;
            //ReplaceFragment(_fragment2, addFragmentToContainer);

            _drawerLayout.CloseDrawer(_leftDrawer);
            
        }

        private void ReplaceFragment(SupportFragment fragment, string tag)
        {
            if (fragment.IsVisible)
                return;

            var trans = SupportFragmentManager.BeginTransaction();           
            trans.Replace(Resource.Id.fragmentContainer, fragment, tag);
            trans.AddToBackStack(null);
            trans.Commit();
            _currentFragment = fragment;
        }

        //private void ShowFragment(SupportFragment fragment)
        //{
        //    if (fragment.IsVisible)
        //        return;

        //    var transaction = SupportFragmentManager.BeginTransaction();
        //    transaction.Hide(_currentFragment);
        //    transaction.Show(fragment);
        //    transaction.AddToBackStack(null); //this allows to go back to prior fragment
        //    transaction.Commit();

        //    _stackFragment.Push(_currentFragment);
        //    _currentFragment = fragment;
        //}

        public override void OnBackPressed()
        {
            //use if doing show hide of fragments
            //if (SupportFragmentManager.BackStackEntryCount > 0)//something is stack if >0
            //{
            //    SupportFragmentManager.PopBackStack();
            //    _currentFragment = _stackFragment.Pop();
            //}
            //else {
            //    base.OnBackPressed();
            //}
            //use if replacing otherwise use our own stack above
            base.OnBackPressed();
        }


        //is called when icon is selected
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            
            switch (item.ItemId)
            {                
                case Android.Resource.Id.Home:
                    //The hamburger icon was clicked which means the drawer toggle will handle the event
                    //all we need to do is ensure the right drawer is closed so the don't overlap
                    _drawerLayout.CloseDrawer(_rightDrawer);
                    _drawerToggle.OnOptionsItemSelected(item);
                    return true;

                //case Resource.Id.action_refresh:
                //    //Refresh
                //    return true;

                case Resource.Id.action_fragment1:
                    //ShowFragment(_fragment1);

                    if (_fragment1 == null)                    
                        _fragment1 = new Fragment1();          
                        
                        ReplaceFragment(_fragment1, "Fragment1");
                    return true;
                case Resource.Id.action_fragment2:
                    //ShowFragment(_fragment2);
                    if (_fragment2 == null) 
                        _fragment2 = new Fragment2();
                        
                    ReplaceFragment(_fragment2, "Fragment2");
                    return true;
                case Resource.Id.action_fragment3:
                    //ShowFragment(_fragment3);
                    
                    if (_fragment3 == null)                    
                        _fragment3 = new Fragment3();

                    ReplaceFragment(_fragment3, "Fragment3");
                    return true;
                case Resource.Id.action_help:
                    if (_drawerLayout.IsDrawerOpen(_rightDrawer))
                    {
                        //Right Drawer is already open, close it
                        _drawerLayout.CloseDrawer(_rightDrawer);
                    }
                    else
                    {
                        //Right Drawer is closed, open it and just in case close left drawer
                        _drawerLayout.OpenDrawer(_rightDrawer);
                        _drawerLayout.CloseDrawer(_leftDrawer);
                    }
                    return true;
                default:
                    return base.OnOptionsItemSelected(item);
            }
        }

        //action menu
        public override bool OnCreateOptionsMenu(IMenu menu)
        {            
            MenuInflater.Inflate(Resource.Menu.action_menu, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        protected override void OnSaveInstanceState(Bundle outState)
        {
            if (_drawerLayout.IsDrawerOpen((int)GravityFlags.Left))
            {
                outState.PutString("DrawerState", "Opened");
            }
            else
            {
                outState.PutString("DrawerState", "Closed");
            }
            base.OnSaveInstanceState(outState);
        }

        protected override void OnPostCreate(Bundle savedInstanceState)
        {
            base.OnPostCreate(savedInstanceState);
            _drawerToggle.SyncState();
        }

        public override void OnConfigurationChanged(Android.Content.Res.Configuration newConfig)
        {
            base.OnConfigurationChanged(newConfig);
            _drawerToggle.OnConfigurationChanged(newConfig);
        }


    }
}

