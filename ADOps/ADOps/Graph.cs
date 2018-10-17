using System;
using System.Collections.Generic;

namespace ADOps
{
    namespace MyGraph
    {
        public interface IVertex
        {
            void Reset();
            string ToString();
        }

        public interface IGraph
        {
            void AddEdge(string source, string dest, double cost);
            Vertex GetVertex(string name);
            string ToString();
        }

        public class Graph : IGraph
        {
            internal const double INF = double.MaxValue;

            private Dictionary<string, Vertex> vertices = new Dictionary<string, Vertex>();

            public void AddEdge(string source, string dest, double cost)
            {
                Vertex v = GetVertex(source);
                Vertex d = GetVertex(dest);
                v.edges.Add(new Edge(d, cost));

            }

            public Vertex GetVertex(string name)
            {
                try
                {
                    return vertices[name];
                }
                catch (KeyNotFoundException)
                {
                    Vertex v = new Vertex(name);
                    vertices.Add(name, v);
                    return v;
                }
            }

            private void ClearAll()
            {
                foreach (var v in vertices.Values)
                    v.Reset();
            }

            public void Unweighted(string startName)
            {
                ClearAll();

                Vertex start = vertices[startName];

                Queue<Vertex> q = new Queue<Vertex>();
                start.dist = 0;
                q.Enqueue(start);

                while (q.Count > 0)
                {
                    Vertex v = q.Dequeue();
                    foreach (var e in v.edges)
                    {
                        Vertex w = e.dest;
                        if (w.dist == INF)
                        {
                            w.dist = v.dist + 1;
                            w.prev = v;
                            q.Enqueue(w);
                        }
                    }
                }
            }

            public void PrintPath(string destName)
            {
                Vertex w = vertices[destName];
                if (w.dist == INF)
                {
                    Console.WriteLine($"{w.name} is (as of yet) unreachable");
                    return;
                }
                Console.Write($"Cost is: {w.dist}\n\t");
                PrintPath(w);
                Console.WriteLine();
            }

            private void PrintPath(Vertex w)
            {
                if (w.prev != null)
                {
                    PrintPath(w.prev);
                    Console.Write(" --> ");
                }
                Console.Write(w.name);
            }

            public override string ToString()
            {
                string str = "";
                foreach (var v in vertices.Values)
                    str += v.ToString() + '\n';
                return str;
            }
        }

        public class Vertex : IVertex
        {
            public string name;
            public List<Edge> edges;
            public double dist;
            public Vertex prev;
            public int scratch;

            public Vertex(string name)
            {
                this.name = name;
                edges = new List<Edge>();
                Reset();
            }

            public void Reset()
            {
                dist = Graph.INF;
                prev = null;
                scratch = 0;
            }

            public override string ToString()
            {
                string str;
                if (dist < Graph.INF)
                    str = $"{name}({dist}) -->";
                str = $"{name} -->";

                foreach (var edge in edges)
                    str += $" {edge.dest.name}({edge.cost})";

                return str;
            }
        }

        public class Edge
        {
            public Vertex dest;
            public double cost;

            public Edge(Vertex dest, double cost)
            {
                this.dest = dest;
                this.cost = cost;
            }
        }
    }
}