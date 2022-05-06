using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Widget;
using AndroidX.AppCompat.App;
using Xamarin.Essentials;

namespace EssentialsTest
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Platform.Init(this, savedInstanceState);
            
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            var requestPermissionButton = FindViewById<Button>(Resource.Id.request_permission);
            requestPermissionButton.Click += async (sender, args) =>
            {
                var result = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();

                Toast.MakeText(this, $"Request Permission: {result}", ToastLength.Short).Show();
            };
            
            var checkPermissionButton = FindViewById<Button>(Resource.Id.check_permission);
            checkPermissionButton.Click += async (sender, args) =>
            {
                var result = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();

                Toast.MakeText(this, $"Check Permission: {result}", ToastLength.Short).Show();
            };
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
        {
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}