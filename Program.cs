using System;
using System.Collections.Generic;

namespace ConvertToRomanNumerals
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите число: ");
            string imput = Console.ReadLine();

            Console.Write("Результат: ");

            if (Char.IsDigit(imput[0])) Console.WriteLine(ConvertToRome(imput));

            if (Char.IsLetter(imput[0])) Console.WriteLine(ConvertFromRome(imput));
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
            string output = "";
            int rank = 0;

            for (int i = str.Length - 1; i >= 0; i--)
            {
                if (i >= 3)
                {
                    if (dictDigits[str[i]] == dictDigits[str[i - 1]] && dictDigits[str[i]] == dictDigits[str[i - 2]] &&
                        dictDigits[str[i]] - dictDigits[str[i - 3]] == -1)
                    {
                        output = output.Insert(0, "8");
                        i -= 3;
                        rank += 2;
                        continue;
                    }
                }

                if (i >= 2)
                {
                    if (dictDigits[str[i]] == dictDigits[str[i - 1]] && dictDigits[str[i]] - dictDigits[str[i - 2]] == -1)
                    {
                        output = output.Insert(0, "7");
                        i -= 2;
                        rank += 2;
                        continue;
                    }
                    if (dictDigits[str[i]] == dictDigits[str[i - 1]] && dictDigits[str[i]] == dictDigits[str[i - 2]])
                    {
                        output = output.Insert(0, "3");
                        i -= 2;
                        rank += 2;
                        continue;
                    }
                }

                if (i >= 1)
                {
                    if (dictDigits[str[i]] - dictDigits[str[i - 1]] == 2)
                    {
                        output = output.Insert(0, "9");
                        i--;
                        rank += 2;
                        continue;
                    }

                    if (dictDigits[str[i]] - dictDigits[str[i - 1]] == 1)
                    {
                        output = output.Insert(0, "4");
                        i--;
                        rank += 2;
                        continue;
                    }

                    if (dictDigits[str[i]] - dictDigits[str[i - 1]] == -1)
                    {
                        output = output.Insert(0, "6");
                        i--;
                        rank += 2;
                        continue;
                    }

                    if (dictDigits[str[i]] == dictDigits[str[i - 1]])
                    {
                        output = output.Insert(0, "2");
                        i--;
                        rank += 2;
                        continue;
                    }
                }
                if (dictDigits[str[i]] - rank == 1 )
                    output = output.Insert(0, "1");
                else
                    output = output.Insert(0, "5");

                rank += 2;
            }

            if ((dictDigits[str[str.Length - 1]] - 1) % 2 == 0)
                for (int i = (dictDigits[str[str.Length - 1]] - 1) / 2; i > 0; i--)
                    output += "0";
            else
                for (int i = (dictDigits[str[str.Length - 1]] - 2) / 2; i > 0; i--)
                    output += "0";

            return output;
        }
    }
}
