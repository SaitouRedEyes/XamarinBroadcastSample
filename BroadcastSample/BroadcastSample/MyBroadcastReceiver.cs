using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace BroadcastSample
{
    [BroadcastReceiver(Enabled = true)]
    [IntentFilter(new[] { "MyBroadcastReceiver" }, Categories = new[] { Intent.CategoryDefault })]
    public class MyBroadcastReceiver : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {
            if (intent != null)
            {
                Bundle myParameters = intent.Extras;

                if (myParameters != null)
                {
                    Toast.MakeText(context, "Received from: " + myParameters.GetString("App"), ToastLength.Short).Show();
                }
            }
            else
            {
                Toast.MakeText(context, "Received from some app:", ToastLength.Short).Show();
            }
        }
    }
}