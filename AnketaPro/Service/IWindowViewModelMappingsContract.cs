using System;
using System.Diagnostics.Contracts;
using System.Windows;

namespace AnketaPro.Service
{
	[ContractClassFor(typeof(IWindowViewModelMappings))]
	abstract class WindowViewModelMappingsContract : IWindowViewModelMappings
	{
		/// <summary>
		/// Gets the window type based on registered ViewModel type.
		/// </summary>
		/// <param name="viewModelType">The type of the ViewModel.</param>
		/// <returns>
		/// The window type based on registered ViewModel type.
		/// </returns>
		public Type GetWindowTypeFromViewModelType(Type viewModelType)
		{
			Contract.Ensures(Contract.Result<Type>().IsSubclassOf(typeof(Window)));

			return default(Type);
		}
	}
}
