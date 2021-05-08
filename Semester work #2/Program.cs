using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Запись_данных_в_файл_Семестровая_работа__2_
{
    class CreateGraph
    {
        private int CountOfVertex { get; set; }

        public CreateGraph(int vertex) { CountOfVertex = vertex; }

        public int[,] Create()
        {
            int[,] graph = new int[CountOfVertex, CountOfVertex];
            var random = new Random();
            for (int i = 0; i < CountOfVertex; i++)
            {
                int count = 0;
                while(count == 0)
                {
                    for (int j = i; j < CountOfVertex; j++)
                    {
                        if (random.Next(0, 2) == 1 && i != j) 
                        {
                            graph[i, j] = 1;
                            graph[j, i] = 1;
                            count++;
                        }
                    }
                    if (i == CountOfVertex - 1)
                    break;
                }
            }
            return graph;
        }
        public void WriteToDirectory(string path)
        {
            int[,] graph = Create();
            string text = graph[0, 0].ToString() + ",";
            for (int i = 0; i < CountOfVertex; i++)
            {
                for (int j = 0; j < CountOfVertex; j++)
                {
                    if ((i == 0) && (j == 0)) 
                    {
                        continue;
                    }
                    text += graph[i, j] + ",";
                }
                text += "\n";
            }
            File.WriteAllText(path, text);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            for(int i = 0; i < 50; i++)
            {
                string path = @"D:\Input\Test" + i  + ".txt";
                CreateGraph graph = new CreateGraph(new Random().Next(20,50));
                graph.WriteToDirectory(path);
            }
        }
    }
}
