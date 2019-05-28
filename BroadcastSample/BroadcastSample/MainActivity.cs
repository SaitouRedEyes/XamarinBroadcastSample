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
        MyBroadcastReceiver receiver;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Main);

            receiver = new MyBroadcastReceiver();
            IntentFilter myFilter = new IntentFilter("MyBroadcastReceiver");
            RegisterReceiver(receiver, myFilter);

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

        protected override void OnPause()
        {
            base.OnPause();
            UnregisterReceiver(receiver);
        }
    }
}

