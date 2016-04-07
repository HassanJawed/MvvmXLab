using System;

using UIKit;
using MvvmCross.iOS.Views;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.Binding.BindingContext;
using System.Collections.Generic;

namespace MvvmXLab.iOS
{
	public partial class ListViewController : MvxViewController<ListViewModel>
	{
		public ListViewController () : base ("ListViewController", null)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			var source = new TableViewSource (this.TableView);
			this.AddBindings (new Dictionary<object, string>{ { source,"ItemsSource Names" } });
			this.TableView.Source = source;
			this.TableView.ReloadData ();
		}

		public class TableViewSource : MvxSimpleTableViewSource
		{

			public TableViewSource (UITableView tableView) : base (tableView, "ListCell", "ListCell")
			{
				
			}
		}
	}
}


