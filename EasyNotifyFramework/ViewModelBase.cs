using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EasyNotifyFramework
{
	/// <summary>
	/// Base class for every ViewModel. It maintains static graph of dependencies between properties of ViewModel.
	/// When property changes occurs, this class also raise  INotifyPropertyChanged event for all dependent ( = reachable in graph terms) properties
	/// </summary>
	/// <typeparam name="ViewModel">ViewModel class</typeparam>
	public class ViewModelBase<ViewModel> : INotifyPropertyChanged
	{
		#region Protected NestedClasses
		 
		//NOTETOSELF: Private and protected aren't considered bad, look at http://stackoverflow.com/questions/48872/why-when-should-you-use-nested-classes-in-net-or-shouldnt-you
		//On contrary public nested class are bad language concept



		/// <summary>
		/// Base interface for property notification ( =vertex in graph terms)
		/// </summary>
		protected interface PropertyNotifier
		{
			/// <summary>
			/// Name of this property
			/// </summary>
			string Name { get; }

			/// <summary>
			/// INotifyPropertyChanged interface event is called with this argument, because performance reason ( no need of new PropertyChangedEvenentArgs("...") )
			/// </summary>
			PropertyChangedEventArgs PropertyArgs { get; }
		}



		/// <summary>
		/// ViewModelPropertyNotifier implementation with bunch of added methods for easy creation of dependency graph.
		/// It uses something like Builder pattern "PropertyNotifier pro = CreateProperty<int>(x => x.Int).AlsoRaises(propertyNotif).AlsoRaises(anotherPropertyNotif)"
		/// </summary>
		protected class ViewModelPropertyNotifier : PropertyNotifier
		{
			#region Private fields

			private readonly PropertyChangedEventArgs _args;
			#endregion

			#region Ctor
			public ViewModelPropertyNotifier(string propertyName)
			{
				_args = new PropertyChangedEventArgs(propertyName);

			}
			#endregion

			#region Fields
			public string Name
			{
				get { return _args.PropertyName; }
			}

			public PropertyChangedEventArgs PropertyArgs
			{
				get { return _args; }
			}

			#endregion

			#region Methods
			public ViewModelPropertyNotifier AlsoRaises(params PropertyNotifier[] properties)
			{
				//TODO: Check null

				ViewModelBase<ViewModel>.AddDependency(this, properties);

				return this;
			}


			#endregion

		}


		#endregion


		#region Protected Fields
		static protected Dictionary<string,PropertyNotifier> _cachedProperties = new Dictionary<string,PropertyNotifier>();
		
		static protected Dictionary<PropertyNotifier,List<PropertyNotifier>>  _dependencyGraph = new Dictionary<PropertyNotifier,List<PropertyNotifier>>();
		
		static protected HashSet<PropertyNotifier> _notifyAlreadySent =new HashSet<PropertyNotifier>();
		
		#endregion



		protected static PropertyNotifier CreateNotifier<PropertyType>(Expression<Func<ViewModel,PropertyType>> property, params IEnumerable<PropertyNotifier>[] alsoRaise)
		{
			string name = PropertyNameHelper.GetPropertyName<ViewModel, PropertyType>(property);
			
			PropertyNotifier returnVal = new ViewModelPropertyNotifier(name);

			_cachedProperties.Add(name, returnVal);
			
			return returnVal;
			
		}

		protected static void SetDependencies(PropertyNotifier property , IEnumerable<PropertyNotifier> alsoRaise)
		{
			_dependencyGraph.Add(property, new List<PropertyNotifier>(alsoRaise));
		}


		protected static void AddDependency(PropertyNotifier property, PropertyNotifier alsoRaise)
		{
			List<PropertyNotifier> dependent = null;


			if (!_dependencyGraph.TryGetValue(property, out dependent))
			{
				dependent = new List<PropertyNotifier>();
				_dependencyGraph.Add(property,dependent);
			}

			dependent.Add(alsoRaise);
			
		}

		protected static bool RemoveDependency(PropertyNotifier property, PropertyNotifier dependentProperty)
		{
			List<PropertyNotifier> dependent = null;

			if (!_dependencyGraph.TryGetValue(property, out dependent))
			{
				return false;
			}


			return dependent.Remove(property);


		}
			
		protected static PropertyNotifier CreateNotifier<PropertyType>(Expression<Func<ViewModel,PropertyType>> property, params PropertyNotifier[] alsoNotify)
		{
			string name = PropertyNameHelper.GetPropertyName<ViewModel, PropertyType>(property);

			PropertyNotifier returnVal = new NormalPropertyNotifier(name);

			_cachedProperties.Add(name, returnVal);
			_dependencyGraph.Add(returnVal,alsoNotify);

			return returnVal;
		}


		protected static bool TryGetProperty(Expression<Func<ViewModel,object>> propertyExpression,out PropertyNotifier property)
		{
			
			string propertyName = PropertyNameHelper.GetPropertyName<ViewModel>(propertyExpression);

			return _cachedProperties.TryGetValue(propertyName, out property);
		
		
		}

		protected static bool TryGetProperty<PropertyType>(Expression<Func<ViewModel,PropertyType>> propertyExpression, out PropertyNotifier property)
		{
			
			string propertyName = PropertyNameHelper.GetPropertyName<ViewModel,PropertyType>(propertyExpression);

			return  _cachedProperties.TryGetValue(propertyName,out property);
		
		}



		protected void RaisePropertyChange(PropertyNotifier property)
		{
			//New notification
			_notifyAlreadySent = new HashSet<PropertyNotifier>();

			notifyChange(property.PropertyArgs);

			_notifyAlreadySent.Add(property);


			if (!_dependencyGraph.ContainsKey(property)) return;

			foreach (var prop in _dependencyGraph[property])
			{
				raisePropertyChangeRecursive(prop);
			}

		}

	

		

		#region INotifyPropertyChange
		public event PropertyChangedEventHandler PropertyChanged;
		#endregion



		#region private methods
		private static void addDependency(PropertyNotifier property, IEnumerable<PropertyNotifier> alsoRaise)
		{
			_dependencyGraph.Add(property, alsoRaise);
		}


		private void raisePropertyChangeRecursive(PropertyNotifier property)
		{
			//If notification has been already sent, then return;
			if (_notifyAlreadySent.Contains(property)) return;

			//Send notification
			notifyChange(property.PropertyArgs);

			//Add 
			_notifyAlreadySent.Add(property);


			//Recursive call of  dependent properties
			if (!_dependencyGraph.ContainsKey(property)) return;

			foreach (var prop in _dependencyGraph[property])
			{
				raisePropertyChangeRecursive(prop);
			}


		}

		private void notifyChange(PropertyChangedEventArgs propertyChangeArgs)
		{

			var handler = PropertyChanged;

			if (handler != null)
			{
				handler(this, propertyChangeArgs);
			}

		}
		#endregion

	}

	
}
