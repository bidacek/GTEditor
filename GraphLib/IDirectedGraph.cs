using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphLib
{
	public interface IDirectedGraph : IGraph
	{
		IEnumerable<DirectedEdge> Edges { get; }

		DirectedEdge CreateEdge(IVertex firstVertex, IVertex secondVertex);


		IEnumerable<DirectedEdge> GetIncidentEdges(IVertex vertex);


		IEnumerable<DirectedEdge> GetOutputEdges(IVertex vertex);


		IEnumerable<DirectedEdge> GetInputEdges(IVertex vertex);
		
	}

	abstract class BaseDirected : IDirectedGraph
	{
		HashSet<IVertex> _vertices = new HashSet<IVertex>();

		public abstract IEnumerable<DirectedEdge> Edges;

		public abstract DirectedEdge CreateEdge(IVertex firstVertex, IVertex secondVertex);

		public IEnumerable<DirectedEdge> GetIncidentEdges(IVertex vertex)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<DirectedEdge> GetOutputEdges(IVertex vertex)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<DirectedEdge> GetInputEdges(IVertex vertex)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<IVertex> Vertices
		{
			get { throw new NotImplementedException(); }
		}

		public int CountOfVertices
		{
			get { return _vertices.Count; }
		}

		public bool Contains(IVertex vertex)
		{
			return _vertices.Contains(vertex);
		}

		public IVertex CreateVertex()
		{
			IVertex vertex = new Vertex();
			_vertices.Add(vertex);
			return vertex;
		}

		public bool RemoveVertex(IVertex vertex)
		{
			return _vertices.Remove(vertex);
		}

		IEnumerable<IEdge> IGraph.Edges
		{
			get { return Edges; }
		}

		public abstract int CountOfEdges;

		public abstract bool Contains(IEdge e);

		public abstract bool Contains(IVertex firstVertex, IVertex secondVertex);

		IEdge IGraph.CreateEdge(IVertex firstVertex, IVertex secondVertex)
		{
			return CreateEdge(firstVertex, secondVertex);
		}

		public abstract bool RemoveEdge(IEdge edge);

		public abstract bool RemoveEdge(IVertex firstVertex, IVertex secondVertex);

		IEnumerable<IEdge> IGraph.GetIncidentEdges(IVertex vertex)
		{
			return GetIncidentEdges(vertex);
		}

		public abstract int CountOfIncidentEdges(IVertex vertex);

		IEnumerable<IEdge> IGraph.GetOutputEdges(IVertex vertex)
		{
			return GetOutputEdges(vertex);
		}

		public abstract int CountOfOutputEdges(IVertex vertex);


		IEnumerable<IEdge> IGraph.GetInputEdges(IVertex vertex)
		{
			return GetInputEdges(vertex);
		}

		public abstract int CountOfInputEdges(IVertex vertex);
	}



	interface DirectedEdge : IEdge
	{
	}

	public class DirectedImp : BaseDirected {

		HashSet<DirectedEdge> _edges = new HashSet<DirectedEdge>();

		public override DirectedEdge CreateEdge(IVertex firstVertex, IVertex secondVertex)
		{
			throw new NotImplementedException();
		}

		public override bool Contains(IEdge e)
		{
			return _edges.Contains(e);
		}

		public override bool Contains(IVertex firstVertex, IVertex secondVertex)
		{
			throw new NotImplementedException();
		}

		public override bool RemoveEdge(IEdge edge)
		{
			throw new NotImplementedException();
		}

		public override bool RemoveEdge(IVertex firstVertex, IVertex secondVertex)
		{
			throw new NotImplementedException();
		}

		public override int CountOfIncidentEdges(IVertex vertex)
		{
			throw new NotImplementedException();
		}

		public override int CountOfOutputEdges(IVertex vertex)
		{
			throw new NotImplementedException();
		}

		public override int CountOfInputEdges(IVertex vertex)
		{
			throw new NotImplementedException();
		}
	}


	
}
