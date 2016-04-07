using System;
using MvvmCross.Core.ViewModels;

namespace MvvmXLab
{
	public class MinusViewModel : BaseViewModel
	{
		public override void Recalculate ()
		{
			Result = Num1 - Num2;
		}
	}

}

