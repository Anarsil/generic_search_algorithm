using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace generic_search_algorithm.Environment
{
    public enum PatchType { Grass, Tree, Water, Bridge, Path };
    internal static class PatchTypeConverter
    {
        public static PatchType PatchFromChar (Char _c)
        {
            switch (_c)
            {
                case ' ':
                    return PatchType.Grass;

                case '*':
                    return PatchType.Tree;

                case 'X':
                    return PatchType.Water;

                case '=':
                    return PatchType.Bridge;

                case '.':
                    return PatchType.Path;
            }
            throw new FormatException();
        }
    }
}
