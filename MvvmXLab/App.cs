using System;
using MvvmCross.Platform;
using MvvmCross.Core.ViewModels;

namespace MvvmXLab
{
	public class App : MvxApplication
	{
		public App()
		{
			Mvx.RegisterType<Calculation,Calculation>();
			Mvx.RegisterSingleton<IMvxAppStart>(new MvxAppStart<CalculatorViewModel>());
		}

	}
}

