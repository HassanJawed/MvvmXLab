// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace MvvmXLab.iOS
{
	[Register ("SumViewController")]
	partial class SumViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton ListButton { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (ListButton != null) {
				ListButton.Dispose ();
				ListButton = null;
			}
		}
	}
}
