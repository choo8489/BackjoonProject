using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;

using static System.Console;
using static BackjoonProject.Tools;

namespace BackjoonProject
{
    class Question1000
    {
        public void Q1000()
        {
            https://www.acmicpc.net/problem/1000
            string[] data = Console.ReadLine().Split();
            int length = data.Length;
            int sum = 0;
            for (int i = 0; i < length; i++)
            {
                sum += int.Parse(data[i]);
            }

            Console.WriteLine(sum);
        }

        public void Q1001()
        {
            https://www.acmicpc.net/problem/1001
            string[] data = Console.ReadLine().Split();
            Console.WriteLine(int.Parse(data[0]) - int.Parse(data[1]));
        }

        public void Q1002()
        {
            https://www.acmicpc.net/problem/1002
            // https://mathbang.net/101 참고자료

            int a = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < a; i++)
            {
                string[] inputs = Console.ReadLine().Split();

                int x1 = int.Parse(inputs[0]);
                int y1 = int.Parse(inputs[1]);
                int r1 = int.Parse(inputs[2]);
                int x2 = int.Parse(inputs[3]);
                int y2 = int.Parse(inputs[4]);
                int r2 = int.Parse(inputs[5]);

                if (x1 == x2 && y1 == y2 && r1 == r2)
                {
                    // 모든 값이 같을 때 무한대
                    Console.WriteLine(-1);
                    continue;
                }

                double distance = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
                int distanceSum = r1 + r2;
                int distanceSub = Math.Abs(r1 - r2);

                if (distanceSub < distance && distance < distanceSum)
                {
                    Console.WriteLine(2);
                }
                else if (distanceSub == distance || distanceSum == distance)
                {
                    Console.WriteLine(1);
                }
                else
                {
                    Console.WriteLine(0);
                }
            }
        }

        // 피보나치 메모이제이션
        public void Q1003()
        {
            https://www.acmicpc.net/problem/1003
            int[,] fibo = new int[41, 2];

            int a = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < a; i++)
            {
                int n = int.Parse(Console.ReadLine());
                Fibonacci(n);
                Console.WriteLine($"{fibo[n, 0]} {fibo[n, 1]}");
            }

            (int, int) Fibonacci(int n)
            {
                if (n == 0)
                {
                    fibo[n, 0] = 1;
                    fibo[n, 1] = 0;
                    return (fibo[n, 0], fibo[n, 1]);
                }
                else if (n == 1)
                {
                    fibo[n, 0] = 0;
                    fibo[n, 1] = 1;
                    return (fibo[n, 0], fibo[n, 1]);
                }

                if (fibo[n, 0] != 0 && fibo[n, 1] != 0)
                {
                    return (fibo[n, 0], fibo[n, 1]);
                }
                else
                {
                    fibo[n, 0] = Fibonacci(n - 1).Item1 + Fibonacci(n - 2).Item1;
                    fibo[n, 1] = Fibonacci(n - 1).Item2 + Fibonacci(n - 2).Item2;
                    return (fibo[n, 0], fibo[n, 1]);
                }
            }
        }

        public void Q1004 ()
        {
            https://www.acmicpc.net/problem/1004
            int length = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < length; i++)
            {
                int count = 0;
                string[] n = Console.ReadLine().Split();

                (int x1, int y1) = (int.Parse(n[0]), int.Parse(n[1]));
                (int x2, int y2) = (int.Parse(n[2]), int.Parse(n[3]));

                int planetCount = Convert.ToInt32(Console.ReadLine());

                for (int j = 0; j < planetCount; j++)
                {
                    string[] planetInfo = Console.ReadLine().Split();

                    (int cx, int cy, int r) = (int.Parse(planetInfo[0]), int.Parse(planetInfo[1]), int.Parse(planetInfo[2]));

                    double distance1 = Math.Pow(x1 - cx, 2) + Math.Pow(y1 - cy, 2);
                    double distance2 = Math.Pow(x2 - cx, 2) + Math.Pow(y2 - cy, 2);

                    double powR = r * r;

                    // 만약 두 거리가 모두 행성의 반지름 보다 작다면, 출발점과 시작점 모두 행성 내부에 있기 때문에 진입 x
                    // 두 지점 중 하나만 행성 내부에 있는 경우에는 진입 또는 이탈 필요
                    if (powR > distance1 && powR > distance2)
                        continue;
                    else if (powR > distance1)
                        count++;
                    else if (powR > distance2)
                        count++;
                }

                Console.WriteLine(count);
            }
        }

        public void Q1005() 
        {
            https://www.acmicpc.net/problem/1005
            int[] inDegree;
            int length = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < length; i++)
            {
                string[] str = Console.ReadLine().Split();

                // 건물 갯수 N, 건설 순서 규칙 총 개수 K
                (int n, int k) = (int.Parse(str[0]), int.Parse(str[1]));

                int[] nTime = new int[n + 1];
                int[] resultTime = new int[n + 1];
                string[] str2 = Console.ReadLine().Split();
                for (int j = 0; j < n; j++)
                {
                    nTime[j + 1] = int.Parse(str2[j]); // 걸리는 시간
                    resultTime[j + 1] = int.Parse(str2[j]); // 가중치 줄 시간
                }

                List<int>[] insertEdge = new List<int>[n + 1];

                for (int j = 0; j < n + 1; j++)
                    insertEdge[j] = new List<int>();

                inDegree = new int[n + 1];
                for (int j = 0; j < k; j++)
                {
                    string[] str3 = Console.ReadLine().Split();
                    insertEdge[int.Parse(str3[0])].Add(int.Parse(str3[1])); // 건설 순서
                    inDegree[int.Parse(str3[1])]++; // 진입 갯수
                }

                int w = int.Parse(Console.ReadLine());

                Queue<int> queue = new Queue<int>();

                for (int j = 1; j < n + 1; j++)
                {
                    if (j == w)
                        continue;
                    else if (inDegree[j] == 0)
                        queue.Enqueue(j);
                }

                while (!(queue.Count == 0))
                {
                    int idx = queue.Dequeue();

                    for (int j = 0; j < insertEdge[idx].Count; j++)
                    {
                        int value = insertEdge[idx][j];

                        resultTime[value] = (int)MathF.Max(resultTime[value], resultTime[idx] + nTime[value]); // 가는 방향에 가중치

                        if (--inDegree[value] == 0)
                            queue.Enqueue(value);
                    }
                }

                Console.WriteLine($"{resultTime[w]}");
            }
        }

        public void Q1008()
        {
            int[] A = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

            Console.WriteLine((double)A[0] / A[1]);
        }

        public void Q1009()
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int[] data = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
                int result = 1;
                for (int j = 0; j < data[1]; j++)
                    result = (result * data[0]) % 10;

                if (result == 0)
                    result = 10;

                Console.WriteLine($"{result}");
            }
        }

        public void Q1010()
        {
            int t = int.Parse(Console.ReadLine());

            for (int i = 0; i < t; i++)
            {
                int[] data = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
                int n = data[0];
                int m = data[1];

                // mCn
                int a = n > (m - n) ? n : (m - n);
                long result = 1;

                for (int j = a + 1; j <= m; j++)
                    result *= j;

                for (int j = 1; j <= (m - a); j++)
                    result /= j;

                Console.WriteLine(result);
            }
        }

        public void Q1012()
        {
            int t = int.Parse(Console.ReadLine());
            for (int i = 0; i < t; i++)
            {
                int[] data = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
                int x = data[0];
                int y = data[1];
                int count = data[2];

                int[,] arry = new int[x, y];
                int[,] visited = new int[x, y];

                for (int j = 0; j < count; j++)
                {
                    string[] str = Console.ReadLine().Split(' ');
                    arry[int.Parse(str[0]), int.Parse(str[1])] = 1;
                }

                Console.WriteLine(BFS(x, y, arry, visited));
            }

            int BFS(int x, int y, int[,] arry, int[,] visited)
            {
                Queue<(int, int)> queue = new Queue<(int, int)>();
                int[] dx = new int[] { 1, 0, -1, 0 };
                int[] dy = new int[] { 0, 1, 0, -1 };

                int result = 0;
                for (int i = 0; i < x; i++)
                {
                    for (int j = 0; j < y; j++)
                    {
                        if (visited[i, j] == 1 || arry[i, j] == 0)
                            continue;

                        queue.Enqueue((i, j));
                        result++;
                        while (queue.Count != 0)
                        {
                            var cur = queue.Dequeue();
                            int curx = cur.Item1;
                            int cury = cur.Item2;

                            for (int dir = 0; dir < 4; dir++)
                            {
                                int nx = cur.Item1 + dx[dir];
                                int ny = cur.Item2 + dy[dir];
                                if (nx < 0 || nx >= x || ny < 0 || ny >= y)
                                    continue;
                                if (visited[nx, ny] == 1 || arry[nx, ny] != 1)
                                    continue;

                                visited[nx, ny] = 1;
                                queue.Enqueue((nx, ny));
                            }
                        }
                    }
                }

                return result;
            }
        }

        public void Q1015()
        {
            StreamWriter writer = new StreamWriter(Console.OpenStandardOutput());
            StreamReader reader = new StreamReader(Console.OpenStandardInput());

            int N = int.Parse(reader.ReadLine());
            string[] input = reader.ReadLine().Split();

            int[] a = new int[N]; // 입력받은 A의 원소
            (int, int)[] p = new (int, int)[N]; // 인덱스와 A의 원소를 저장하기 위한 튜플 배열

            for (int i = 0; i < N; i++)
            {
                // 데이터 파싱
                a[i] = int.Parse(input[i]);
                p[i] = (i, a[i]);
            }

            var sortList = p.OrderBy(o => o.Item2).ToArray(); // A의 원소로 오름차순 정렬
            int[] result = new int[N + 1];

            for (int i = 0; i < N; i++)
                result[sortList[i].Item1] = i; // 오름차순한 배열의 index로 비내림차순 수열 정렬

            for (int i = 0; i < N; i++)
                writer.Write($"{result[i]} ");

            writer.WriteLine();

            writer.Close();
            reader.Close();
        }

        public void Q1018()
        {
            StreamWriter writer = new StreamWriter(Console.OpenStandardOutput());
            StreamReader reader = new StreamReader(Console.OpenStandardInput());

            string[] value = reader.ReadLine().Split();
            int N = int.Parse(value[0]);
            int M = int.Parse(value[1]);

            char[,] panel = new char[M, N];

            for (int i = 0; i < N; i++)
            {
                string line = reader.ReadLine();

                for (int j = 0; j < M; j++)
                    panel[j, i] = line[j];
            }

            float cnt = 8 * 8;

            for (int i = 0; i <= N - 8; i++)
            {
                for (int j = 0; j <= M - 8; j++)
                {
                    float num = 0;
                    for (int a = i; a < i + 8; a++)
                    {
                        for (int b = j; b < j + 8; b++)
                        {
                            var c = (a + b) % 2 == 0 ? 'W' : 'B';
                            if (c != panel[b, a])
                                num++;
                        }
                    }
                    num = MathF.Min(num, 64 - num);
                    cnt = MathF.Min(cnt, num);
                }
            }

            writer.WriteLine(cnt);

            writer.Close();
            reader.Close();
        }

        public void Q1021()
        {
            StreamWriter writer = new StreamWriter(Console.OpenStandardOutput());
            StreamReader reader = new StreamReader(Console.OpenStandardInput());

            string[] input = reader.ReadLine().Split();
            string[] input2 = reader.ReadLine().Split();
            int N = int.Parse(input[0]);
            int M = int.Parse(input[1]);

            List<int> m = new List<int>();
            for (int i = 0; i < input2.Length; i++)
                m.Add(int.Parse(input2[i]));

            List<int> dequeue = new List<int>();

            for (int i = 1; i <= N; i++)
                dequeue.Add(i);

            int count = 0;

            for (int i = 0; i < M; i++)
            {
                int index = dequeue.FindIndex(o => o == m[0]); // 찾고자 하는 수의 인덱스
                if (index <= dequeue.Count / 2) // 총 카운트/2 보다 작으면 2번 실행 크면 3번실행
                {
                    for (int j = 0; j < index; j++) // 2번
                    {
                        int temp = dequeue[0];
                        dequeue.RemoveAt(0); // 왼쪽을 제거
                        dequeue.Add(temp); // 맨 오른쪽으로 이동
                        count++; // 카운트 갱신
                    }
                    dequeue.RemoveAt(0); // 해당 값을 찾아서 제거
                    m.RemoveAt(0); // 찾을 값을 제거
                }
                else
                {
                    for (int j = 0; j < dequeue.Count - index; j++) // 3번
                    {
                        int temp = dequeue[^1];
                        dequeue.RemoveAt(dequeue.Count - 1); // 맨 끝 오른쪽 값을 제거
                        dequeue.Insert(0, temp); // 맨 처음에 값을 삽입
                        count++; // 카운트 갱신
                    }
                    dequeue.RemoveAt(0);
                    m.RemoveAt(0);
                }
            }

            writer.WriteLine(count);

            writer.Close();
            reader.Close();
        }

        public void Q1024()
        {
            StreamWriter writer = new StreamWriter(OpenStandardOutput());
            StreamReader reader = new StreamReader(OpenStandardInput());

            string[] input = reader.ReadLine().Split();
            int N = int.Parse(input[0]);
            int L = int.Parse(input[1]);

            // N = (x+1) + (x+2) + ... + (x+L)
            // N = Lx + L(L+1) / 2
            // Lx = N - L(L+1) / 2
            // Lx / L = (N - L(L+1) / 2) / L
            // x = (N - L(L+1) / 2) / L   => x가 정수가 됩니다.

            int index = L;
            int x;
            while (true)
            {
                x = N - (index * (index + 1) / 2);

                if (x % index == 0)
                {
                    x /= index;

                    // 음이 아닌 정수 리스트이므로
                    // x+1 >= 0  -> x >= -1 이어야 됩니다.
                    if (x >= -1)
                    {
                        for (int i = 1; i < index + 1; i++)
                        {
                            writer.Write($"{i + x} ");
                        }
                        writer.Write("\n");
                        break;
                    }
                }

                if (index == 100) // 리스트의 길이는 100보다 작거나 같기 때문에 넘으면 종료
                {
                    writer.WriteLine(-1);
                    break;
                }

                index++;
            }

            writer.Close();
            reader.Close();
        }

        public void Q1026()
        {
            int n = Convert.ToInt32(Console.ReadLine());

            int[] a = new int[n];
            int[] b = new int[n];

            string[] strA = Console.ReadLine().Split();
            string[] strB = Console.ReadLine().Split();

            for (int i = 0; i < n; i++)
            {
                a[i] = int.Parse(strA[i]);
                b[i] = int.Parse(strB[i]);
            }

            Array.Sort(a);
            Array.Sort(b, (a, b) => (a > b) ? -1 : 1);

            int sum = 0;

            for (int i = 0; i < n; i++)
                sum += (a[i] * b[i]);

            Console.WriteLine(sum);
        }

        public void Q1032()
        {
            StringBuilder builder = new StringBuilder();
            int n = int.Parse(Console.ReadLine());
            string[] name = new string[n];

            string s = string.Empty;

            for (int i = 0; i < n; i++)
                name[i] = Console.ReadLine();

            int length = name[0].Length;
            for (int i = 0; i < length; i++)
            {
                s = string.Empty;
                for (int j = 1; j < n; j++)
                {
                    if (name[0][i] != name[j][i])
                    {
                        s = "?";
                        break;
                    }
                }

                if (s == string.Empty)
                    s = name[0][i].ToString();

                builder.Append(s);
            }

            Console.WriteLine(builder);
        }

        public void Q1037()
        {
            int n = int.Parse(Console.ReadLine());
            int[] number = new int[n];

            number = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

            Console.WriteLine(number.Min() * number.Max());
        }

        public void Q1049()
        {
            StreamWriter writer = new StreamWriter(OpenStandardOutput());
            StreamReader reader = new StreamReader(OpenStandardInput());

            string[] input = reader.ReadLine().Split();
            int N = int.Parse(input[0]); // 끊어진 기타줄의 개수
            int M = int.Parse(input[1]); // 기타줄 브랜드 개수

            int[] package = new int[M];
            int[] piece = new int[M];

            for (int i = 0; i < M; i++)
            {
                // [0] : 6개가 들어있는 패키지의 가격
                // [1] : 낱개로 살 때의 가격
                string[] input2 = reader.ReadLine().Split();
                package[i] = int.Parse(input2[0]);
                piece[i] = int.Parse(input2[1]);
            }

            Array.Sort(package); // 패키지의 최솟값
            Array.Sort(piece); // 낱개의 최솟값

            int sum = 0;

            // 패키지의 가격과 낱개 * 6개의 가격을 비교하여 더 적은 금액을 구하고
            // (필요한 기타 줄 / 6) * 더 적은 금액 6개의 가격을 구합니다.
            sum += (package[0] < piece[0] * 6) ? N / 6 * package[0] : N / 6 * piece[0] * 6;

            // 계산하지 않은 나머지 줄의 갯수를 구합니다.
            N %= 6;

            // 패키지의 가격과 나머지 줄 * 낱개의 가격을 비교하여 더 적은 금액을 구하고
            // 더 적은 금액으로 나머지 줄의 갯수를 곱해줍니다.
            sum += (package[0] > N * piece[0]) ? N * piece[0] : package[0];

            writer.WriteLine(sum);

            writer.Close();
            reader.Close();
        }

        public void Q1051()
        {
            StreamWriter writer = new StreamWriter(Console.OpenStandardOutput());
            StreamReader reader = new StreamReader(Console.OpenStandardInput());

            string[] input = reader.ReadLine().Split();

            int N = int.Parse(input[0]);
            int M = int.Parse(input[1]);
            int[,] rectangle = new int[N, M];

            for (int i = 0; i < N; i++)
            {
                char[] row = reader.ReadLine().ToCharArray();
                for (int j = 0; j < M; j++)
                    rectangle[i, j] = int.Parse(row[j].ToString()); // N*M의 직사각형 값 할당
            }

            int x = 0;
            int y = 0;
            int size = 0;
            int index = 1;

            while (true)
            {
                if (x + index >= N || y + index >= M) // x와 y의 값이 N이나 M을 벗어나면 
                {
                    x++;

                    if (x >= N) // x 값이 N보다 크거나 같으면 초기화 하고 y 증가
                    {
                        x = 0;
                        y++;
                    }

                    if (y >= M) // y 값이 M보다 크거나 같으면 반복문 종료
                        break;

                    index = 0;
                }

                // 각 꼭지점의 값이 같은지 확인
                if (index != 0 && rectangle[x, y] == rectangle[x + index, y + index] &&
                    rectangle[x + index, y + index] == rectangle[x + index, y] &&
                    rectangle[x + index, y] == rectangle[x, y + index])
                {
                    // 정사각형의 크기 계산
                    if (size < (index + 1) * (index + 1))
                        size = (index + 1) * (index + 1);
                }

                index++;

            }

            if (size == 0)
                size = 1;

            writer.WriteLine(size);
        }

        public void Q1052()
        {
            StreamWriter writer = new StreamWriter(Console.OpenStandardOutput());
            StreamReader reader = new StreamReader(Console.OpenStandardInput());

            string[] input = reader.ReadLine().Split();
            int N = int.Parse(input[0]);
            int K = int.Parse(input[1]);

            int num = N;
            int count = 0; // 남은 물병의 개수파악
            int bottle = 0; // 구매한 꽃병의 수

            while (true)
            {
                while (num > 0)
                {
                    if (num % 2 == 0)  // 짝수개이면 다 합칠 수 있고
                    {
                        num /= 2;
                    }
                    else // 아니라면 카운팅 하나 추가
                    {
                        num /= 2;
                        count++;
                    }
                }

                // 남은 물병의 개수가 K 개를 넘지 않으면 종료
                if (count <= K)
                    break;

                // 아니라면 꽃병 하나 구매, N개수 증가
                bottle++;
                num = ++N;
                count = 0;
            }

            writer.WriteLine(bottle);

            writer.Close();
            reader.Close();
        }

        public void Q1059()
        {
            StreamWriter writer = new StreamWriter(OpenStandardOutput());
            StreamReader reader = new StreamReader(OpenStandardInput());

            int L = int.Parse(reader.ReadLine());
            List<int> input = Array.ConvertAll(reader.ReadLine().Split(), int.Parse).ToList();
            int n = int.Parse(reader.ReadLine());
            input.Add(0); // n의 값이 S[0]의 값보다 작은 경우를 확인하기 위해 S[0] = 0값을 추가
            int[] S = input.ToArray();
            Array.Sort(S);

            int count = 0;
            int index = 1;
            int min = 0;

            for (int i = 0; i < S.Length; i++)
            {
                if (S[i] < n && n < S[i + 1]) // 정수 집합 S에서 n의 위치를 찾기 위한 조건
                {
                    min = S[i] + 1; // 초기 A 값
                    while (true)
                    {
                        if (min + index >= S[i + 1]) // B 값이 집합 S의 값에 도달한다면 초기화
                        {
                            index = 1;
                            min++;
                        }

                        if (min >= S[i + 1] || min + index >= S[i + 1]) // 구간 A와 B 의 값이 좋은 구간을 벗어난다면 종료
                            break;

                        if (min <= n && n <= min + index) // 좋은 구간 카운팅
                            count++;

                        index++;
                    }

                    break;
                }
            }

            writer.WriteLine(count);

            writer.Close();
            reader.Close();
        }

        public void Q1063()
        {
            StreamWriter writer = new StreamWriter(Console.OpenStandardOutput());
            StreamReader reader = new StreamReader(Console.OpenStandardInput());

            string[] input = reader.ReadLine().Split();

            // 킹과 돌을 정수로 입력 받습니다. 
            (int row, int colum) king = (int.Parse(input[0][1].ToString()), input[0][0] - 'A' + 1);
            (int row, int colum) stone = (int.Parse(input[1][1].ToString()), input[1][0] - 'A' + 1);

            int N = int.Parse(input[2]);

            for (int i = 0; i < N; i++)
            {
                // 입력 받은 이동해야될 방향을 정수로 변경합니다.
                (int row, int colum) = FindDir(reader.ReadLine());

                // 킹을 이동시킵니다.
                king = (king.row + row, king.colum + colum);

                // 킹이 체스판을 벗어난다면 다시 원래대로 이동시키고 다음 이동을 진행합니다.
                if (king.row >= 9 || king.colum >= 9 || king.row <= 0 || king.colum <= 0)
                {
                    king = (king.row - row, king.colum - colum);
                    continue;
                }

                // 킹과 돌의 위치가 같다면 돌을 킹이 움직인 방향으로 똑같이 움직입니다
                if (king.row == stone.row && king.colum == stone.colum)
                    stone = (stone.row + row, stone.colum + colum);

                // 돌의 위치가 체스판을 벗어난다면 돌과 킹을 원래대로 돌립니다.
                if (stone.row >= 9 || stone.colum >= 9 || stone.row <= 0 || stone.colum <= 0)
                {
                    stone = (stone.row - row, stone.colum - colum);
                    king = (king.row - row, king.colum - colum);
                }
            }

            writer.WriteLine($"{(char)(king.colum + 'A' - 1)}{king.row}");
            writer.WriteLine($"{(char)(stone.colum + 'A' - 1)}{stone.row}");

            writer.Close();
            reader.Close();

            (int row, int colum) FindDir(string input)
                => input switch
                {
                    "R" => (0, 1),
                    "L" => (0, -1),
                    "B" => (-1, 0),
                    "T" => (1, 0),
                    "RT" => (1, 1),
                    "LT" => (1, -1),
                    "RB" => (-1, 1),
                    "LB" => (-1, -1),
                    _ => throw new NotImplementedException(),
                };
        }

        public void Q1065()
        {
            int n = int.Parse(Console.ReadLine());
            int count = 0;

            for (int i = 1; i < n + 1; i++)
            {
                if (FindAP(i))
                    count++;
            }

            Console.WriteLine(count);

            bool FindAP(int num)
            {
                if (num < 100)
                    return true;

                string str = num.ToString();
                int[] numbers = new int[str.Length];

                for (int i = 0; i < str.Length; i++)
                    numbers[i] = int.Parse(str[i].ToString());

                if (numbers[0] - numbers[1] == numbers[1] - numbers[2])
                    return true;

                return false;
            }
        }

        public void Q1075()
        {
            int temp, i;
            int n = int.Parse(Console.ReadLine());
            int f = int.Parse(Console.ReadLine());

            n = (n / 100) * 100;

            for (i = 0; i < 100; i++)
            {
                temp = n;

                if ((temp += i) % f == 0)
                    break;
            }

            if (i < 10)
                Console.Write(0);

            Console.Write(i);
        }

        public void Q1076()
        {
            Dictionary<string, (long, long)> dict = new Dictionary<string, (long, long)>();
            dict.Add("black", (0, 1));
            dict.Add("brown", (1, 10));
            dict.Add("red", (2, 100));
            dict.Add("orange", (3, 1000));
            dict.Add("yellow", (4, 10000));
            dict.Add("green", (5, 100000));
            dict.Add("blue", (6, 1000000));
            dict.Add("violet", (7, 10000000));
            dict.Add("grey", (8, 100000000));
            dict.Add("white", (9, 1000000000));

            string a = Console.ReadLine();
            string b = Console.ReadLine();
            string c = Console.ReadLine();

            long value = (dict[a].Item1 * 10 + dict[b].Item1) * dict[c].Item2;
            Console.WriteLine(value);
        }

        public void Q1085()
        {
            int[] data = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

            int x = data[0];
            int y = data[1];
            int w = data[2];
            int h = data[3];

            int[] result = new int[4];
            result[0] = x;
            result[1] = y;
            result[2] = w - x;
            result[3] = h - y;

            Console.WriteLine(result.Min());
        }

        public void Q1094()
        {
            int x = Convert.ToInt32(Console.ReadLine());

            int count = 0;

            while (x > 0)
            {
                if (x % 2 == 1)
                    count++;
                x /= 2;
            }

            Console.WriteLine(count);
        }

        public void Q1100()
        {
            StreamWriter writer = new StreamWriter(Console.OpenStandardOutput());
            StreamReader reader = new StreamReader(Console.OpenStandardInput());

            List<(int, int)> whiteMap = new List<(int, int)>();
            int start;
            for (int i = 0; i < 8; i++)
            {
                // 시작점을 정해줍니다.
                start = (i == 0 || i % 2 == 0) ? 0 : 1;

                // 흰색 체스판들을 찾습니다.
                for (int j = start; j < 8; j += 2)
                    whiteMap.Add((i, j));
            }

            int[,] inputMap = new int[8, 8];

            for (int i = 0; i < 8; i++)
            {
                string str = reader.ReadLine();
                for (int j = 0; j < 8; j++)
                {
                    // 입력받은 값이 'F'면 1을 아니면 0을 입력받습니다.
                    if (str[j] == 'F')
                        inputMap[i, j] = 1;
                    else
                        inputMap[i, j] = 0;
                }
            }

            int count = 0;
            for (int i = 0; i < whiteMap.Count; i++)
            {
                // 흰색체스판 위에 값이 1이면 카운트 증가
                if (inputMap[whiteMap[i].Item1, whiteMap[i].Item2] == 1)
                    count++;
            }

            writer.WriteLine(count);

            writer.Close();
            reader.Close();
        }

        public void Q1110()
        {
            string n = Console.ReadLine();
            int added;

            if (10 > int.Parse(n))
                n += 0;

            string originalN = n;

            int count = 0;
            while (true)
            {
                count++;
                int x = int.Parse(n) / 10;
                int y = int.Parse(n) % 10;

                added = x + y;

                n = y.ToString() + (added % 10).ToString();

                if (int.Parse(n) == int.Parse(originalN))
                    break;
            }

            Console.WriteLine(count);
        }

        public void Q1145()
        {
            StreamWriter writer = new StreamWriter(Console.OpenStandardOutput());
            StreamReader reader = new StreamReader(Console.OpenStandardInput());

            int[] input = Array.ConvertAll(reader.ReadLine().Split(), int.Parse);

            long result = input.Min();
            int count = 0;

            // 값이 작기 때문에 완전탐색
            while (true)
            {
                for (int i = 0; i < 5; i++)
                {
                    // 나누어 떨어진 값이 0이라면 count 증가
                    if (result % input[i] == 0)
                        count++;
                }

                // 적어도 세 개로 나누어 지는 가장 작은 자연수면 반복문 탈출
                if (count >= 3)
                    break;

                count = 0;
                result++;
            }

            writer.WriteLine(result);

            writer.Close();
            reader.Close();
        }

        public void Q1152()
        {
            string[] str = Console.ReadLine().Split();
            int length = str.Length;
            int count = 0;
            for (int i = 0; i < length; i++)
            {
                if (str[i] == "")
                    count++;
            }
            Console.WriteLine(str.Length - count);
        }

        public void Q1157()
        {
            StreamWriter writer = new StreamWriter(Console.OpenStandardOutput());
            StreamReader reader = new StreamReader(Console.OpenStandardInput());

            string str = reader.ReadLine().ToUpper();
            int[] counts = new int[26];

            for (int i = 0; i < str.Length; i++)
                counts[str[i] - 'A']++;

            int max = 0;
            int maxIndex = -1;
            bool duplicated = false;

            for (int i = 0; i < counts.Length; i++)
            {
                if (counts[i] > max)
                {
                    max = counts[i];
                    maxIndex = i;
                    duplicated = false;
                }
                else if (counts[i] == max)
                {
                    duplicated = true;
                }
            }

            writer.WriteLine(duplicated == true ? '?' : (char)(maxIndex + 'A'));

            reader.Close();
            writer.Close();
        }

        public void Q1159()
        {
            StringBuilder builder = new StringBuilder();
            StreamWriter writer = new StreamWriter(Console.OpenStandardOutput());
            StreamReader reader = new StreamReader(Console.OpenStandardInput());

            int n = int.Parse(reader.ReadLine());

            // 알파벳 갯수를 담을 배열 정의
            int[] english = new int[26];

            for (int i = 0; i < n; i++)
            {
                // 첫번째 글자에 'a' 값을 빼어 호출되는 수만큼 더해서 저장
                string name = reader.ReadLine();
                english[name[0] - 'a']++;
            }

            for (int i = 0; i < english.Length; i++)
            {
                // 5번 이상 호출되면 기록
                if (english[i] >= 5)
                    builder.Append((char)(i + 'a'));
            }

            // 기록된게 하나도 없다면 기권 아니면 성 첫글자 출력
            if (builder.Length == 0)
                writer.WriteLine("PREDAJA");
            else
                writer.WriteLine(builder);

            writer.Close();
            reader.Close();
        }

        public void Q1181()
        {
            StreamWriter writer = new StreamWriter(Console.OpenStandardOutput());
            StreamReader reader = new StreamReader(Console.OpenStandardInput());

            int n = int.Parse(reader.ReadLine());
            List<string> str = new List<string>();

            for (int i = 0; i < n; i++)
            {
                string s = reader.ReadLine();
                str.Add(s);
            }

            str = str.Distinct().ToList();
            str.Sort();
            List<string> str2 = str.OrderBy(x => x.Length).ToList();

            for (int i = 0; i < str2.Count; i++)
                writer.WriteLine(str2[i]);

            writer.Close();
            reader.Close();
        }

        public void Q1193()
        {
            int n = int.Parse(ReadLine());

            int line = 0;
            int sum = 0;

            while (n > sum)
            {
                line++;
                sum += line;
            }

            int i = n - (sum - line);

            if (line % 2 == 1)
                Write($"{line - i + 1}/{ i}");
            else
                Write($"{i}/{line - i + 1}");
        }

        public void Q1212()
        {
            StreamWriter writer = new StreamWriter(OpenStandardOutput());
            StreamReader reader = new StreamReader(OpenStandardInput());

            StringBuilder builder = new StringBuilder();

            string[] binary = { "000", "001", "010", "011", "100", "101", "110", "111" };

            char[] input = reader.ReadLine().ToCharArray(); // 8진수

            if (input[0] == '0') // 입력이 0인경우 바로 0으로 출력
            {
                builder.Append(0);
            }
            else
            {
                for (int i = 0; i < input.Length; i++)
                {
                    int num = int.Parse(input[i].ToString());
                    builder.Append(binary[num]);  // 한자리씩 읽어들여 2진수 3자리로 변형
                }

                while (true)
                {
                    if (builder[0] == '0') // 맨 앞자리가 0이 아닐 때까지 제거
                        builder.Remove(0, 1);
                    else
                        break;
                }
            }

            writer.WriteLine(builder);

            writer.Close();
            reader.Close();
        }

        public void Q1225()
        {
            StreamWriter writer = new StreamWriter(Console.OpenStandardOutput());
            StreamReader reader = new StreamReader(Console.OpenStandardInput());

            string[] input = reader.ReadLine().Split();
            string a = input[0];
            string b = input[1];

            long sum = 0;
            for (int i = 0; i < a.Length; i++)
            {
                // a와 b를 한자리씩 순환하면 sum에 다 더해주고 있습니다.
                for (int j = 0; j < b.Length; j++)
                    sum += int.Parse(a[i].ToString()) * int.Parse(b[j].ToString());
            }

            writer.WriteLine(sum);

            writer.Close();
            reader.Close();
        }

        public void Q1233()
        {
            StreamWriter writer = new StreamWriter(Console.OpenStandardOutput());
            StreamReader reader = new StreamReader(Console.OpenStandardInput());

            string[] input = reader.ReadLine().Split();
            int s1 = int.Parse(input[0]);
            int s2 = int.Parse(input[1]);
            int s3 = int.Parse(input[2]);

            int[] count = new int[s1 + s2 + s3 + 1];

            for (int i = 1; i <= s1; i++)
            {
                for (int j = 1; j <= s2; j++)
                {
                    for (int z = 1; z <= s3; z++)
                        count[i + j + z]++; // 주사위의 모든 눈의 합을 카운팅
                }
            }

            int max = 0, result = 0;
            for (int i = 1; i < count.Length; i++)
            {
                // 가장 높은 빈도수를 구함 (단, 여러개라면 합이 가장 작은거)
                // 오름차순이라 처음으로 구해진 max값이 제일 작습니다.
                if (max < count[i])
                {
                    max = count[i];
                    result = i;
                }

            }

            writer.WriteLine(result);

            writer.Close();
            reader.Close();
        }

        public void Q1236()
        {
            StreamWriter writer = new StreamWriter(Console.OpenStandardOutput());
            StreamReader reader = new StreamReader(Console.OpenStandardInput());

            string[] input = reader.ReadLine().Split();
            int N = int.Parse(input[0]);
            int M = int.Parse(input[1]);

            string[] array = new string[N];

            for (int i = 0; i < N; i++)
                array[i] = reader.ReadLine();

            int columCount = 0;

            // 행에서 경비원이 필요한 숫자 계산
            for (int i = 0; i < N; i++)
            {
                bool isGuard = false;
                for (int j = 0; j < M; j++)
                {
                    if (array[i][j] == 'X') // N행에서 경비원이 한명이라도 있으면 패스
                    {
                        isGuard = true;
                        break;
                    }
                }

                if (!isGuard) // N행에 경비원이 한명도 없으면 추가
                    columCount++;
            }

            int rowCount = 0;

            // 열에서 경비원이 필요한 숫자 계산
            for (int i = 0; i < M; i++)
            {
                bool isGuard = false;
                for (int j = 0; j < N; j++)
                {
                    if (array[j][i] == 'X') // M열에서 경비원이 한명이라도 있으면 패스
                    {
                        isGuard = true;
                        break;
                    }
                }

                if (!isGuard) // M열에 경비원이 한명도 없으면 추가
                    rowCount++;
            }

            // 경비원이 더 큰수를 출력
            writer.WriteLine((rowCount > columCount) ? rowCount : columCount);

            writer.Close();
            reader.Close();
        }

        public void Q1251()
        {
            // 1251 단어 나누기
            StreamWriter writer = new StreamWriter(Console.OpenStandardOutput());
            StreamReader reader = new StreamReader(Console.OpenStandardInput());

            string input = reader.ReadLine();

            int left = 1; // 삼등분 해야되는 왼쪽 값
            int right = 2; // 삼등분 해야하는 오른쪽 값
            int length = input.Length;
            List<string> result = new List<string>();

            while (true)
            {
                char[] a = input[..left].ToArray(); // 삼등분한 첫번째 단어
                Array.Reverse(a);

                char[] b = input[left..right].ToArray(); // 삼등분한 두번째 단어
                Array.Reverse(b);

                char[] c = input[right..length].ToArray(); // // 삼등분한 세번째 단어
                Array.Reverse(c);

                result.Add(new string(a) + new string(b) + new string(c));

                right++;

                if (right >= length) // right의 값이 총 길이를 넘기면 left값 증가시키고 right값을 left+1로 초기화
                {
                    left++;
                    right = left + 1;

                    if (right >= length) // 초기화 후에도 length 보다 크다면 반복문 종료
                        break;
                }
            }

            result.Sort(); // 사전상 가장 앞에 있는 단어 오름차순 정렬

            writer.WriteLine(result[0]);

            writer.Close();
            reader.Close();
        }

        public void Q1252()
        {
            //  https://bokhead.tistory.com/
            // 1252 이진수 덧셈
            StreamWriter writer = new StreamWriter(Console.OpenStandardOutput());
            StreamReader reader = new StreamReader(Console.OpenStandardInput());

            string[] input = reader.ReadLine().Split();
            BigInteger value = BigInteger.Parse(input[0]);
            BigInteger value2 = BigInteger.Parse(input[1]);

            string sum = (value + value2).ToString();

            List<BigInteger> result = new List<BigInteger>();

            int s = 0;

            for (int i = sum.Length - 1; i >= 0; i--)
            {
                int j = int.Parse(sum[i].ToString()) + s;

                if (j != 0)
                {
                    s = j / 2; // 다음 값에 해주기위해서
                    result.Add(j % 2); // 이진수 값 추가
                }
                else
                {
                    s = 0;
                    result.Add(0);
                }
            }

            if (s == 1)
                result.Add(s);

            result.Reverse(); // 2진수 리버스

            List<string> strings = result.ConvertAll<string>(x => x.ToString()); // string 형으로 바꾸기 위해서
            writer.WriteLine(String.Join("", strings));

            writer.Close();
            reader.Close();

        }

        public void Q1259()
        {
            StreamWriter writer = new StreamWriter(Console.OpenStandardOutput());
            StreamReader reader = new StreamReader(Console.OpenStandardInput());

            while (true)
            {
                string n = reader.ReadLine();

                if (n[0] == '0')
                    break;

                writer.WriteLine(Result(n));
            }

            writer.Close();
            reader.Close();

            string Result(string n)
            {
                for (int i = 0, j = n.Length - 1; i < n.Length; i++, j--)
                {
                    if (int.Parse(n[i].ToString()) != int.Parse(n[j].ToString()))
                        return "no";
                }

                return "yes";
            }
        }

        public void Q1260()
        {
            int[] visited;
            List<int>[] list;
            Queue<int> queue;
            List<int> result;

            StreamWriter writer = new StreamWriter(Console.OpenStandardOutput());
            StreamReader reader = new StreamReader(Console.OpenStandardInput());

            int[] data = Array.ConvertAll(reader.ReadLine().Split(), int.Parse);
            int n = data[0];
            int m = data[1];
            int r = data[2];

            list = new List<int>[1001];
            visited = new int[1001];
            result = new List<int>();

            for (int i = 0; i < 1001; i++)
                list[i] = new List<int>();

            for (int i = 0; i < m; i++)
            {
                // 양방향
                int[] line = Array.ConvertAll(reader.ReadLine().Split(), int.Parse);
                list[line[0]].Add(line[1]);
                list[line[1]].Add(line[0]);
            }

            for (int i = 1; i < 1001; i++)
                list[i].Sort();

            DFS(r);

            for (int i = 0; i < result.Count; i++)
                writer.Write(result[i] + " ");

            void DFS(int start)
            {
                if (visited[start] == 1)
                    return;

                visited[start] = 1;
                result.Add(start);

                for (int i = 0; i < list[start].Count; i++)
                    DFS(list[start][i]);
            }

            // ---------------------------------------------------------------------------------------

            queue = new Queue<int>();
            visited = new int[1001];
            result.Clear();

            queue.Enqueue(r);
            result.Add(r);
            visited[r] = 1;

            while (queue.Count != 0)
            {
                int q = queue.Dequeue();

                for (int i = 0; i < list[q].Count; i++)
                {
                    int temp = list[q][i];
                    if (visited[temp] != 1)
                    {
                        visited[temp] = 1;
                        result.Add(temp);
                        queue.Enqueue(temp);
                    }
                }
            }

            writer.Write("\n");

            for (int i = 0; i < result.Count; i++)
                writer.Write(result[i] + " ");

            writer.Close();
            reader.Close();
        }

        public void Q1271()
        {
            //    // 1271
            StreamWriter writer = new StreamWriter(Console.OpenStandardOutput());
            StreamReader reader = new StreamReader(Console.OpenStandardInput());

            string[] input = reader.ReadLine().Split();
            BigInteger n = BigInteger.Parse(input[0]);
            BigInteger m = BigInteger.Parse(input[1]);

            writer.WriteLine(n / m);
            writer.WriteLine(n % m);

            writer.Close();
            reader.Close();
        }

        public void Q1284()
        {
            StreamWriter writer = new StreamWriter(Console.OpenStandardOutput());
            StreamReader reader = new StreamReader(Console.OpenStandardInput());

            int length;
            while (true)
            {
                // 호수판의 경계와 숫자 사이에는 1cm * 2
                length = 2;

                string input = reader.ReadLine();

                // 입력이 0이면 프로그램 종료
                if (input == "0")
                    break;

                for (int i = 0; i < input.Length; i++)
                {
                    int num = int.Parse(input[i].ToString());

                    // 1은 2cm / 0은 4cm / 나머지는 3cm
                    if (num == 1)
                        length += 2;
                    else if (num == 0)
                        length += 4;
                    else
                        length += 3;
                }

                // 각 숫자 사이에는 1cm 여백 ( 총 갯수 - 1 만큼 )
                length += input.Length - 1;

                writer.WriteLine(length);
            }

            writer.Close();
            reader.Close();
        }

        public void Q1292()
        {
            StreamWriter writer = new StreamWriter(Console.OpenStandardOutput());
            StreamReader reader = new StreamReader(Console.OpenStandardInput());

            string[] input = reader.ReadLine().Split();
            int A = int.Parse(input[0]);
            int B = int.Parse(input[1]);

            int count = 0; // 1을 한번, 2를 두번 등 몇번 입력받았는지 갯수 체크를 위한 변수
            List<int> list = new List<int>(); // 수열을 저장하기 위한 LIST

            int num = 1;
            while (true)
            {
                list.Add(num); // 수열을 추가합니다.
                count++;

                if (num == count) // num이랑 count가 같으면 갯수를 1로 초기화 
                {
                    num++;
                    count = 0;
                }

                if (list.Count + 1 > B) // 입력받은 B번째 숫자까지 추가하게되면 반복문 종료
                    break;
            }

            int sum = 0;
            // A번째 부터 B번째 까지의 합을 구합니다. ( A-1 => 리스트의 인덱스는 0부터 시작하기 때문에 )
            for (int i = A - 1; i < B; i++)
                sum += list[i];

            writer.WriteLine(sum);

            writer.Close();
            reader.Close();
        }

        public void Q1297()
        {
            StreamWriter writer = new StreamWriter(Console.OpenStandardOutput());
            StreamReader reader = new StreamReader(Console.OpenStandardInput());

            string[] input = reader.ReadLine().Split();
            int D = int.Parse(input[0]); // 대각선의 길이
            int H = int.Parse(input[1]); // 높의 비율 
            int W = int.Parse(input[2]); // 너비 비율

            double c = MathF.Sqrt(H * H + W * W);
            double a = H * D / c;
            double b = W * D / c;

            writer.WriteLine($"{(int)a} {(int)b}");

            writer.Close();
            reader.Close();
        }

        public void Q1316()
        {
            int n = int.Parse(Console.ReadLine());
            int cnt = 0;

            for (int i = 0; i < n; i++)
            {
                if (Word(Console.ReadLine()))
                    cnt++;
            }

            Console.WriteLine(cnt);

            bool Word(string s)
            {
                for (int i = 0; i < s.Length; i++)
                {
                    for (int j = i; j < s.Length; j++)
                    {
                        if (j - i > 1 && s[i] == s[j])
                            return false;
                        if (s[i] == s[j])
                            i += j - i;
                    }
                }

                return true;
            }
        }

        public void Q1330()
        {
            int[] data = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

            if (data[0] == data[1])
                Console.WriteLine("==");
            else if (data[0] > data[1])
                Console.WriteLine(">");
            else
                Console.WriteLine("<");
        }

        public void Q1333()
        {
            StreamWriter writer = new StreamWriter(Console.OpenStandardOutput());
            StreamReader reader = new StreamReader(Console.OpenStandardInput());

            string[] input = reader.ReadLine().Split();
            int N = int.Parse(input[0]); // 총 노래 곡
            int L = int.Parse(input[1]); // 모든 노래의 길이
            int D = int.Parse(input[2]); // 전화벨 울리는 초시간

            int time = 0; // 전화벨을 들을 수 있는 시간 누적
            int bell = 0; // 전화벨 체크 
            int result = 0; // 정답
            int index = 0; // N곡 인덱스 넘버

            while (N - 1 >= index)
            {
                int music = 0; // 뮤직 진행 시간

                while (true)
                {
                    if (music == L) // 뮤직 진행이 끝나면 반복문 종료
                        break;

                    if (bell >= D) // 전화벨 시간이 지나면 0초로 초기화
                        bell = 0;

                    music++;
                    bell++;
                    time++;
                }

                for (int j = 0; j < 5; j++) // 노래와 노래 사이 5초
                {
                    if (bell >= D) // 이 시간에 전화벨을 울릴 시간이 되면 프로그램 종료 준비
                    {
                        index = N; // 최상위 반복문을 종료하기 위한 플래그 
                        result = time; // 종료되는 시간 측정
                        break;
                    }
                    bell++;
                    time++;
                }

                index++;
            }

            if (result == 0) // 만약 노래가 전부다 끝나기 전까지 전화를 못받았다면
                result = (time % D == 0) ? time : time + D - (time % D); // 전화벨이 울릴시간을 측정하여 최종 값 계산

            writer.WriteLine(result);

            writer.Close();
            reader.Close();
        }

        public void Q1343()
        {
            StringBuilder sb = new StringBuilder();
            StreamWriter writer = new StreamWriter(OpenStandardOutput());
            StreamReader reader = new StreamReader(OpenStandardInput());

            string input = reader.ReadLine();
            int count = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == 'X') // X가 나올 때마다 카운팅
                {
                    count++;
                }
                else
                {
                    if (count % 2 == 1) // '.'이 나왔을 때 카운팅된 개수가 홀수이면 -1 출력 
                    {
                        sb = new StringBuilder();
                        sb.Append(-1);
                        break;
                    }

                    Counting(); // 입력받은 X의 개수만큼 AAAA와 BB 출력

                    sb.Append(".");
                }
            }

            if (count > 0) // .이 한번도 나오지 않은경우 예외처리 실행
            {
                if (count % 2 == 1)
                {
                    sb = new StringBuilder();
                    sb.Append(-1);
                }
                else
                    Counting();
            }

            writer.WriteLine(sb);
            writer.Close();
            reader.Close();

            void Counting()
            {
                while (count != 0)
                {
                    if (count >= 4)
                    {
                        sb.Append("AAAA");
                        count -= 4;
                    }
                    else
                    {
                        sb.Append("BB");
                        count -= 2;
                    }
                }
            }
        }

        public void Q1343_1()
        {
            StreamWriter writer = new StreamWriter(OpenStandardOutput());
            StreamReader reader = new StreamReader(OpenStandardInput());

            string input = reader.ReadLine();

            input = input.Replace("XXXX", "AAAA").Replace("XX", "BB"); // 모든 XXXX와 XX를 바꿔줍니다.

            bool isSuccess = true;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == 'X') // 하나라도 X가 있으면 실패
                {
                    isSuccess = false;
                    break;
                }
            }

            if (isSuccess)
                writer.WriteLine(input);
            else
                writer.WriteLine(-1);

            writer.Close();
            reader.Close();
        }

        public void Q1373()
        {
            StreamWriter writer = new StreamWriter(OpenStandardOutput());
            StreamReader reader = new StreamReader(OpenStandardInput());

            string input = reader.ReadLine();
            int count = input.Length % 3;

            if (count != 0)
            {
                // 입력 받은 값을 3자리 씩 끊기 위해 맨 앞자리에 0을 붙여줍니다.
                for (int i = 0; i < 3 - count; i++)
                    input = "0" + input;
            }

            for (int i = 0; i < input.Length; i += 3)
            {
                // 3자리씩 10진수로 변형
                writer.Write((input[i] - '0') * 4 + (input[i + 1] - '0') * 2 + (input[i + 2] - '0') * 1);
            }

            writer.WriteLine();

            writer.Close();
            reader.Close();
        }

        public void Q1417()
        {
            StreamWriter writer = new StreamWriter(OpenStandardOutput());
            StreamReader reader = new StreamReader(OpenStandardInput());

            int N = int.Parse(reader.ReadLine());
            int Dasom = int.Parse(reader.ReadLine());
            int count = 0;

            if (N == 1) // 후보가 한명이라면 0 출력
            {
                writer.WriteLine(0);
            }
            else
            {
                int[] person = new int[N - 1];

                // 다솜이를 제외한 나머지 당선인 입력
                for (int i = 0; i < N - 1; i++)
                    person[i] = int.Parse(reader.ReadLine());

                // 오름차순 정렬
                Array.Sort(person);

                // 다솜이를 제외한 투표수가 제일 많은 사람과 비교하여 다솜이보다 적으면 0 출력
                if (Dasom > person[N - 2])
                {
                    writer.WriteLine(0);
                }
                else
                {
                    while (Dasom <= person[N - 2])
                    {
                        person[N - 2]--; // 제일 투표수가 많은 당선인의 표를 뺃고
                        Dasom++; // 다솜이에게 투표수 추가
                        count++; // 매수해야되는 사람의 수 증가

                        Array.Sort(person); // 제일 투표수가 많은 당선인을 찾기위해 Sort

                        // 다솜이를 제외한 투표수가 제일 많은 사람과 비교하여 다솜이보다 적으면 반복문 종료
                        if (Dasom > person[N - 2])
                            break;
                    }

                    writer.WriteLine(count);
                }
            }

            writer.Close();
            reader.Close();
        }


        public void Q1427()
        {
            // 1427 문자열 정렬
            StreamWriter writer = new StreamWriter(OpenStandardOutput());
            StreamReader reader = new StreamReader(OpenStandardInput());

            string input = reader.ReadLine();
            int[] range = new int[input.Length];

            int length = range.Length;
            for (int i = 0; i < length; i++)
                range[i] = int.Parse(input[i].ToString()); // 한자리씩 입력받아서 배열에 저장

            Array.Sort(range); // 내림차순으로 정렬

            for (int i = length - 1; i >= 0; i--) // 뒤에서부터 앞으로 출력
                writer.Write(range[i]);

            writer.Close();
            reader.Close();
        }

        public void Q1436()
        {
            StreamWriter writer = new StreamWriter(Console.OpenStandardOutput());
            StreamReader reader = new StreamReader(Console.OpenStandardInput());

            int n = int.Parse(reader.ReadLine());

            int cnt = 0;
            int start = 666;

            while (true)
            {
                // 영화 제목에 666이 포함되면 cnt를 증가
                if (start.ToString().Contains("666"))
                    cnt++;

                // 입력 받은 값이랑 같으면 반복문 중단
                if (n == cnt)
                    break;

                start++;
            }

            writer.Write($"{start}");

            writer.Close();
            reader.Close();
        }

        public void Q1439()
        {
            StreamWriter writer = new StreamWriter(OpenStandardOutput());
            StreamReader reader = new StreamReader(OpenStandardInput());

            string S = reader.ReadLine();
            int zeroCount = 0; // 0이 연속되는 숫자
            int oneCount = 0; // 1이 연속되는 숫자

            // 첫번째 숫자 카운팅
            if (S[0] == '0')
                zeroCount++;
            else
                oneCount++;

            for (int i = 1; i < S.Length; i++)
            {
                // 현재 숫자랑 전숫자랑 비교해서 값이 달라지면 연속이 끊킨거라고 판단하여 개수 증가
                if (S[i] != S[i - 1])
                {
                    if (S[i] == '0')
                        zeroCount++;
                    else
                        oneCount++;
                }
            }

            // 두 숫자 카운팅 중 작은숫자가 최소 횟수로 보고 출력
            writer.WriteLine(MathF.Min(zeroCount, oneCount));

            writer.Close();
            reader.Close();
        }

        public void Q1476()
        {
            StreamWriter writer = new StreamWriter(Console.OpenStandardOutput());
            StreamReader reader = new StreamReader(Console.OpenStandardInput());

            string[] input = reader.ReadLine().Split();
            int E = int.Parse(input[0]); // 1 <= E <= 15
            int S = int.Parse(input[1]); // 1 <= S <= 28
            int M = int.Parse(input[2]); // 1 <= M <= 19

            int e = 1, s = 1, m = 1;

            int result = 1;

            while (true)
            {
                if (e == E && s == S && m == M) // 입력받은 ESM과 같으면 반복문 종료
                    break;

                // 각각 e s m 값을 증가시키다가 범위를 넘으면 1로 초기화
                e = (e >= 15) ? 1 : ++e;
                s = (s >= 28) ? 1 : ++s;
                m = (m >= 19) ? 1 : ++m;

                // 몇년인지 카운팅
                result++;
            }

            writer.WriteLine(result);

            writer.Close();
            reader.Close();
        }

        public void Q1546()
        {
            int n = int.Parse(Console.ReadLine());

            int[] grade = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            float max = grade.ToList().Max();

            float sum = 0;
            for (int i = 0; i < n; i++)
            {
                sum += grade[i] / max * 100;
            }

            Console.WriteLine((float)sum / n);
        }

        public void Q1568()
        {
            StreamWriter writer = new StreamWriter(Console.OpenStandardOutput());
            StreamReader reader = new StreamReader(Console.OpenStandardInput());

            int input = int.Parse(reader.ReadLine());

            int count = 1;
            int second = 0;

            while (input > 0)
            {
                // 새가 날아가는 만큼 빼줍니다.
                input -= count;

                // 날아는 새의 수와 총 걸린 초를 누적시켜줍니다.
                count++;
                second++;

                // 앉아있는 새의 수 보다 날아가야 되는 새의 수가 많으면 1로 초기화
                if (input < count)
                    count = 1;
            }

            writer.WriteLine(second);

            writer.Close();
            reader.Close();
        }

        public void Q1654()
        {
            StreamWriter writer = new StreamWriter(OpenStandardOutput());
            StreamReader reader = new StreamReader(OpenStandardInput());

            string[] str = reader.ReadLine().Split();
            int k = int.Parse(str[0].ToString());
            int n = int.Parse(str[1].ToString());

            List<long> list = new List<long>();

            for (int i = 0; i < k; i++)
                list.Add(int.Parse(reader.ReadLine()));

            long max = list.Max();

            writer.WriteLine(FindMaxLAN());

            writer.Close();
            reader.Close();

            long FindMaxLAN()
            {
                long start = 1;
                long end = max;
                long middle;
                long sum = 0;

                while (true)
                {
                    // start가 end보다 커지는 순간 프로그램 종료
                    if (start > end)
                        break;

                    // 이분탐색 중간 값
                    middle = (start + end) / 2;

                    // 리스트 k의 값을 순환하며 중간 값으로 나누어 만들 수 있는 랜선의 갯수를 구합니다.
                    for (int i = 0; i < k; i++)
                        sum += list[i] / middle;

                    // 우리가 만들 랜선의 갯수가 n개보다 많거나 같아도 최대 랜선의 길이는 아닐 수 있기에 반복문을 또 돌면서 검사합니다.
                    if (sum >= n)
                        start = middle + 1;
                    else
                        end = middle - 1;

                    sum = 0;
                }

                return end;
            }
        }

        public void Q1697()
        {
            StreamWriter writer = new StreamWriter(Console.OpenStandardOutput());
            StreamReader reader = new StreamReader(Console.OpenStandardInput());

            int[] data = Array.ConvertAll(reader.ReadLine().Split(), int.Parse);
            int n = data[0];
            int k = data[1];
            bool[] visited = new bool[100001];

            Queue<(int, int)> queue = new Queue<(int, int)>();

            queue.Enqueue((n, 0));
            int result = 0;

            while (queue.Count != 0)
            {
                var q = queue.Dequeue();

                if (q.Item1 < 0 || q.Item1 > 100000)
                    continue;
                if (visited[q.Item1])
                    continue;

                visited[q.Item1] = true;

                if (q.Item1 == k)
                    result = q.Item2;

                queue.Enqueue((q.Item1 * 2, q.Item2 + 1));
                queue.Enqueue((q.Item1 + 1, q.Item2 + 1));
                queue.Enqueue((q.Item1 - 1, q.Item2 + 1));
            }

            writer.WriteLine(result);

            writer.Close();
            reader.Close();
        }

        public void Q1712()
        {
            int[] value = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            int a = value[0];
            int b = value[1];
            int c = value[2];

            if (b >= c)
            {
                Console.WriteLine(-1);
                return;
            }

            // a+bn = cn
            // a = cn - bn
            // a = n(c-b)
            // a / (c-b) = n
            Console.WriteLine((a / (c - b)) + 1);
        }

        public void Q1789()
        {
            StreamWriter writer = new StreamWriter(Console.OpenStandardOutput());
            StreamReader reader = new StreamReader(Console.OpenStandardInput());

            long S = long.Parse(reader.ReadLine());

            long N = 0;
            long index = 1;
            long sum = 0;

            while (true)
            {
                sum += index++; // 자연수 누적
                N++;

                if (sum > S) // 누적된 자연수의 값이 S보다 클때 까지 반복
                    break;
            }

            writer.WriteLine(N - 1);

            writer.Close();
            reader.Close();
        }

        public void Q1874()
        {
            // 1874 스택 수열 문제 풀이
            StreamWriter writer = new StreamWriter(OpenStandardOutput());
            StreamReader reader = new StreamReader(OpenStandardInput());

            int n = int.Parse(reader.ReadLine());
            int[] sequence = new int[n];

            for (int i = 0; i < n; i++)
                sequence[i] = int.Parse(reader.ReadLine());

            Stack<int> stack = new Stack<int>();
            List<char> result = new List<char>();

            int count = 0;
            for (int i = 1; i < n + 1; i++)
            {
                stack.Push(i);
                result.Add('+');

                while (true)
                {
                    if (stack.Count == 0)
                        break;

                    // 스택의 pop 할 값과 임의의 수열 값을 확인하여 같으면 Pop 합니다.
                    if (stack.Peek() == sequence[count])
                    {
                        stack.Pop();
                        count++; // 임의의 수열값을 증가시켜줍니다.
                        result.Add('-');
                    }
                    else
                        break;
                }
            }

            // 예제 입력 2에 대한 예외처리 
            if (stack.Count != 0)
            {
                writer.WriteLine("NO");
            }
            else
            {
                for (int i = 0; i < result.Count; i++)
                    writer.WriteLine(result[i]);
            }

            writer.Close();
            reader.Close();
        }

        public void Q1920()
        {
            // 기본 List 서치방식
            StreamWriter writer = new StreamWriter(Console.OpenStandardOutput());
            StreamReader reader = new StreamReader(Console.OpenStandardInput());

            int n = int.Parse(reader.ReadLine());
            List<int> a = Array.ConvertAll(reader.ReadLine().Split(), int.Parse).ToList();
            int m = int.Parse(reader.ReadLine());
            int[] result = Array.ConvertAll(reader.ReadLine().Split(), int.Parse);

            int print = 0;
            for (int i = 0; i < m; i++)
            {
                print = (a.Contains(result[i])) ? 1 : 0;
                writer.WriteLine(print);
            }

            writer.Close();
            reader.Close();
        }

        public void Q1920_2()
        {
            // 이진탐색
            StreamWriter writer = new StreamWriter(Console.OpenStandardOutput());
            StreamReader reader = new StreamReader(Console.OpenStandardInput());

            int n = int.Parse(reader.ReadLine());
            List<int> a = Array.ConvertAll(reader.ReadLine().Split(), int.Parse).ToList();
            int m = int.Parse(reader.ReadLine());
            int[] b = Array.ConvertAll(reader.ReadLine().Split(), int.Parse);

            a.Sort();
            int[] result = new int[b.Length];

            for (int i = 0; i < m; i++)
            {
                int start = 0;
                int end = a.Count - 1;
                int middle = 0;

                while (true)
                {
                    middle = (start + end) / 2;
                    if (middle == start)
                    {
                        if (a[start] == b[i] || a[end] == b[i])
                            result[i] = 1;
                        else
                            result[i] = 0;
                        break;
                    }
                    else if (a[middle] == b[i])
                    {
                        result[i] = 1;
                        break;
                    }
                    else if (a[middle] > b[i])
                    {
                        end = middle;
                    }
                    else if (a[middle] < b[i])
                    {
                        start = middle;
                    }
                }
            }

            StringBuilder sb = new StringBuilder(string.Join("\n", result));

            writer.WriteLine(sb);

            writer.Close();
            reader.Close();
        }

        public void Q1920_3()
        {
            StreamWriter writer = new StreamWriter(Console.OpenStandardOutput());
            StreamReader reader = new StreamReader(Console.OpenStandardInput());

            int n = int.Parse(reader.ReadLine());
            List<int> a = Array.ConvertAll(reader.ReadLine().Split(), int.Parse).ToList();
            int m = int.Parse(reader.ReadLine());
            int[] b = Array.ConvertAll(reader.ReadLine().Split(), int.Parse);

            a.Sort();
            int[] result = new int[b.Length];

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < m; i++)
            {
                int start = 0;
                int end = a.Count - 1;
                bool found = false;

                while (start <= end && !found)
                {
                    int middle = (start + end) / 2;

                    if (a[middle] == b[i])
                        found = true;
                    else if (a[middle] > b[i])
                        end = middle - 1;
                    else
                        start = middle + 1;
                }
                sb.Append(found ? "1\n" : "0\n");
            }

            writer.WriteLine(sb);

            writer.Close();
            reader.Close();
        }

        public void Q1929()
        {
            StreamWriter writer = new StreamWriter(OpenStandardOutput());
            StreamReader reader = new StreamReader(OpenStandardInput());

            int[] primeNum = Eratosthenes(1000000 + 1);

            string[] str = reader.ReadLine().Split();
            int m = int.Parse(str[0]);
            int n = int.Parse(str[1]);

            for (int i = m; i <= n; i++)
            {
                if (primeNum[i] != 0)
                    writer.WriteLine(primeNum[i]);
            }

            writer.Close();
            reader.Close();
        }

        public void Q1931()
        {
            StreamWriter writer = new StreamWriter(OpenStandardOutput());
            StreamReader reader = new StreamReader(OpenStandardInput());

            int N = int.Parse(reader.ReadLine());
            (int start, int end)[] time = new (int, int)[N];

            for (int i = 0; i < N; i++)
            {
                string[] input = reader.ReadLine().Split();
                time[i] = (int.Parse(input[0]), int.Parse(input[1]));
            }

            Array.Sort(time, (x, y) => Compare(x, y)); // end를 기준으로 오름차순

            int count = 0; // 회의 가능 한 수
            int endTime = 0;

            for (int i = 0; i < N; i++)
            {
                if (endTime <= time[i].start) // 회의 종료 시점이 다음 회의 시작지점보다 적다면
                {
                    endTime = time[i].end;
                    count++;
                }
            }

            writer.WriteLine(count);

            writer.Close();
            reader.Close();

            int Compare((int start, int end) x, (int start, int end) y)
            {
                if (x.end == y.end) // 끝나는 순서가 같다면
                    return (x.start < y.start) ? -1 : 1; // 시작하는 순서가 빠른 순으로
                else
                    return (x.end < y.end) ? -1 : 1; // 끝나는 순서가 빠른 순으로
            }
        }

        public void Q1966()
        {
            StreamWriter writer = new StreamWriter(OpenStandardOutput());
            StreamReader reader = new StreamReader(OpenStandardInput());

            int t = int.Parse(reader.ReadLine());

            List<int> priority = new List<int>();
            int count = 0;

            for (int i = 0; i < t; i++)
            {
                string[] str = reader.ReadLine().Split();
                int n = int.Parse(str[0]); // 문서의 개수
                int m = int.Parse(str[1]); // Queue에서 몇 번째 놓여 있는지를 나타내는 정수

                int[] status = Array.ConvertAll(reader.ReadLine().Split(), int.Parse);

                Queue<(int, int)> queue = new Queue<(int, int)>();
                count = 0;
                priority.Clear();

                for (int j = 0; j < n; j++)
                {
                    queue.Enqueue((status[j], j));
                    priority.Add(status[j]);
                }

                priority.Sort();
                priority.Reverse();

                while (queue.Count > 0)
                {
                    // 위치값과, 우선순위 값을 가져온 뒤 pop수행
                    int value = queue.Peek().Item1;
                    int location = queue.Peek().Item2;

                    queue.Dequeue();

                    // 값 비교
                    if (priority[0] == value)
                    {
                        priority.RemoveAt(0);
                        ++count;
                        if (m == location)
                        {
                            writer.WriteLine(count);
                            break;
                        }
                    }
                    else
                    {
                        queue.Enqueue((value, location));
                    }
                }
            }
            writer.Close();
            reader.Close();
        }

        public void Q1966_1()
        {
            StreamWriter writer = new StreamWriter(OpenStandardOutput());
            StreamReader reader = new StreamReader(OpenStandardInput());

            int t = int.Parse(reader.ReadLine());

            Queue<(int, int)> queue = new Queue<(int, int)>();
            int max = 0;

            for (int i = 0; i < t; i++)
            {
                int[] count = new int[10];

                string[] str = reader.ReadLine().Split();
                int n = int.Parse(str[0]); // 문서의 개수
                int m = int.Parse(str[1]); // Queue에서 몇 번째 놓여 있는지를 나타내는 정수

                int[] status = Array.ConvertAll(reader.ReadLine().Split(), int.Parse);
                int result = 0;
                queue.Clear();

                for (int j = 0; j < n; j++)
                {
                    queue.Enqueue((status[j], j)); // (중요도, 인덱스순서)
                    count[status[j]]++; // 같은 숫자에 대해서 카운트
                }

                max = queue.Max(o => o.Item1); // 중요도의 최대값을 구합니다.

                while (queue.Count > 0) // 큐가 1개 이상일 때까지 반복하며
                {
                    // 중요도의 최대값이 큐의 값과 같다면
                    if (max == queue.Peek().Item1)
                    {
                        // 입력받은 m과 인덱스 순서를 비교하여 같으면 출력하고 반복문 탈출
                        if (queue.Peek().Item2 == m)
                        {
                            writer.WriteLine($"{++result}");
                            break;
                        }

                        // 인덱스 순서가 같지않으면 pop하고 최종
                        // result 값 ++
                        // 같은 숫자 갯수 --
                        int a = queue.Dequeue().Item1;
                        result++;
                        count[a]--;

                        // 중요도를 max 부터 -- 하면서 다음 서치해야될 중요도를 찾습니다.
                        if (count[a] == 0)
                        {
                            while (count[max] == 0)
                                --max;
                        }
                    }
                    else
                    {
                        queue.Enqueue(queue.Dequeue());
                    }
                }
            }

            writer.Close();
            reader.Close();
        }

        public void Q1978()
        {
            StreamWriter writer = new StreamWriter(OpenStandardOutput());
            StreamReader reader = new StreamReader(OpenStandardInput());

            int[] primeNum = new int[1001];

            for (int i = 2; i <= 1000; i++)
                primeNum[i] = i;

            float num = MathF.Sqrt(1000);
            for (int i = 2; i <= num; i++)
            {
                if (primeNum[i] == 0)
                    continue;

                for (int j = i * i; j <= 1000; j += i)
                    primeNum[j] = 0;
            }


            int n = int.Parse(reader.ReadLine());

            int[] value = Array.ConvertAll(reader.ReadLine().Split(), int.Parse);

            int cnt = 0;
            for (int i = 0; i < value.Length; i++)
            {
                if (primeNum[value[i]] != 0)
                    cnt++;
            }

            writer.WriteLine(cnt);

            writer.Close();
            reader.Close();
        }
    }
}
