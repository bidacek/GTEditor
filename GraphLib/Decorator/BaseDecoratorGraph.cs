using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphLib.Decorator
{
	class BaseDecoratorGraph : IGraph
	{
		IGraph _decoratedGraph;
		public BaseDecoratorGraph(IGraph decoratedGraph)
		{
			_decoratedGraph = decoratedGraph;

		}
		
		public virtual IEnumerable<IVertex> Vertices
		{
			get { return _decoratedGraph.Vertices; }
		}

		public virtual bool Contains(IVertex vertex)
		{
			return _decoratedGraph.Contains(vertex);
		}

		public virtual IVertex CreateVertex()
		{
			return _decoratedGraph.CreateVertex();
		}

		public virtual bool RemoveVertex(IVertex vertex)
		{
			return _decoratedGraph.RemoveVertex(vertex);
		}

		public virtual IEnumerable<IEdge> Edges
		{
			get { return _decoratedGraph.Edges; }
		}

		public virtual bool Contains(IEdge edge)
		{
			return _decoratedGraph.Contains(edge);
		}

		public virtual bool Contains(IVertex firstVertex, IVertex secondVertex)
		{
			return _decoratedGraph.Contains(firstVertex, secondVertex);
		}

		public virtual IEdge CreateEdge(IVertex firstVertex, IVertex secondVertex)
		{
			return _decoratedGraph.CreateEdge(firstVertex, secondVertex);
		}

		public virtual bool RemoveEdge(IEdge edge)
		{
			return _decoratedGraph.RemoveEdge(edge);
		}

		public virtual bool RemoveEdge(IVertex firstVertex, IVertex secondVertex)
		{
			return _decoratedGraph.RemoveEdge(firstVertex, secondVertex);
		}

		public virtual IEnumerable<IEdge> GetIncidentEdges(IVertex vertex)
		{
			return _decoratedGraph.GetIncidentEdges(vertex);
		}

		public virtual IEnumerable<IEdge> GetOutputEdges(IVertex vertex)
		{
			return _decoratedGraph.GetOutputEdges(vertex);
		}

		public virtual IEnumerable<IEdge> GetInputEdges(IVertex vertex)
		{
			return _decoratedGraph.GetInputEdges(vertex);
		}



		public virtual int CountOfVertices
		{
			get { return _decoratedGraph.CountOfVertices;  }
		}

		public virtual int CountOfEdges
		{
			get { return _decoratedGraph.CountOfEdges; }
		}


		public virtual int CountOfIncidentEdges(IVertex vertex)
		{
			return _decoratedGraph.CountOfIncidentEdges(vertex);
		}

		public virtual int CountOfOutputEdges(IVertex vertex)
		{
			return _decoratedGraph.CountOfOutputEdges(vertex);
		}

		public virtual int CountOfInputEdges(IVertex vertex)
		{
			return _decoratedGraph.CountOfInputEdges(vertex);
		}
	}
}
