using System;
using MvvmCross.Droid.Platform;
using Android.Content;
using MvvmCross.Platform;
using MvvmCross.Droid.Views;

namespace MvvmXLab.Droid
{
	public class Setup:MvxAndroidSetup
	{

		public Setup (Context appContext) : base (appContext)
		{
		}

		protected override MvvmCross.Core.ViewModels.IMvxApplication CreateApp ()
		{
			return new App ();
		}

		protected override MvvmCross.Droid.Views.IMvxAndroidViewPresenter CreateViewPresenter ()
		{
			var presenter = Mvx.IocConstruct<DroidPresenter> ();
			Mvx.RegisterSingleton<MvxAndroidViewPresenter> (presenter);
			return presenter;
		}

		protected override void InitializeIoC ()
		{
			base.InitializeIoC ();

			Mvx.ConstructAndRegisterSingleton<IFragmentTypeLookup, FragmentTypeLookup> ();
		}

//		protected override MvvmCross.Core.ViewModels.IMvxNavigationSerializer CreateNavigationSerializer ()
//		{
//			return new MvxJsonNavigationSerializer ();
//		}

	}
}

