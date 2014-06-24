using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EasyNotifyFramework
{	

	/// <summary>
	/// Helper for getting property name from given expression in form of "x => x.Property"
	/// </summary>
	static class PropertyNameHelper
	{

		/// <summary>
		/// Returns name of given property
		/// </summary>
		/// <typeparam name="ParrentClass">Class which contains given property</typeparam>
		/// <param name="property">Epression returning property typically "x => x.Property" </param>
		/// <returns>Property name</returns>
		public static string GetPropertyName<ParrentClass>(Expression<Func<ParrentClass, object>> property)
		{


			var lambda = (LambdaExpression)property;
			MemberExpression memberExpression;
			if (lambda.Body is UnaryExpression)
			{
				var unaryExpression = (UnaryExpression)lambda.Body;
				memberExpression = (MemberExpression)unaryExpression.Operand;
			}
			else memberExpression = (MemberExpression)lambda.Body;

			return memberExpression.Member.Name;
		}

		/// <summary>
		/// Returns name of given property. 
		/// This method provides more type safety, because property type is defined
		/// </summary>
		/// <typeparam name="ParrentClass">Class which contains given property</typeparam>
		/// <typeparam name="ValueType">Type of given property</typeparam>
		/// <param name="property">Epression returning property typically "x => x.Property"</param>
		/// <returns>Property name</returns>
		public static string GetPropertyName<ParrentClass,ValueType>(Expression<Func<ParrentClass, ValueType>> property)
		{


			var lambda = (LambdaExpression)property;
			MemberExpression memberExpression;
			if (lambda.Body is UnaryExpression)
			{
				var unaryExpression = (UnaryExpression)lambda.Body;
				memberExpression = (MemberExpression)unaryExpression.Operand;
			}
			else memberExpression = (MemberExpression)lambda.Body;

			return memberExpression.Member.Name;
		}


	}
}
