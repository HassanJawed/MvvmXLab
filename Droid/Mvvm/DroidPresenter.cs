using System;
using MvvmCross.Core.Views;
using MvvmCross.Droid.Views;
using MvvmCross.Droid.FullFragging.Fragments;
using MvvmCross.Core.ViewModels;
using Android.App;
using MvvmXLab.Droid;

namespace MvvmXLab.Droid
{
	public class DroidPresenter : MvxAndroidViewPresenter
	{
		private readonly IFragmentTypeLookup fragmentLookup;
		private readonly IMvxViewModelLoader viewModelLoader;
		private FragmentManager fragmentManager;

		public DroidPresenter (IFragmentTypeLookup fragmentLookup, IMvxViewModelLoader viewModelLoader)
		{
			this.fragmentLookup = fragmentLookup;
			this.viewModelLoader = viewModelLoader;
		}

		public void RegisterFragmentManager(FragmentManager fragmentManager) {
			this.fragmentManager = fragmentManager;
		}

		public void RegisterFragmentManager(FragmentManager fragmentManager, MvxFragment fragment) {
			this.fragmentManager = fragmentManager;
			showFragment (fragment, false);
		}

		public override void Show(MvxViewModelRequest request) {
			Type fragmentType;

			if (!this.fragmentLookup.TryGetFragmentType (request.ViewModelType, out fragmentType)) {
				base.Show (request);
				return;
			}

			var fragment = (MvxFragment)Activator.CreateInstance(fragmentType);
			fragment.ViewModel = this.viewModelLoader.LoadViewModel (request, null);
			showFragment (fragment, true);
		}

		private void showFragment (MvxFragment fragment, bool shouldAddToBackStack)
		{
			var transaction = this.fragmentManager.BeginTransaction ();

			if (shouldAddToBackStack) {
				transaction.AddToBackStack (nameof (fragment));
			}

			transaction.Replace (Resource.Id.contentFrame, fragment).Commit();
		}

		public override void Close(IMvxViewModel viewModel) { 
			var currentFragment = this.fragmentManager.FindFragmentById (Resource.Id.contentFrame) as MvxFragment;

			if (currentFragment != null && currentFragment.ViewModel == viewModel) {
				this.fragmentManager.PopBackStackImmediate ();
				return;
			}

			base.Close (viewModel);
		}
	}
}

