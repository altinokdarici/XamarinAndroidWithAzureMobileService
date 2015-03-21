using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;

namespace BlogSample
{
	[Activity (Label = "BlogSample", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		ListView listViewPosts;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			Button button = FindViewById<Button> (Resource.Id.buttonNavigateNewPost);
			listViewPosts = FindViewById<ListView> (Resource.Id.listViewPosts);
			button.Click += delegate {
				StartActivity(typeof(AddActivity));
			};

			FillData ();
		}

		private async void FillData()
		{
			MobileServiceRepository repo = new MobileServiceRepository ();
			List<string> list =	await repo.GetPosts ();
			ArrayAdapter<string> adapter = new ArrayAdapter<string> (this, Resource.Layout.ListViewItem, list);
			listViewPosts.Adapter = adapter;
		}
	}
}


