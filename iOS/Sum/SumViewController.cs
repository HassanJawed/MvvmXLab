using System;

using UIKit;
using MvvmCross.iOS.Views;
using MvvmCross.Binding.BindingContext;

namespace MvvmXLab.iOS
{
	public partial class SumViewController : MvxViewController<CalculatorViewModel>
	{
		public SumViewController () : base ("SumViewController", null)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			this.CreateBinding (ListButton).To<CalculatorViewModel> (viewModel => viewModel.ListCommand).Apply ();
		}
	}
}


