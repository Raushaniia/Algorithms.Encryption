using System;
using System.IO;
using System.Text;

namespace Encryption
{
    class Program
    {
        static void Main(string[] args)
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            string s = Console.ReadLine();

            string result = encryption(s);
            var ss = result;
            textWriter.WriteLine(result);

            textWriter.Flush();
            textWriter.Close();
        }

        // Complete the encryption function below.
        static string encryption(string s)
        {
            s = s.Replace(" ", "");
            int length = s.Length;
            int row = (int)Math.Round(Math.Sqrt(length));
            int column = Math.Sqrt(length) > row ? row + 1 : row;

            int index = 0;
            char[,] matrix = new char[row, column];
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    if (index < s.Length)
                    {
                        matrix[i, j] = s[index];
                        index++;
                    }
                }
            }

            StringBuilder result = new StringBuilder();
            index = 0;
            for (int i = 0; i < column; i++)
            {
                for (int j = 0; j < row; j++)
                {
                    result.Append(matrix[j, i]);
                    index++;
                }

                result.Append(" ");
            }

            string resultString = result.ToString().Trim(' ').Replace("\0", "");
            return resultString;
        }
    }
}
