

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
namespace Calculator
{
    class Program
    {
        public static void Main(string[] args)
        {
            startpoint:
            Console.WriteLine("Enter your mathematical phrase please");
            String phrase = Console.ReadLine();
            while (!(phrase == "finish"))
            {
                if (phrase == "history")
                {
                    string path = @"D:\work\p1_calculator\calculator\calculator\bin\Debug\netcoreapp3.1\results.txt";
                    if (File.Exists(path))
                    {
                        Console.Write(File.ReadAllText(path));
                    }
                    else {
                        Console.WriteLine("No history found");
                    }
                }
                else
                {
                    char[] operators = { '+', '-', '*', '/' };
                    String[] splitedList = phrase.Split(operators);
                    ArrayList numbersList = new ArrayList();
                    for (int i = 0; i < splitedList.Length; i++)
                    {
                        numbersList.Add(splitedList[i]);
                    }

                    ArrayList operatorsList = new ArrayList();
                    int j = 0;

                    for (int i = 0; i < phrase.Length; i++)
                    {
                        if (phrase[i] == '*' || phrase[i] == '/' || phrase[i] == '+' || phrase[i] == '-')
                        {
                            operatorsList.Add(phrase[i]);
                            j++;
                        }
                    }
                    for (int i = 0; i < operatorsList.Count; i++)
                    {
                        if (char.Parse(operatorsList[i].ToString()) == '*')
                        {
                            int res = Int32.Parse(numbersList[i].ToString()) * Int32.Parse(numbersList[i + 1].ToString());
                            numbersList[i + 1] = res.ToString();
                            operatorsList.RemoveAt(i);
                            numbersList.RemoveAt(i);
                            i--;
                        }
                        else if (char.Parse(operatorsList[i].ToString()) == '/')
                        {
                            if (Int32.Parse(numbersList[i + 1].ToString()) == 0)
                            {
                                Console.WriteLine("divide to 0 is not allowed");
                                goto startpoint;
                            }
                            int res = Int32.Parse(numbersList[i].ToString()) / Int32.Parse(numbersList[i + 1].ToString());
                            numbersList[i + 1] = res.ToString();
                            operatorsList.RemoveAt(i);
                            numbersList.RemoveAt(i);
                            i--;
                        }
                    }
                    for (int i = 0; i < operatorsList.Count; i++)
                    {
                        if (char.Parse(operatorsList[i].ToString()) == '+')
                        {
                            int res = Int32.Parse(numbersList[i].ToString()) + Int32.Parse(numbersList[i + 1].ToString());
                            numbersList[i + 1] = res.ToString();
                            operatorsList.RemoveAt(i);
                            numbersList.RemoveAt(i);
                            i--;
                        }
                        else if (char.Parse(operatorsList[i].ToString()) == '-')
                        {
                            int res = Int32.Parse(numbersList[i].ToString()) - Int32.Parse(numbersList[i + 1].ToString());
                            numbersList[i + 1] = res.ToString();
                            operatorsList.RemoveAt(i);
                            numbersList.RemoveAt(i);
                            i--;
                        }
                    }
                    int result = Int32.Parse(numbersList[0].ToString());
                    String finalResult = numbersList[0].ToString() + "=" + phrase;
                    Console.WriteLine(result);
                    string path = @"D:\work\p1_calculator\calculator\calculator\bin\Debug\netcoreapp3.1\results.txt";
                    if (File.Exists(path))
                    {
                        using (StreamWriter sw = File.AppendText(path))
                        {
                            sw.WriteLine(Environment.NewLine);
                            sw.WriteLine(finalResult);
                        }
                    }
                    else
                    {
                        File.WriteAllText("results.txt", finalResult);
                    }

                }
                Console.WriteLine("Enter a new mathematical phrase please");
                phrase = Console.ReadLine();
            }
            return;

        }
    }

}
