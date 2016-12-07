using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace generic_search_algorithm.Graph
{
    public abstract class Node
    {
        private Node precursor = null;
        internal Node Precursor {
            get
            {
                return this.precursor;
            }
            set
            {
                this.precursor = value;
            }
        }

        private double distanceFromBegin = double.PositiveInfinity;
        internal double DistanceFromBegin
        {
            get
            {
                return this.distanceFromBegin;
            }
            set
            {
                this.distanceFromBegin = value;
            }
        }

        internal double estimateDistance { get; set; }
    }
}
