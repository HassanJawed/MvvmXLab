using System;
using System.Linq;
using System.Collections.Generic;
using MvvmCross.Platform.IoC;
using MvvmCross.Droid.FullFragging.Fragments;

namespace MvvmXLab.Droid
{
	public class FragmentTypeLookup : IFragmentTypeLookup
	{
		private readonly IDictionary<string,Type> lookupDictionary = new Dictionary<string,Type> ();

		public FragmentTypeLookup ()
		{
			var dictionary = (from type in GetType ().Assembly.ExceptionSafeGetTypes ()
			                  where !type.IsAbstract
			                      && !type.IsInterface
			                      && typeof(MvxFragment).IsAssignableFrom (type)
			                      && type.Name.EndsWith ("Fragment")
			                  select type);

			lookupDictionary = dictionary.ToDictionary (this.getStrippedName);
 
		}

		string getStrippedName (Type type)
		{
			var fragmentName = "Fragment";
			var viewModelName = "ViewModel";
			var typeName = type.Name;
			if (typeName.EndsWith (fragmentName)) {
				typeName = typeName.Replace (fragmentName, "");
			}

			if (typeName.EndsWith (viewModelName)) {
				typeName = typeName.Replace (viewModelName, "");
			}

			return typeName;
		}

		public bool TryGetFragmentType (Type viewModelType, out Type fragmentType) {
			var viewModelName = getStrippedName (viewModelType);

			var hasFragmentType = this.lookupDictionary.ContainsKey (viewModelName);
			fragmentType = hasFragmentType? this.lookupDictionary[viewModelName] : null;

			return fragmentType != null;
		}
	}
}

