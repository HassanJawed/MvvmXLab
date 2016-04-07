using System;
using MvvmCross.Core.ViewModels;

namespace MvvmXLab
{
	public abstract class BaseViewModel:MvxViewModel
	{
		public BaseViewModel ()
		{
			_calculateCommand = new MvxCommand (() => {
				Recalculate();
			});
		}

		public void Clear ()
		{
			Num1 = 1;
			Num2 = 0;
			Recalculate ();
		}

		abstract public void Recalculate ();

		private int num1;

		public int Num1 {
			get { return num1; }
			set {
				num1 = value;
				RaisePropertyChanged (() => num1);
			}
		}

		private int num2;

		public int Num2 {
			get { return num2; }
			set {
				num2 = value;
				RaisePropertyChanged (() => num2);
			}
		}

		private int result;

		public int Result {
			get { return result; }
			set {
				result = value;
				RaisePropertyChanged (() => Result);
			}
		}

		private MvxCommand _calculateCommand;

		public IMvxCommand CalculateCommand {
			get { return _calculateCommand; }
		}
	}
}

