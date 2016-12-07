using generic_search_algorithm.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace generic_search_algorithm.Algorithm
{
    public class BellmanFord : Algorithm
    {
        public BellmanFord(GraphType _graph, IHM _ihm) : base (_graph, _ihm) {}

        protected override void Run()
        {
            bool distanceChanged = true;
            int i = 0;
            List<Edge> edges = graph.EdgesList();

            int nbLoopMax = graph.NodesCount() - 1;
            while (i < nbLoopMax && distanceChanged)
            {
                distanceChanged = false;
                foreach (Edge edge in edges)
                {
                    if (edge.FromNode.DistanceFromBegin +
                        edge.Cost < edge.ToNode.DistanceFromBegin)
                    {
                        edge.ToNode.DistanceFromBegin =
                            edge.FromNode.DistanceFromBegin + edge.Cost;
                        edge.ToNode.Precursor = edge.FromNode;
                        distanceChanged = true;
                    }
                }
                i++;
            }

            //test si boucle négative
            foreach (Edge edge in edges)
            {
                if (edge.FromNode.DistanceFromBegin + edge.Cost < edge.ToNode.DistanceFromBegin)
                {
                    throw new Exception();
                }
            }
        }
    }
}
