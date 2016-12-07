using generic_search_algorithm.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace generic_search_algorithm.Environment
{
    internal class Patch : Node
    {
        protected PatchType patchType;

        internal int Row { get; set; }
        internal int Col { get; set; }

        public Patch(PatchType _type, int _row, int _col)
        {
            patchType = _type;
            Row = _row;
            Col = _col;
        }

        internal bool IsValidPath()
        {
            return patchType.Equals(PatchType.Bridge) ||
                patchType.Equals(PatchType.Grass) || patchType.Equals(PatchType.Path);
        }

        internal double Cost()
        {
            switch (patchType)
            {
                case PatchType.Path:
                    return 1;

                case PatchType.Bridge:
                case PatchType.Grass:
                    return 2;
                
                default:
                    return double.PositiveInfinity;
            }
        }

        public override string ToString()
        {
            return "[" + Row + ";" + Col + ";" + patchType.ToString() + "]";
        }
    }
}
