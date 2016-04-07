using System;
using MvvmCross.Core.ViewModels;

namespace MvvmXLab
{
	public class CalculatorViewModel : BaseViewModel
	{
		private Calculation cal;

		public CalculatorViewModel (Calculation cal) : base ()
		{
			this.cal = cal;
			_multiplyCommand = new MvxCommand (() => {
				ShowViewModel<MultiplyViewModel> ();
			});

			_minusCommand = new MvxCommand (() => {
				ShowViewModel<MinusViewModel> ();
			});

			_listCommand = new MvxCommand (() => {
				ShowViewModel<ListViewModel>();
			});
		}

		public override void Recalculate ()
		{
			Result = cal.sum (Num1, Num2);
		}

		private MvxCommand _multiplyCommand;

		public IMvxCommand MultiplyCommand {
			get{ return _multiplyCommand; }
		}

		private MvxCommand _minusCommand;

		public IMvxCommand MinusCommand {
			get{ return _minusCommand; }
		}

		private MvxCommand _listCommand;

		public IMvxCommand ListCommand {
			get{ return _listCommand; }
		}
	}
}

