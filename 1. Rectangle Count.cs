using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        public int[,] Matrix=new int[200,200];
        public int m, n, CountRects;
        static void Main(string[] args)
        {
            Program p = new Program();
            p.StartProgram();
            Console.ReadKey();
        }
        public void StartProgram()
        {
            InputMatrix();
            FindRects();
            if (CountRects==1)
                Console.WriteLine("There is 1 rectangle.");
            else
                Console.WriteLine("There are " + CountRects +  " rectangles.\n");
            PrintRects();
        }
        public void InputMatrix()
        {
            Console.WriteLine("Enter the matrix size");
            m = Convert.ToInt32(Console.ReadLine());
            n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the values of each element");
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    int inputKey = Console.ReadKey().KeyChar - 48;
                    if (inputKey != 0 && inputKey != 1)
                    {
                        j--;
                        Console.Write("\b \b");
                        continue;
                    }
                    Matrix[i, j] = inputKey;
                    Console.Write("\t");
                }
                Console.Write("\n");
            }
        }
        public void FindRects()
        {
            for (int i = 0; i < m - 2; i++)   //Checking row by row
            {
                for (int j = 0; j < n - 2; j++) //Checking column by column
                {
                    if (Matrix[i, j] == 1 && Matrix[i, j + 1] == 1 && Matrix[i + 1, j] == 1)  //top-left corner found
                    {
                        for (int l = j + 2; l < n; l++) //Looking for a straight line of more than 3 length
                        {
                            if (Matrix[i, l] == 1 && Matrix[i + 1, l] == 1) //Checking for a top-right corner
                            {
                                int k;
                                //Down the matrix
                                for (k = i + 2; k <= m && Matrix[k, j] != 0 && Matrix[k, l] != 0; k++)
                                {
                                    //Bottom line check
                                    if (Matrix[k, j + 1] == 1 && Matrix[k, l - 1] == 1)
                                    {
                                        int p;
                                        for (p = j + 1; p < l; p++)
                                        {
                                            if (Matrix[k, p] == 0)
                                                break;
                                        }
                                        if (p == l)
                                            if (CheckRect(i, j, k, l))
                                                CountRects++;
                                    }
                                }
                            }
                            if (Matrix[i, l] == 0)
                                break;
                        }
                    }
                }
            }
        }
        public bool CheckRect(int x1,int y1,int x2, int y2)
        {
            //Checking boundaries : OPTIONAL : DELETE after no errors
            //for (int i = x1; i <= x2; i++)
            //{
            //    if (Matrix[i, y1] != 1)
            //        Console.WriteLine("It was not even a rectangle!!");
            //    if (Matrix[i, y2] != 1)
            //        Console.WriteLine("It was not even a rectangle!!");
            //}
            //for (int i = y1; i <= y2; i++)
            //{
            //    if (Matrix[x1, i] != 1)
            //        Console.WriteLine("It was not even a rectangle!!");
            //    if (Matrix[x2, i] != 1)
            //        Console.WriteLine("It was not even a rectangle!!");
            //}

            //Checking for 0's
            for (int i = x1 + 1; i <= x2 - 1; i++)
                for (int j = y1 + 1; j <= y2 - 1; j++)
                    if (Matrix[i, j] == 0)
                    {
                        //Console.WriteLine("x1 = " + x1 + ", y1 = " + y1 + ", x2 = " + x2 + ", y2 = " + y2);
                        return true;
                    }
            return false;
        }
        public void PrintRects()
        {
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)

                    if (Matrix[i, j] == 1)
                        Console.Write("▓▓");
                    else
                        Console.Write("  ");
                Console.WriteLine("");
            }
        }
    }
}
