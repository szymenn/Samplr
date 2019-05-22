using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Support.V4.Widget;
using V7Toolbar = Android.Support.V7.Widget.Toolbar;
using Android.Support.Design.Widget;
using Android.Views;
using System.Collections.Generic;
using Android.Widget;
using System;
using Android.Content;

namespace SamplerApp
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true, ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class MainActivity : AppCompatActivity 
    {
        DrawerLayout drawerLayout;
        NavigationView navigationView;

        private SampleFragment sampleFragment;
        private WelcomeFragment welcomeFragment;
        private AboutFragment aboutFragment;
        private Fragment currentFragment;
        private Stack<Fragment> stackFragment;
        public static List<string> listSample;
        public static Dictionary<string, SampleFragment> dictionarySample;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_main);

            drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout_main);
            navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);
            var toolbar = FindViewById<V7Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetDisplayShowTitleEnabled(false);
            SupportActionBar.SetHomeButtonEnabled(true);
            var drawerToggle = 
                new ActionBarDrawerToggle(this, drawerLayout, toolbar, Resource.String.drawer_open, Resource.String.drawer_close);
            drawerLayout.AddDrawerListener(drawerToggle);
            drawerToggle.SyncState();
            navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);
            SetupDrawerContent(navigationView);

            sampleFragment = new SampleFragment();
            aboutFragment = new AboutFragment();
            welcomeFragment = new WelcomeFragment();
            stackFragment = new Stack<Fragment>();
            listSample = new List<string>();
            dictionarySample = new Dictionary<string, SampleFragment>();

            FragmentTransaction transaction = FragmentManager.BeginTransaction();
            transaction.Add(Resource.Id.fragmentContainer, aboutFragment, "About Fragment");
            transaction.Hide(aboutFragment);
            transaction.Add(Resource.Id.fragmentContainer, sampleFragment, "Sample Fragment");
            transaction.Hide(sampleFragment);
            transaction.Add(Resource.Id.fragmentContainer, welcomeFragment, "Welcome Fragment");
            currentFragment = welcomeFragment;
            transaction.Commit();

        }

        void SetupDrawerContent(NavigationView navigationView)
        {
            navigationView.NavigationItemSelected += (sender, e) =>
            {
                switch (e.MenuItem.ItemId)
                {
                    case Resource.Id.nav_home:
                        ShowFragment(welcomeFragment);
                        break;
                    case Resource.Id.nav_sample:
                        ShowFragment(sampleFragment);
                        break;
                    case Resource.Id.nav_about:
                        ShowFragment(aboutFragment);
                        break;
                }
                drawerLayout.CloseDrawers();
            };
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            navigationView.InflateMenu(Resource.Menu.nav_menu);
            return true;
        }

        public override void OnBackPressed()
        {
            if (FragmentManager.BackStackEntryCount > 0)
            {
                FragmentManager.PopBackStack();
                currentFragment = stackFragment.Pop();
            }
            else
            {
                base.OnBackPressed();
            }
        }

        private void ShowFragment(Fragment fragment)
        {
            FragmentTransaction transaction = FragmentManager.BeginTransaction();

            transaction.Hide(currentFragment);
            transaction.Show(fragment);
            transaction.AddToBackStack(null);
            transaction.Commit();

            stackFragment.Push(currentFragment);
            currentFragment = fragment;
        }

        private void ReplaceSampleFragment(SampleFragment fragment)
        {
            FragmentTransaction transaction = FragmentManager.BeginTransaction();

            sampleFragment = new SampleFragment();
            transaction.Add(Resource.Id.fragmentContainer, sampleFragment, "Sample Fragment");
            transaction.Hide(sampleFragment);
            transaction.Commit();
        }

    }   
}