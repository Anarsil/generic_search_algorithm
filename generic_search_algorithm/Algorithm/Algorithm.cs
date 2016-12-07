using generic_search_algorithm.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace generic_search_algorithm.Algorithm
{
    public abstract class Algorithm
    {
        protected GraphType graph;
        protected IHM ihm;

        public Algorithm(GraphType _graph, IHM _ihm)
        {
            graph = _graph;
            ihm = _ihm;
        }

        //Application du design pattern "Patron de méthode"
        public void Solve() //Solve() doit être "sealed"
        {
            graph.Clear();
            Run();
            //ihm.PrintResult(graph.ReconstructPath(), graph.ExitNode().DistanceFromBegin);
        }

        protected abstract void Run();
    }
}
