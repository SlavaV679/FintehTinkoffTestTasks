using System;
using System.Collections.Generic;
using static System.Math;

namespace Task10DivideFigure
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LinkedList<Vertex> vertices = new LinkedList<Vertex>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] coords = Console.ReadLine().Split(new char[] { ',' });
                if ((coords.Length != 2) || !double.TryParse(coords[0], out double X) || (!double.TryParse(coords[1], out double Y)))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Координата вершины заданы не верно");
                    continue;
                }
                vertices.AddLast(new Vertex(X, Y));
            }

            double sum = 0;
            Vertex endVertex = vertices.First.Value;
            vertices.AddLast(endVertex);

            LinkedListNode<Vertex> vertex = vertices.First;
            for (int i = 0; i < vertices.Count - 1; i++)
            {
                sum += 0.5 * Abs(vertex.Value.X + vertex.Next.Value.X) * (vertex.Value.Y - vertex.Next.Value.Y);
                vertex = vertex.Next;
            }
        }
    }

    public class Vertex
    {
        public double X { get; set; }
        public double Y { get; set; }
        public Vertex(double x, double y)
        {
            X = x;
            Y = y;
        }
    }
}
