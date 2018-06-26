using Android.App;
using Android.Widget;
using Android.OS;
using System;
using Android.Content;

namespace BroadcastSample
{
    [Activity(Label = "BroadcastSample", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Main);

            Button buttonSendBroadcast = FindViewById<Button>(Resource.Id.sendBroadcast);

            buttonSendBroadcast.Click += OnButtonSendBroadcastClicked;
        }

        private void OnButtonSendBroadcastClicked(object sender, EventArgs e)
        {
            Intent i = new Intent("MyBroadcastReceiver");

            Bundle myParameters = new Bundle();
            myParameters.PutString("App", "BroadcastSample");

            i.PutExtras(myParameters);
            SendBroadcast(i);
        }
    }
}

