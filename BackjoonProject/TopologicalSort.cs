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

/*DFS와 BFS의 시간복잡도
두 방식 모두 조건 내의 모든 노드를 검색한다는 점에서 시간 복잡도는 동일합니다.
DFS와 BFS 둘 다 다음 노드가 방문하였는지를 확인하는 시간과 각 노드를 방문하는 시간을 합하면 됩니다.

깊이 우선 탐색(DFS)과 너비 우선 탐색(BFS) 활용한 문제 유형/응용

DFS, BFS은 특징에 따라 사용에 더 적합한 문제 유형들이 있습니다.

그래프의 모든 정점을 방문하는 것이 주요한 문제
단순히 모든 정점을 방문하는 것이 중요한 문제의 경우 DFS, BFS 두 가지 방법 중 어느 것을 사용하셔도 상관없습니다.
둘 중 편한 것을 사용하시면 됩니다.
경로의 특징을 저장해둬야 하는 문제
예를 들면 각 정점에 숫자가 적혀있고 a부터 b까지 가는 경로를 구하는데 경로에 같은 숫자가 있으면 안 된다는 문제 등, 
각각의 경로마다 특징을 저장해둬야 할 때는 DFS를 사용합니다. (BFS는 경로의 특징을 가지지 못합니다)
최단거리 구해야 하는 문제
미로 찾기 등 최단거리를 구해야 할 경우, BFS가 유리합니다.
왜냐하면 깊이 우선 탐색으로 경로를 검색할 경우 처음으로 발견되는 해답이 최단거리가 아닐 수 있지만,
너비 우선 탐색으로 현재 노드에서 가까운 곳부터 찾기 때문에경로를 탐색 시 먼저 찾아지는 해답이 곧 최단거리기 때문입니다.
이밖에도

검색 대상 그래프가 정말 크다면 DFS를 고려
검색대상의 규모가 크지 않고, 검색 시작 지점으로부터 원하는 대상이 별로 멀지 않다면 BFS*/

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
