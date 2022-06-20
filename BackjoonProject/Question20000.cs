using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BackjoonProject
{
    class Question20000
    {
        static int cnt = 0;
        static int[] visited;
        static int[] result;
        static List<int>[] list;

        public void Q24479()
        {
            StreamWriter writer = new StreamWriter(Console.OpenStandardOutput());
            StreamReader reader = new StreamReader(Console.OpenStandardInput());

            int[] data = Array.ConvertAll(reader.ReadLine().Split(), int.Parse);
            int n = data[0];
            int m = data[1];
            int r = data[2];

            list = new List<int>[n + 1];
            visited = new int[n + 1];
            result = new int[n + 1];

            for (int i = 1; i < n + 1; i++)
                list[i] = new List<int>();

            for (int i = 0; i < m; i++)
            {
                int[] line = Array.ConvertAll(reader.ReadLine().Split(), int.Parse);
                list[line[0]].Add(line[1]);
                list[line[1]].Add(line[0]);
            }

            for (int i = 1; i < n + 1; i++)
                list[i].Sort();

            DFS(r);

            for (int i = 1; i <= n; i++)
                writer.WriteLine(result[i]);

            writer.Close();
            reader.Close();

            void DFS(int r)
            {
                if (visited[r] == 1)
                    return;

                visited[r] = 1;
                cnt++;
                result[r] = cnt;

                for (int i = 0; i < list[r].Count; i++)
                    DFS(list[r][i]);
            }
        }
    }
}
