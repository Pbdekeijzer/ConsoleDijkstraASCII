using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpExercises
{
    //contains the paths, the adjacency matrix and the graph
    public class AreaMatrix
    {
        public AreaMatrix(int xLen, int yLen)
        {
            xLength = xLen;
            yLength = yLen;
            Graph = CreateNewGraph(xLen, yLen);
            WeightList = new Dictionary<Tile, double>();
            Paths = CreatePathList();
            AdjacencyMatrix = CreateAdjacencyMatrix(Paths);
        }

        private int xLength { get; }
        private int yLength { get; }

        public Tile[][] Graph { get; set; }
        public Tile[][] CreateNewGraph(int xLen, int yLen)
        {
            var tempMatrix = new Tile[yLen][];
            for (int i = 0; i < tempMatrix.Length; i++)
            {
                tempMatrix[i] = new Tile[xLen];
                for (int j = 0; j < tempMatrix[i].Length; j++)
                {
                    tempMatrix[i][j] = new Tile(new Vector2(i, j));
                }
            }
            return tempMatrix;
        }

        public Dictionary<Tile, List<Tile>> AdjacencyMatrix { get; set; }
        public Dictionary<Tile, List<Tile>> CreateAdjacencyMatrix(List<Tuple<Tile, Tile>> paths)
        {
            var adjacencyList = new Dictionary<Tile, List<Tile>>();

            foreach (var path in paths)
            {
                if (!adjacencyList.ContainsKey(path.Item1))
                {
                    adjacencyList.Add(path.Item1, new List<Tile>());
                    AddToWeightList(path.Item1, path.Item1.AreaType.AreaWeight);
                }

                adjacencyList[path.Item1].Add(path.Item2);
            }
            return adjacencyList;
        }

        public Dictionary<Tile, double> WeightList { get; set; }
        public void AddToWeightList(Tile tile, double weight)
        {
            WeightList.Add(tile, weight);
        }

        private List<Tuple<Tile, Tile>> Paths { get; set; }
        private List<Tuple<Tile, Tile>> CreatePathList()
        {
            var pathList = new List<Tuple<Tile, Tile>>();

            for (int i = 0; i < yLength; i++)
            {
                for (int j = 0; j < xLength; j++)
                {
                    //the weight of a road is half of the starting point + half of the next point. two roads ()(), weight of road is )(

                    if (Graph[i][j].Vector2.x < xLength - 1)
                        pathList.Add(new Tuple<Tile, Tile>(Graph[i][j], Graph[i][j + 1]));
                    if (Graph[i][j].Vector2.x > 0)
                        pathList.Add(new Tuple<Tile, Tile>(Graph[i][j], Graph[i][j - 1]));
                    if (Graph[i][j].Vector2.y < yLength - 1)
                        pathList.Add(new Tuple<Tile, Tile>(Graph[i][j], Graph[i + 1][j]));
                    if (Graph[i][j].Vector2.y > 0)
                        pathList.Add(new Tuple<Tile, Tile>(Graph[i][j], Graph[i - 1][j]));
                }
            }

            return pathList;
        }

        private string FillPrintableMatrix()
        {
            string map = "";
            for (int i = 0; i < Graph.Length; i++)
            {
                for (int j = 0; j < Graph[i].Length; j++)
                    map += Graph[i][j].AreaType.AreaCodeForPrinting;
                map += "\n";
            }
            return map;
        }
        public void PrintMatrix()
        {
            Console.WriteLine(FillPrintableMatrix());
        }
    }
}
