using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpExercises
{
    //To do:

    class Program
    {
        static void Main(string[] args)
        {
            var randomArea = new AreaMatrix(50, 50);

            var dijkstraTest = new Dijkstra();

            var fastestRoute = dijkstraTest.DijkstraAlgorithm(randomArea.AdjacencyMatrix, randomArea.WeightList, new Vector2(5,4), new Vector2(44,47));
            
            Console.WriteLine("J = Jungle\nO = Ocean\nR = Road\nF = Forest\nU = Unpassable Terrain\nM = Mountain\nD = Desert");

            dijkstraTest.PrintMatrixIncludingPath(randomArea.Graph, fastestRoute);

            Console.ReadKey();
        }
    }
}
