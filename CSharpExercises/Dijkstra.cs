using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpExercises
{
    public class Dijkstra
    {
        //searches for the shortest route from start to end. If the end is not reachable, just return.
        public HashSet<Tuple<Tile, Tile>> DijkstraAlgorithm(Dictionary<Tile, List<Tile>> adjacencyMatrix, Dictionary<Tile, double> weightList, Vector2 start, Vector2 end)
        {
            var visitedList = new List<Tile>();
            var unvisitedList = new List<Tile>();
            var prev = new Dictionary<Tile, Tile>();
            var distance = new Dictionary<Tile, double>();

            adjacencyMatrix.ToList().ForEach(x => distance.Add(x.Key, double.PositiveInfinity));
            
            distance.ToList().ForEach(x => unvisitedList.Add(x.Key));

            //make sure the startPoint and endPoint have the same reference as the values from the unvisitedList
            Tile startPoint = unvisitedList.Find(x => x.Vector2.x == start.x && x.Vector2.y == start.y);
            Tile endPoint = unvisitedList.Find(x => x.Vector2.x == end.x && x.Vector2.y == end.y);

            double prevStartWeight = weightList[startPoint];
            weightList[startPoint] = 0; //make sure the startPoint has 0 weight, else it returns an empty hashset when the startpoint is an unpassable tile
            distance[startPoint] = 0;

            while (!visitedList.Contains(endPoint) && unvisitedList.Count > 0)
            {
                unvisitedList = unvisitedList.OrderBy(x => distance[x]).ToList();
                Tile current = unvisitedList[0]; //shortest distance

                if (distance[current] != double.PositiveInfinity)
                {
                    foreach (Tile neighbour in adjacencyMatrix[current])
                    {
                        double tempWeight = distance[current] + weightList[neighbour]; //distance from start to current + weight
                        if (tempWeight < distance[neighbour]) //if current distance < previous lowest distance to neighbour
                        {
                            distance[neighbour] = tempWeight;
                            prev[neighbour] = current;
                        }
                    }
 
                    visitedList.Add(current);
                    unvisitedList.Remove(current);
                }

                else
                    return new HashSet<Tuple<Tile, Tile>>();
            }
            
            var shortestPath = new HashSet<Tuple<Tile, Tile>>();
            if (visitedList.Contains(endPoint))
            {
                while (endPoint != startPoint)
                {
                    shortestPath.Add(new Tuple<Tile, Tile>(endPoint, prev[endPoint]));
                    endPoint = prev[endPoint];
                }
            }

            weightList[startPoint] = prevStartWeight; //return the startweight to it's original value

            return shortestPath;
        }

        //print the map, including the shortest route with highlighting
        public void PrintMatrixIncludingPath(Tile[][] graph, HashSet<Tuple<Tile, Tile>> shortestPath)
        {
            for (int i = 0; i < graph.Length; i++)
            {
                for (int j = 0; j < graph[i].Length; j++)
                {
                    bool check = false;
                    foreach (var path in shortestPath)
                    {
                        if ((path.Item1.Vector2.x == graph[i][j].Vector2.x &&
                            path.Item1.Vector2.y == graph[i][j].Vector2.y) || path.Item2.Vector2.x == graph[i][j].Vector2.x &&
                            path.Item2.Vector2.y == graph[i][j].Vector2.y)
                        {
                            check = true;
                        }
                    }
                    if (check)
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.Write(graph[i][j].AreaType.AreaCodeForPrinting);
                        Console.ResetColor();
                    }
                    else
                        Console.Write(graph[i][j].AreaType.AreaCodeForPrinting);
                }
                Console.WriteLine("");
                ;
            }
        }
    }
}
