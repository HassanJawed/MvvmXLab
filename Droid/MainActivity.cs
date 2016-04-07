using Android.App;
using Android.Widget;
using Android.OS;
using MvvmCross.Droid.Views;
using System;
using MvvmCross.Platform;

namespace MvvmXLab.Droid
{
	[Activity (Label = "MvvmX Lab", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : MvxActivity
	{
		int count = 1;

		public new CalculatorViewModel ViewModel {
			get { return (CalculatorViewModel)base.ViewModel; }
			set { base.ViewModel = value; }
		}

		protected override void OnViewModelSet ()
		{
			base.OnViewModelSet ();
			SetContentView (Resource.Layout.Main);
			Console.WriteLine ("Inside OnViewModelSet");
		}

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			Console.WriteLine ("Inside OnCreate");

			var presenter = (DroidPresenter)Mvx.Resolve <MvxAndroidViewPresenter> ();
			var fragment = new SumFragment ();
			fragment.ViewModel = this.ViewModel;
			presenter.RegisterFragmentManager (this.FragmentManager, fragment);
		}
	}
}


