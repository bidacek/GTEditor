using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyNotifyFramework
{
	class ProxyViewModelBase<ViewModel, Model> : ViewModelBase<ViewModel> where Model : INotifyPropertyChanged
	{
		#region Protected fields

		protected static Dictionary<string, List<IProperty<ViewModel>>> _dependencies = new Dictionary<string, List<IProperty<ViewModel>>>();
		protected Model _model;

		#endregion




		#region ProxyPropertyNotifier implementation
		protected class ProxyPropertyNotifier : PropertyNotifier
		{

			public ProxyPropertyNotifier AlsoRaises(params PropertyNotifier[] properties);
			public ProxyPropertyNotifier DependsOn(params Expression<Func<Model, object>>[] modelProperties);
			public ProxyPropertyNotifier DependsOn<PropertyType>(Expression<Func<Model, PropertyType>> modelProperty);

		}
		#endregion




		#region Ctor
		public ProxyViewModelBase(Model model)
		{

			_model = model;
			Register();
		}
		#endregion
		private static void SetDependency(string name, IProperty<ViewModel> property)
		{

		}

		private void model_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{

			List<IProperty<ViewModel>> dependentProperties = null;
			if (!_dependencies.TryGetValue(e.PropertyName, out dependentProperties))
			{
				return;
			}

			foreach (var prop in dependentProperties)
			{

				RaisePropertyChange(prop);
			}
		}




		protected void Unregister()
		{
			_model.PropertyChanged -= model_PropertyChanged;
		}

		protected void Register()
		{
			_model.PropertyChanged += model_PropertyChanged;
		}



	}
}
