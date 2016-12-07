using generic_search_algorithm.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace generic_search_algorithm.Algorithm
{
    public class BreadthFirst : Algorithm
    {
        public BreadthFirst(GraphType _graph, IHM _ihm) : base (_graph, _ihm) { }
        protected override void Run()
        {
            List<Node> notVisitedNodes = graph.NodesList();
            Queue<Node> nodesToVisit = new Queue<Node>();

            nodesToVisit.Enqueue(graph.BeginingNode());
            notVisitedNodes.Remove(graph.BeginingNode());

            Node exitNode = graph.ExitNode();

            bool exitReached = false;

            while (nodesToVisit.Count != 0 && !exitReached)
            {
                Node currentNode = nodesToVisit.Dequeue();
                if (currentNode.Equals(exitNode))
                {
                    exitReached = true;
                }
                else
                {
                    foreach (Node node in graph.NodesList(currentNode))
                    {
                        if (notVisitedNodes.Contains(node))
                        {
                            notVisitedNodes.Remove(node);
                            node.Precursor = currentNode;
                            node.DistanceFromBegin = currentNode.DistanceFromBegin + graph.CostBetweenNodes(currentNode, node);
                            nodesToVisit.Enqueue(node);
                        }
                    }
                }
            }

        }
    }
}
