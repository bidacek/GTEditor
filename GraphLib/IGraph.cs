using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphLib
{
    public interface IGraph
    {
		IEnumerable<IVertex> Vertices { get; }
		int CountOfVertices { get; }
		bool Contains(IVertex vertex);
		IVertex CreateVertex();
		bool RemoveVertex(IVertex vertex);


		IEnumerable<IEdge> Edges { get; }
		int CountOfEdges { get; }
		bool Contains(IEdge e);
		bool Contains(IVertex firstVertex, IVertex secondVertex);

		IEdge CreateEdge(IVertex firstVertex, IVertex secondVertex);
		bool RemoveEdge(IEdge edge);
		bool RemoveEdge(IVertex firstVertex, IVertex secondVertex);

		IEnumerable<IEdge> GetIncidentEdges(IVertex vertex);
		int CountOfIncidentEdges(IVertex vertex);

		IEnumerable<IEdge> GetOutputEdges(IVertex vertex);
		int CountOfOutputEdges(IVertex vertex);

		IEnumerable<IEdge> GetInputEdges(IVertex vertex);
		int CountOfInputEdges(IVertex vertex);

	
    }


	public interface IEdge { }

	public interface IVertex { }

	public class Vertex : IVertex { }
}
