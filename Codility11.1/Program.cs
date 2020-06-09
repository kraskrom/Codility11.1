/*
You are given an array A consisting of N integers.

For each number A[i] such that 0 ≤ i < N, we want to count the number of elements of the array that are not the divisors of A[i]. We say that these elements are non-divisors.

For example, consider integer N = 5 and array A such that:

    A[0] = 3
    A[1] = 1
    A[2] = 2
    A[3] = 3
    A[4] = 6
For the following elements:

A[0] = 3, the non-divisors are: 2, 6,
A[1] = 1, the non-divisors are: 3, 2, 3, 6,
A[2] = 2, the non-divisors are: 3, 3, 6,
A[3] = 3, the non-divisors are: 2, 6,
A[4] = 6, there aren't any non-divisors.
Write a function:

class Solution { public int[] solution(int[] A); }

that, given an array A consisting of N integers, returns a sequence of integers representing the amount of non-divisors.

Result array should be returned as an array of integers.

For example, given:

    A[0] = 3
    A[1] = 1
    A[2] = 2
    A[3] = 3
    A[4] = 6
the function should return [2, 4, 3, 2, 0], as explained above.

Write an efficient algorithm for the following assumptions:

N is an integer within the range [1..50,000];
each element of array A is an integer within the range [1..2 * N].
*/

using System;

namespace Codility11._1
{
    class Solution
    {
        public int[] solution(int[] A)
        {
            int[] s = new int[A.Length];
            if (A.Length == 1)
                return s;
            int max = int.MinValue;
            for (int i = 0; i < A.Length; i++)
                if (A[i] > max)
                    max = A[i];
            int[] divisors = new int[max + 1];
            int[] count = new int[max + 1];
            for (int i = 0; i < A.Length; i++)
                count[A[i]]++;
            for (int i = 0; i < A.Length; i++)
                if (count[A[i]] > 0)
                {
                    for (int k = A[i]; k <= max; k += A[i])
                        divisors[k] += count[A[i]];
                    count[A[i]] = 0;
                }
            for (int i = 0; i < A.Length; i++)
                s[i] = A.Length - divisors[A[i]];
            return s;
        }
    }

    class Program
    {
        static void Main()
        {
            Solution sol = new Solution();
            int[] A = { 3, 1, 2, 3, 6 };
            //int[] A = { 2, 2 };
            //int[] A = new int[20000];
            //for (int i = 0; i < A.Length; i++)
            //    A[i] = i + 1;
            int[] s = sol.solution(A);
            //Console.WriteLine("Solution: " + s);
            Console.WriteLine("Solution: " + string.Join(", ", s));
        }
    }
}
