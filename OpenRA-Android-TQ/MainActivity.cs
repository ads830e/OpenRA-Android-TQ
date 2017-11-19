using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using OpenRA;

namespace OpenRA_Android_TQ
{
    [Activity(Label = "OpenRA_Android_TQ", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        int count = 1;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.MyButton);

            Button button1 = FindViewById<Button>(Resource.Id.MyButton1);

            button.Click += delegate { button.Text = string.Format("{0} clicks!", count++); };

            button1.Click += delegate {
                String[] a = new String[0];
                OpenRA.Program.Main(a); };
            }
    }
}

