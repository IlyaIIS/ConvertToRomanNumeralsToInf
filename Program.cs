using System;
using System.Collections.Generic;

namespace ConvertToRomanNumerals
{
    class Program
    {
        static void Main(string[] args)
        {
            string imput = Console.ReadLine();

            Console.WriteLine(ConvertToRome(imput));
        }

        static Char[] listDigits = { 'I', 'V', 'X', 'L', 'C', 'D', 'M', '-' };

        static string ConvertToRome(string str)
        {
            string output = "";
            int rank = str.Length * 2 - 1;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '1') { output += listDigits[rank - 1]; }
                if (str[i] == '2') { output += listDigits[rank - 1]; output += listDigits[rank - 1]; }
                if (str[i] == '3') { output += listDigits[rank - 1]; output += listDigits[rank - 1]; output += listDigits[rank - 1]; }
                if (str[i] == '4') { output += listDigits[rank - 1]; output += listDigits[rank]; }
                if (str[i] == '5') { output += listDigits[rank]; }
                if (str[i] == '6') { output += listDigits[rank]; output += listDigits[rank - 1]; }
                if (str[i] == '7') { output += listDigits[rank]; output += listDigits[rank - 1]; output += listDigits[rank - 1]; }
                if (str[i] == '8') { output += listDigits[rank]; output += listDigits[rank - 1]; output += listDigits[rank - 1]; output += listDigits[rank - 1]; }
                if (str[i] == '9') { output += listDigits[rank - 1]; output += listDigits[rank + 1]; }

                rank -= 2;
            }
            return output;
        }































        /*
        static Dictionary<char, int> dictDigits = new Dictionary<char, int>
          { { 'I', 1 },
            { 'V', 2 },
            { 'X', 3 },
            { 'L', 4 },
            { 'C', 5 },
            { 'D', 6 },
            { 'M', 7 },
            { '-', 8 } };
        
        static string ConvertFromRome(string str)
        {
            string local = "";

            for (int i = 0; i < str.Length; i++)
            {
                if (i != str.Length - 1)
                {
                    if (dictDigits[str[i + 1]] - dictDigits[str[i]] == 1)
                    {
                        if (dictDigits[str[i]] % 2 == 1)
                        local += '9';
                        i++;
                        continue;
                    }

                    if (dictDigits[str[i + 1]] - dictDigits[str[i]] == 1)
                    {
                        local += '4';
                        i++;
                        continue;
                    }

                    if (dictDigits[str[i + 1]] - dictDigits[str[i]] == 0)
                    {
                        local += '2';
                        i++;
                        continue;
                    }
                }

                if (i != str.Length - 2)
                {
                    if (dictDigits[str[i + 1]] - dictDigits[str[i]] + dictDigits[str[i + 2]] == dictDigits[str[i + 2]])
                    {
                        local += '3';
                        i += 2;
                        continue;
                    }

                    if (-dictDigits[str[i + 1]] - dictDigits[str[i + 2]] + dictDigits[str[i]] == dictDigits[str[i]])
                    {
                        local += '7';
                        i += 2;
                        continue;
                    }

                    if (dictDigits[str[i]] - dictDigits[str[i - 1]] == 1)
                    {
                        local += '6';
                        i += 2;
                        continue;
                    }
                }

                if (i != str.Length - 3)
                {
                    if (dictDigits[str[i + 1]] - dictDigits[str[i + 2]] - dictDigits[str[i + 3]] + dictDigits[str[i]] == 1)
                    {
                        local += '8';
                        i += 3;
                        continue;
                    }
                }

                local += '1';
                
            }

            return local;
        }*/
    }
}
