using System;
using System.Collections.Generic;
using System.Text;

// topological Sort BFS <QUEUE>
// 1. 진입 차수가 0인 정점을 큐에 삽입합니다.
// 2. 큐에서 원소를 꺼내 연결된 모든 간선을 제거합니다
// 3. 간선 제거 이후에 진입차수가 0이 된 정점을 큐에 삽입합니다.
// 4. 큐가 빌 때까지 2번 ~ 3번 과정을 반복합니다. 모든 원소를 방문하기 전에 큐가 빈다면 사이클이 존재하는 것이고,
// 모든 원소를 방문했다면 큐에서 꺼낸 순서가 위상 정렬의 결과입니다.

// topological Sort DFS <STACK>
// 1. 임의의 방문하지 않은 한 정점을 잡고 DFS를 수행하면서 방문하는 정점들을 스택에 담는다.
// 2. 모든 정점의 방문될 때까지 1번을 반복한다.
// 3. 모든 정점을 방문했다면 스택에 담긴 정점들을 출력한다.

namespace BackjoonProject
{

    class TopologicalSort
    {
        int n = 7;
        List<int>[] insertEdge;
        int[] inDegree;

        public void Start()
        {
            InitializeData();

            TopologicalSortBFS();
            TopologicalSortDFS();
        }

        private void TopologicalSortBFS()
        {
            int[] result = new int[n];

            Queue<int> queue = new Queue<int>();

            for (int i = 1; i < n + 1; i++)
            {
                if (inDegree[i] == 0)
                    queue.Enqueue(i);
            }

            for (int i = 1; i < n + 1; i++)
            {
                if (queue.Count == 0)
                {
                    Console.WriteLine("It is not a Directed Acyclic Graph.");
                    return;
                }

                int x = queue.Dequeue();
                result[i - 1] = x;

                int count = insertEdge[x].Count;
                for (int j = 0; j < count; j++)
                {
                    int y = insertEdge[x][j];

                    if (--inDegree[y] == 0)
                        queue.Enqueue(y);
                }
            }

            for (int i = 0; i < n; i++)
            {
                Console.Write($"{result[i]} ");
            }
        }

        private void TopologicalSortDFS()
        {
            Stack<int> result = new Stack<int>();
            bool cycle = false;
            bool[] visit = new bool[n + 1];
            bool[] finish = new bool[n + 1];

            for (int i = 1; i < n + 1; i++)
            {
                if (cycle)
                {
                    Console.WriteLine("It is not a Directed Acyclic Graph.");
                    return;
                }

                if (!visit[i])
                {
                    Dfs(i);
                }
            }

            Console.WriteLine("");
            foreach (var i in result)
            {
                Console.Write($"{i} ");
            }

            void Dfs(int i)
            {
                visit[i] = true;
                int count = insertEdge[i].Count;
                for (int j = 0; j < count; j++)
                {
                    int y = insertEdge[i][j];

                    if (!visit[y])
                    {
                        Dfs(y);
                    }
                    else if (!finish[y])
                    {
                        cycle = true;
                        return;
                    }
                }

                finish[i] = true;
                result.Push(i);
            }
        }

        private void InitializeData()
        {
            insertEdge = new List<int>[n + 1];

            for (int i = 0; i < n + 1; i++)
                insertEdge[i] = new List<int>();

            inDegree = new int[n + 1];

            insertEdge[1].Add(2); inDegree[2]++;
            insertEdge[1].Add(5); inDegree[5]++;

            insertEdge[2].Add(3); inDegree[3]++;
            insertEdge[3].Add(4); inDegree[4]++;
            insertEdge[4].Add(6); inDegree[6]++;
            insertEdge[5].Add(6); inDegree[6]++;
            insertEdge[6].Add(7); inDegree[7]++;

            for (int i = 0; i < n + 1; i++)
            {
                foreach (var value in insertEdge[i])
                    Console.WriteLine($"{i} -> {value}");
            }

            Console.WriteLine($"---------------------------------");

            for (int i = 0; i < n + 1; i++)
                Console.WriteLine($"inDegree[{i}] = {inDegree[i]}");
        }

    }
}
