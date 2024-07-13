﻿using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Views;

namespace MovieNest
{
    [Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, LaunchMode = LaunchMode.SingleTop, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
    public class MainActivity : MauiAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            if (Window != null)
            {
                Window.SetStatusBarColor(Android.Graphics.Color.Transparent);

                var decorView = Window.DecorView;
                if (decorView != null)
                {
                    decorView.SystemUiVisibility = (StatusBarVisibility)(
                        SystemUiFlags.LayoutStable |
                        SystemUiFlags.LayoutFullscreen
                    );
                }
            }
        }
    }
}
