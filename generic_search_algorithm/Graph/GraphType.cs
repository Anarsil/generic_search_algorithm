using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace generic_search_algorithm.Graph
{
    public interface GraphType
    {
        Node BeginingNode();
        Node ExitNode();

        //Retourne la liste complète des nodes
        List<Node> NodesList();

        //Retourne la liste des nodes adjacents
        List<Node> NodesList(Node _currentNode);

        //Retourne la liste complète des arcs
        List<Edge> EdgesList();

        //Retourne la liste des arcs sortants
        List<Edge> EdgesList(Node _currentNode);

        int NodesCount();

        double CostBetweenNodes(Node _fromNode, Node _toNode);

        //Reconstruit le chemin à partir des prédecesseurs
        string ReconstructPath();

        //Calcule la distance estimée à la sortie
        void ComputeEstimatedDistanceToExit();

        //Remet le graph dans son état initial
        void Clear();
    }
}
