using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphLib
{
	class DirectedGraph : IDirectedGraph
	{

		#region Fields
		private Dictionary<IVertex, Tuple<List<DirectedEdge>,List<DirectedEdge>>> _adjacency = new Dictionary<IVertex, Tuple<List<DirectedEdge>,List<DirectedEdge>>>();

		#endregion

		public IEnumerable<DirectedEdge> Edges
		{
			get{

				foreach (var vert in _adjacency.Keys)
				{
					foreach (DirectedEdge edge in _adjacency[vert].Item1)
					{
						yield return edge;
					}
				}
			
			
			}
		}


		
		public DirectedEdge CreateEdge(IVertex firstVertex, IVertex secondVertex)
		{
			throw new NotImplementedException();
		}

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
			get { return _adjacency.Count; }
		}

		public bool Contains(IVertex vertex)
		{
			return _adjacency.ContainsKey(vertex);
		}

		public IVertex CreateVertex()
		{
			Vertex vertex = new Vertex();

			_adjacency.Add(vertex, new Tuple<List<DirectedEdge>, List<DirectedEdge>>( new List<DirectedEdge(),new List<DirectedEdge>()));

			return vertex;
		}

		public bool RemoveVertex(IVertex vertex)
		{
			Tuple<List<DirectedEdge>,List<DirectedEdge>> incidentEdges;
			
			if (!_adjacency.TryGetValue(vertex, out incidentEdges)) return false;

			foreach (var edge in incidentEdges.Item1)
			{
				RemoveEdge(edge);
			}

			foreach (var edge in incidentEdges.Item2)
			{
				RemoveEdge(edge);
			}

			return _adjacency.Remove(vertex);


		}

		IEnumerable<IEdge> IGraph.Edges
		{
			get { throw new NotImplementedException(); }
		}

		public int CountOfEdges
		{
			get { throw new NotImplementedException(); }
		}

		public bool Contains(IEdge e)
		{
			throw new NotImplementedException();
		}

		public bool Contains(IVertex firstVertex, IVertex secondVertex)
		{
			throw new NotImplementedException();
		}

		IEdge IGraph.CreateEdge(IVertex firstVertex, IVertex secondVertex)
		{
			throw new NotImplementedException();
		}

		public bool RemoveEdge(IEdge edge)
		{
			throw new NotImplementedException();
		}

		public bool RemoveEdge(IVertex firstVertex, IVertex secondVertex)
		{
			throw new NotImplementedException();
		}

		IEnumerable<IEdge> IGraph.GetIncidentEdges(IVertex vertex)
		{
			throw new NotImplementedException();
		}

		public int CountOfIncidentEdges(IVertex vertex)
		{
			throw new NotImplementedException();
		}

		IEnumerable<IEdge> IGraph.GetOutputEdges(IVertex vertex)
		{
			throw new NotImplementedException();
		}

		public int CountOfOutputEdges(IVertex vertex)
		{
			throw new NotImplementedException();
		}

		IEnumerable<IEdge> IGraph.GetInputEdges(IVertex vertex)
		{
			throw new NotImplementedException();
		}

		public int CountOfInputEdges(IVertex vertex)
		{
			throw new NotImplementedException();
		}
	}
}
