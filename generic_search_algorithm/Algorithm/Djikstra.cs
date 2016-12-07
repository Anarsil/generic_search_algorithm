using generic_search_algorithm.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace generic_search_algorithm.Algorithm
{
    class Djikstra : Algorithm
    {
        public Djikstra(GraphType _graph, IHM _ihm) : base (_graph, _ihm) {}
        protected override void Run()
        {
            List<Node> nodesToVisit = graph.NodesList();
            bool exitReached = false;

            while (nodesToVisit.Count != 0 && !exitReached)
            {
                Node currentNode = nodesToVisit.FirstOrDefault();
                foreach (Node newNode in nodesToVisit)
                {
                    if (newNode.DistanceFromBegin < currentNode.DistanceFromBegin)
                    {
                        currentNode = newNode;
                    }
                }

                if (currentNode == graph.ExitNode())
                {
                    exitReached = true;
                }
                else
                {
                    List<Edge> edgesFromCurrentNode = graph.EdgesList(currentNode);
                    foreach (Edge edge in edgesFromCurrentNode)
                    {
                        if(edge.FromNode.DistanceFromBegin +
                            edge.Cost < edge.ToNode.DistanceFromBegin)
                        {
                            edge.ToNode.DistanceFromBegin = 
                                edge.FromNode.DistanceFromBegin + edge.Cost;
                            edge.ToNode.Precursor = edge.FromNode;
                        }
                    }
                    nodesToVisit.Remove(currentNode);
                }
            }

        }
    }
}
