using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DynamicArray
{
    class Program
    {
        
        
        static void Main(string[] args)
        {
            //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

            int n = Convert.ToInt32(firstMultipleInput[0]);

            int q = Convert.ToInt32(firstMultipleInput[1]);

            List<List<int>> queries = new List<List<int>>();

            for (int i = 0; i < q; i++)
            {
                queries.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(queriesTemp => Convert.ToInt32(queriesTemp)).ToList());
            }

            List<int> result = Program.DynamicArray(n, queries);

            Console.WriteLine(String.Join("\n", result));
            Console.ReadLine();
            //textWriter.Flush();
            //textWriter.Close();
        }
        public static List<int> DynamicArray(int n, List<List<int>> queries)
        {
            List<int> result= new List<int>();
            List<List<int>> seqlist = new List<List<int>>();
            for (int i = 0; i < n; i++)
            {
                seqlist.Add(new List<int>());
            }
            List<int> seq = new List<int>();
            int lastAnswer = 0;
            foreach(var list in queries)
            {
                if(list[0] ==1)
                {
                    //int rowIndex = (list[1] ^ lastAnswer) % n;
                    seq = seqlist[(list[1] ^ lastAnswer) % n];
                    seq.Add(list[2]);

                }
                if (list[0] == 2)
                {
                    //int rowIndex = (list[1] ^ lastAnswer) % n;
                    seq = seqlist[(list[1] ^ lastAnswer) % n];
                    //int colIndex = list[2] % seq.Count;
                    lastAnswer = seq[list[2] % seq.Count];
                    result.Add(lastAnswer);
                }
            }
           
            return result;

        }
       

    }
}
