using generic_search_algorithm.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace generic_search_algorithm.Environment
{
    class Map : GraphType
    {
        Patch[,] patches;
        int nbRows;
        int nbCols;

        Patch beginNode;
        Patch exitNode;

        List<Node> nodesList = null;
        List<Edge> edgesList = null;

        public Map(String _map, int _beginRow, int _beginColumn, int _exitRow,
            int _exitColumn)
        {
            String[] mapRows = _map.Split(new char[] { '\n' });
            nbRows = mapRows.Length;
            nbCols = mapRows[0].Length;

            patches = new Patch[nbRows, nbCols];

            for (int row = 0; row < nbRows; row++)
            {
                for (int col = 0; col < nbCols; col++)
                {
                    patches[row, col] = new Patch(
                        PatchTypeConverter.PatchFromChar(mapRows[row][col]), 
                        row,
                        col
                        );
                }
            }

            //Entrée et sortie
            beginNode = patches[_beginRow, _beginColumn];
            beginNode.DistanceFromBegin = beginNode.Cost();
            exitNode = patches[_exitRow, _exitColumn];

            //Liste des noeux et des arcs
            NodesList();
            EdgesList();
        }

        public Node BeginingNode()
        {
            return beginNode;
        }

        public Node ExitNode()
        {
            return exitNode;
        }

        public List<Node> NodesList()
        {
            if (nodesList == null)
            {
                nodesList = new List<Node>();
                foreach (Node node in patches)
                {
                    nodesList.Add(node);
                }
            }
            return nodesList;
        }

        public List<Node> NodesList(Node _currentNode)
        {
            List<Node> nodesList = new List<Node>();

            int currentRow = ((Patch)_currentNode).Row;
            int currentCol = ((Patch)_currentNode).Col;

            //Renvoyer les voisins s'ils existent et sont accessibles
            if (currentRow - 1 >= 0 && patches[currentRow - 1, currentCol].IsValidPath())
            {
                nodesList.Add(patches[currentRow - 1, currentCol]);
            }
            if (currentRow + 1 < nbRows && patches[currentRow + 1, currentCol].IsValidPath())
            {
                nodesList.Add(patches[currentRow + 1, currentCol]);
            }
            if (currentCol - 1 >= 0 && patches[currentRow, currentCol - 1].IsValidPath())
            {
                nodesList.Add(patches[currentRow, currentCol - 1]);
            }
            if (currentCol + 1 < nbCols && patches[currentRow, currentCol + 1].IsValidPath())
            {
                nodesList.Add(patches[currentRow, currentCol + 1]);
            }

            return nodesList;
        }

        public int NodesCount()
        {
            return nbRows * nbCols;
        }

        public void Clear()
        {
            Console.WriteLine("Je nettoie");
            nodesList = null;
            edgesList = null;
            for (int row = 0; row < nbRows; row++)
            {
                for (int col = 0; col < nbCols; col++)
                {
                    patches[row, col].DistanceFromBegin = double.PositiveInfinity;
                    patches[row, col].Precursor = null;
                }
            }
            beginNode.DistanceFromBegin = beginNode.Cost();
            Console.WriteLine("J'ai nettoyé");

        }

        public void ComputeEstimatedDistanceToExit()
        {
            foreach (Patch patch in patches)
            {
                patch.estimateDistance = Math.Abs(exitNode.Row - patch.Row) +
                    Math.Abs(exitNode.Col - exitNode.Col);
            }
        }

        public double CostBetweenNodes(Node _fromNode, Node _toNode)
        {
            return ((Patch)_toNode).Cost();
        }

        public List<Edge> EdgesList()
        {
            if (edgesList == null)
            {
                edgesList = new List<Edge>();

                for (int row = 0; row < nbRows; row++)
                {
                    for (int col = 0; col < nbCols; col++)
                    {
                        if(patches[row, col].IsValidPath())
                        {
                            if(row -1 >= 0 && patches[row - 1, col].IsValidPath())
                            {
                                edgesList.Add(new Edge(
                                    patches[row, col],
                                    patches[row - 1, col],
                                    patches[row - 1, col].Cost()));
                            }
                            if (row + 1 < nbRows && patches[row + 1, col].IsValidPath())
                            {
                                edgesList.Add(new Edge(
                                    patches[row, col],
                                    patches[row + 1, col],
                                    patches[row + 1, col].Cost()));
                            }
                            if (col - 1 >= 0 && patches[row, col - 1].IsValidPath())
                            {
                                edgesList.Add(new Edge(
                                    patches[row, col],
                                    patches[row, col - 1],
                                    patches[row, col - 1].Cost()));
                            }
                            if (col + 1 < nbCols && patches[row, col + 1].IsValidPath())
                            {
                                edgesList.Add(new Edge(
                                    patches[row, col],
                                    patches[row, col + 1],
                                    patches[row, col + 1].Cost()));
                            }
                        }

                    }
                }
            }
            return edgesList;
        }

        public List<Edge> EdgesList(Node _currentNode)
        {
            List<Edge> edgesList = new List<Edge>();

            int currentRow = ((Patch)_currentNode).Row;
            int currentCol = ((Patch)_currentNode).Col;

            //Renvoyer les voisins s'ils existent et sont accessibles
            if (currentRow - 1 >= 0 && patches[currentRow - 1, currentCol].IsValidPath())
            {
                edgesList.Add(new Edge(_currentNode,
                    patches[currentRow - 1, currentCol],
                    patches[currentRow - 1, currentCol].Cost()));
            }
            if (currentRow + 1 < nbRows && patches[currentRow + 1, currentCol].IsValidPath())
            {
                edgesList.Add(new Edge(_currentNode,
                    patches[currentRow + 1, currentCol],
                    patches[currentRow + 1, currentCol].Cost()));
            }
            if (currentCol - 1 >= 0 && patches[currentRow, currentCol - 1].IsValidPath())
            {
                edgesList.Add(new Edge(_currentNode,
                    patches[currentRow, currentCol - 1],
                    patches[currentRow, currentCol - 1].Cost()));
            }
            if (currentCol + 1 < nbCols && patches[currentRow, currentCol + 1].IsValidPath())
            {
                edgesList.Add(new Edge(_currentNode,
                    patches[currentRow, currentCol + 1],
                    patches[currentRow, currentCol + 1].Cost()));
            }

            return edgesList;
        }

        public string ReconstructPath()
        {
            String resultPath = "";
            Patch currentNode = exitNode;
            Patch prevNode = (Patch)exitNode.Precursor;
            while (prevNode != null)
            {
                resultPath = "-" + currentNode.ToString() + resultPath;
                currentNode = prevNode;
                prevNode = (Patch)prevNode.Precursor;
            }
            resultPath = currentNode.ToString() + resultPath;
            return resultPath;
        }
    }
}
