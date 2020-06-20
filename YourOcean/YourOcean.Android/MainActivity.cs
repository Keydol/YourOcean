using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android;
using Android.Support.V4.Content;
using Android.Support.V4.App;
using Android.Util;
using Android.Support.Design.Widget;
using Android.Text;
using static Android.App.ActivityManager;
using Android.Content;
using System.Collections.Generic;

namespace YourOcean.Droid
{
    [Activity(Label = "YourOcean", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {

        int REQUEST_LOCATION = 95;
        string TAG = "YourOcean";
        string permission_location_rationale = "95";
        CoordinatorLayout rootLayout;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());

            if (ActivityCompat.ShouldShowRequestPermissionRationale(this, Manifest.Permission.AccessFineLocation))
            {
                // Provide an additional rationale to the user if the permission was not granted
                // and the user would benefit from additional context for the use of the permission.
                // For example if the user has previously denied the permission.
                Log.Info(TAG, "Displaying camera permission rationale to provide additional context.");

                var requiredPermissions = new String[] { Manifest.Permission.AccessFineLocation };
                Snackbar.Make(rootLayout,
                               95,
                               Snackbar.LengthIndefinite)
                        .SetAction("ok",
                                   new Action<View>(delegate (View obj) {
                                       ActivityCompat.RequestPermissions(this, requiredPermissions, REQUEST_LOCATION);
                                   }
                        )
                ).Show();
            }
            else
            {
                ActivityCompat.RequestPermissions(this, new String[] { Manifest.Permission.Camera }, REQUEST_LOCATION);
            }

            ActivityManager activityManager = (ActivityManager)BaseContext.GetSystemService(Context.ActivityService);
            ActivityManager.MemoryInfo memoryInfo = new ActivityManager.MemoryInfo();
            activityManager.GetMemoryInfo(memoryInfo);

            List<ActivityManager.RunningAppProcessInfo> runningAppProcesses = activityManager.RunningAppProcesses as List<ActivityManager.RunningAppProcessInfo>;

        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}