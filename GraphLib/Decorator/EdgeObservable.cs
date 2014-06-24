using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphLib.Decorator
{
	class EdgeObservable : BaseDecoratorGraph , IObservable<IEdge>
	{

		private List<IObserver<IEdge>> _edgeObservers = new List<IObserver<IEdge>>();

		public override IEdge CreateEdge(IVertex firstVertex, IVertex secondVertex)
		{
			return base.CreateEdge(firstVertex, secondVertex);
		}

		public override bool RemoveEdge(IEdge edge)
		{
			bool wasRemoved = base.RemoveEdge(edge);

			
			return base.RemoveEdge(edge);
		}

		public override bool RemoveEdge(IVertex firstVertex, IVertex secondVertex)
		{
			return base.RemoveEdge(firstVertex, secondVertex);
		}

		//TODO: At this moment I'm not sure, how this default IObservable interface works.
		public IDisposable Subscribe(IObserver<IEdge> observer)
		{
			_edgeObservers.Add(observer);
			throw new NotImplementedException();
		}

		private void Notify(IEdge edge)
		{
			foreach (IObserver<IEdge> obs in _edgeObservers)
			{
				obs.OnNext(edge);
			}
		}
	}
}
