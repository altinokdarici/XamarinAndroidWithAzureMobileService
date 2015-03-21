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

namespace BlogSample
{
	[Activity (Label = "AddActivity")]			
	public class AddActivity : Activity
	{
		Button buttonSend;
		EditText	editTextPost;
		ProgressBar progressBar1;
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.AddPost);

			buttonSend = FindViewById<Button> (Resource.Id.buttonSend);
			editTextPost = FindViewById<EditText> (Resource.Id.editTextPost);
			progressBar1 = FindViewById<ProgressBar> (Resource.Id.progressBar1);
			progressBar1.Visibility=ViewStates.Invisible;
			MobileServiceRepository repo = new MobileServiceRepository ();
			buttonSend.Click += async delegate {
				await repo.AddPost (editTextPost.Text);
				progressBar1.Visibility = ViewStates.Visible;
				StartActivity(typeof(MainActivity));
			};
			// Create your application here
		}
	}
}