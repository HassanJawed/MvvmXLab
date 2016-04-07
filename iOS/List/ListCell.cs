using System;

using Foundation;
using UIKit;
using MvvmCross.Binding.iOS.Views;

namespace MvvmXLab.iOS
{
	public partial class ListCell : MvxTableViewCell
	{
		private const string BindingText = "TitleText Title";

		public static readonly NSString Key = new NSString ("ListCell");
		public static readonly UINib Nib;

		static ListCell ()
		{
			Nib = UINib.FromName ("ListCell", NSBundle.MainBundle);
		}

		public ListCell (IntPtr handle) : base (BindingText, handle)
		{
		}

		public string TitleText {
			get{ return TitleLabel.Text; }
			set { TitleLabel.Text = value; }
		}
	}
}
