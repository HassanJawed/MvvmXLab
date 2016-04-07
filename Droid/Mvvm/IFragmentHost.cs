using System;
using MvvmCross.Core.ViewModels;

namespace MvvmXLab.Droid
{
	public interface IFragmentHost
	{
		bool Show (MvxViewModelRequest request);
	}
}

