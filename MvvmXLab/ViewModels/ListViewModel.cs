using System;
using MvvmCross.Core.ViewModels;
using System.Collections.Generic;

namespace MvvmXLab
{
	public class ListViewModel : MvxViewModel
	{
		public ListViewModel ()
		{
			_names = new List<Data> (new Data[] { 
				new Data () { Title = "A1" },
				new Data () { Title = "A2" },
				new Data () { Title = "A3" },
				new Data () { Title = "A4" },
				new Data () { Title = "A5" },
				new Data () { Title = "A6" },
				new Data () { Title = "A7" },
				new Data () { Title = "A8" },
			});
		}

		private string _title;

		public string Title {
			get{ return _title; }
			set {
				_title = value;
				RaisePropertyChanged (() => Title);
			}
		}

		private List<Data> _names;

		public List<Data> Names {
			get{ return _names; }
			set {
				_names = value;
				RaisePropertyChanged (() => Names);
			}
		}

		public class Data
		{
			public string Title { get; set; }


			public Data ()
			{
			}
		}
	}
}

