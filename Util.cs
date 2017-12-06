using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2017
{
    public static class Util
    {

        public static List<string> GetSubstringsOfLength(this string input, int length)
        {
            var result = new List<string>();
            for(int start = 0; start < input.Length - length; start++)
            {
                result.Add(input.Substring(start, length));
            }
            return result;
        }


        public static void PrintList(IEnumerable<object> list)
        {
            foreach(var o in list)
            {
                Console.WriteLine(o.ToString());
            }
        }
           
        public static Dictionary<char,int> GetCharCounts(this string input)
        {
            return input.GroupBy(c => c).ToDictionary(grp => grp.Key, grp => grp.Count());
        }

        public static List<string> ColumnsFromRows(this List<string> input)
        {
            var result = new List<String>();
            for(int col = 0; col < input[0].Length; col++)
            {
                var sb = new StringBuilder();
                for(int row = 0; row < input.Count; row++)
                {
                    sb.Append(input[row][col]);
                }
                result.Add(sb.ToString());

            }
            return result;

        }

        public static char LeastFrequentChar(this string input)
        {
            return input.GetCharCounts().ToList().OrderBy(x => x.Value).First().Key;
        }

        public static char MostFrequentChar(this string input)
        {
            return input.GetCharCounts().ToList().OrderByDescending(x => x.Value).First().Key;
        }

        public static void PrintMatrix(bool[,] matrix)
        {
            int rowLength = matrix.GetLength(0);
            int colLength = matrix.GetLength(1);
            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < colLength; j++)
                {
                    Console.Write(matrix[i, j]? 'X' : '_');
                }
                Console.Write(Environment.NewLine);
            }
            Console.Write(Environment.NewLine);
        }
        public static void PrintMatrix(char[,] matrix)
        {

            int rowLength = matrix.GetLength(0);
            int colLength = matrix.GetLength(1);
            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < colLength; j++)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.Write(Environment.NewLine);
            }
            Console.Write(Environment.NewLine);
        }
        public static int[,] RotateMatrixCounterClockwise(int[,] oldMatrix)
        {
            int[,] newMatrix = new int[oldMatrix.GetLength(1), oldMatrix.GetLength(0)];
            int newColumn, newRow = 0;
            for (int oldColumn = oldMatrix.GetLength(1) - 1; oldColumn >= 0; oldColumn--)
            {
                newColumn = 0;
                for (int oldRow = 0; oldRow < oldMatrix.GetLength(0); oldRow++)
                {
                    newMatrix[newRow, newColumn] = oldMatrix[oldRow, oldColumn];
                    newColumn++;
                }
                newRow++;
            }
            return newMatrix;
        }


        static MD5 md5 = System.Security.Cryptography.MD5.Create();

        public static string Md5toHex(string toHash)
        {
            byte[] input = System.Text.Encoding.ASCII.GetBytes(toHash);
            byte[] hash = md5.ComputeHash(input);
            var hex = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                hex.Append(hash[i].ToString("X2"));
            }
            return hex.ToString();
        }

        public static IEnumerable<IEnumerable<T>> QuickPerm<T>(this IEnumerable<T> set)
        {
            int N = set.Count();
            int[] a = new int[N];
            int[] p = new int[N];

            var yieldRet = new T[N];

            List<T> list = new List<T>(set);

            int i, j, tmp; // Upper Index i; Lower Index j

            for (i = 0; i < N; i++)
            {
                // initialize arrays; a[N] can be any type
                a[i] = i + 1; // a[i] value is not revealed and can be arbitrary
                p[i] = 0; // p[i] == i controls iteration and index boundaries for i
            }
            yield return list;
            //display(a, 0, 0);   // remove comment to display array a[]
            i = 1; // setup first swap points to be 1 and 0 respectively (i & j)
            while (i < N)
            {
                if (p[i] < i)
                {
                    j = i % 2 * p[i]; // IF i is odd then j = p[i] otherwise j = 0
                    tmp = a[j]; // swap(a[j], a[i])
                    a[j] = a[i];
                    a[i] = tmp;

                    //MAIN!

                    for (int x = 0; x < N; x++)
                    {
                        yieldRet[x] = list[a[x] - 1];
                    }
                    yield return yieldRet;
                    //display(a, j, i); // remove comment to display target array a[]

                    // MAIN!

                    p[i]++; // increase index "weight" for i by one
                    i = 1; // reset index i to 1 (assumed)
                }
                else
                {
                    // otherwise p[i] == i
                    p[i] = 0; // reset p[i] to zero
                    i++; // set new index value for i (increase by one)
                } // if (p[i] < i)
            } // while(i < N)
        }
    }
}
