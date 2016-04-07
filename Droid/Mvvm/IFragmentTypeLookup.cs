using System;

namespace MvvmXLab.Droid
{
	public interface IFragmentTypeLookup
	{
		bool TryGetFragmentType(Type viewModelType, out Type fragmentType);
	}
}

