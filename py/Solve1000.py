from functools import reduce
import sys
input = sys.stdin.readline

def solve1874():
    n = int(input())
    stack = []
    result = []
    sequence = []

    for i in range(n):
        sequence.append(int(input()))

    count = 0
    for i in range(1, n+1):
        stack.append(i)
        result.append('+')

        while 1:
            if (len(stack) == 0):
                break

            if (stack[-1] == sequence[count]):
                stack.pop()
                count+=1
                result.append('-')
            else :
                break

    if (len(stack) != 0):
        print("NO")
    else :
        for i in result:
            print(i)

solve1874()
