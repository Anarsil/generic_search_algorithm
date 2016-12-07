using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace generic_search_algorithm.Graph
{
    public class Edge
    {
        internal Node FromNode { get; set; }
        internal Node ToNode { get; set; }
        internal double Cost { get; set; }

        internal Edge (Node from, Node to, double cost)
        {
            this.FromNode = from;
            this.ToNode = to;
            this.Cost = cost;
        }

    }
}
