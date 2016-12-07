using generic_search_algorithm.Graph;
using generic_search_algorithm.Algorithm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using generic_search_algorithm.Environment;

namespace generic_search_algorithm
{
    class Program : IHM
    {
        static void Main(string[] args)
        {
            Program main = new Program();
            main.Run();
            while (true) ;
        }

        private void Run()
        {
            while (true)
            {
                Console.WriteLine("Souhaitez-vous lancer tous les algorithmes ? Y/N");
                string response = Console.ReadLine();

                //"D:/Projet perso/generic_search_algorithm/maps/map2.txt"
                Console.WriteLine("MAP 1 \n ******************************************************");
                Map map = CreateMapFromTxt("D:/Projet perso/generic_search_algorithm/maps/map1.txt");
                RunAll(map);

                Console.WriteLine("MAP 2 \n ******************************************************");
                map = CreateMapFromTxt("D:/Projet perso/generic_search_algorithm/maps/map2.txt");
                RunAll(map);
            }
            
        }

        public void PrintResult(string _path, double _distance)
        {
            Console.Out.WriteLine("Chemin (taille : " + _distance + ") : " + _path);
        }

        private void RunAlgorithm(string _algoName, GraphType _graph)
        {
            DateTime begining;
            DateTime end;
            TimeSpan duration;
            Algorithm.Algorithm algo = null;

            switch (_algoName)
            {
                case "Depth-First":
                    algo = new DephtFirst(_graph, this);
                    break;
                case "Breadth-First":
                    algo = new BreadthFirst(_graph, this);
                    break;
                case "Bellman-Ford":
                    algo = new BellmanFord(_graph, this);
                    break;
                case "Djikstra":
                    algo = new Djikstra(_graph, this);
                    break;
                case "A*":
                    algo = new AStar(_graph, this);
                    break;
                default:
                    break;
            }

            Console.Out.WriteLine("Algorithme : " + _algoName);
            begining = DateTime.Now;
            algo.Solve();
            end = DateTime.Now;
            duration = end - begining;
            Console.WriteLine("Durée (ms) : " + duration.TotalMilliseconds.ToString() + "\n");
        }

        private void RunAll (GraphType _graph)
        {
            RunAlgorithm("Depth-First", _graph);
            RunAlgorithm("Breadth-First", _graph);
            RunAlgorithm("Bellman-Ford", _graph);
            RunAlgorithm("Djikstra", _graph);
            RunAlgorithm("A*", _graph);
        }

        private Map CreateMap()
        {
            string mapSTR = "...*     X .*    *  \n"
                   + " *..*   *X .........\n"
                   + "   .     =   *.*  *.\n"
                   + "  *.   * XXXX .    .\n"
                   + "XXX=XX   X *XX=XXX*.\n"
                   + "  *.*X   =  X*.  X  \n"
                   + "   . X * X  X . *X* \n"
                   + "*  .*XX=XX *X . XXXX\n"
                   + " ....  .... X . X   \n"
                   + " . *....* . X*. = * ";
            Map map = new Map(mapSTR, 0, 0, 9, 19);
            return map;
        }

        private Map CreateMapFromTxt(string _path)
        {
            string line;
            string[] dimSTR;
            List<int> dimensions = new List<int>();

            System.IO.StreamReader file = new System.IO.StreamReader(@_path);

            line = file.ReadLine();
            dimSTR = line.Split(';');
            foreach (string dim in dimSTR)
            {
                dimensions.Add(Int32.Parse(dim));
            }

            string mapSTR = "";
            while ((line = file.ReadLine()) != null)
            {
                mapSTR = mapSTR + line + "\n";
            }
            mapSTR = mapSTR.TrimEnd();
            Map myMap = new Map(mapSTR, dimensions[0], dimensions[1], dimensions[2], dimensions[3]);
            return myMap;
        }
    }
}
