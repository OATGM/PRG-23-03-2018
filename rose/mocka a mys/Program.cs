using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace mocka_a_mys
{
    class Program
    {
        static int[,] pole = new int[16, 16], cat = new int[16, 16], mouse = new int[16, 16];
        static int turncount = 0, turn = 1, j = 0, error = 0, stop = 0, catx = 0, caty = 0, mousex = 0, mousey = 0;
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.GetEncoding(1252);
            Program program = new Program();
            Random rnd = new Random();
            catx = rnd.Next(1,14);
            caty = rnd.Next(1, 14);
            mousex = rnd.Next(1, 14);
            mousey = rnd.Next(1, 14);
            if (catx == mousex)
            {
                if (caty == mousey)
                {
                    stop = 1;
                }
            }
            for (int i = 0; i < 15; i++)
            {
                while (j <= 15)
                {
                    pole[i, j] = 0;
                    j++;
                }
                j = 0;
            } // prefill 0
            pole[caty, catx] = 3;
            pole[mousey, mousex] = 2;
            for (int i = 0; i < 15; i++)
            {
                while(j <= 15)
                {
                    pole[0, j] = 1;
                    pole[15, j] = 1;
                    pole[i, 0] = 1;
                    pole[i, 15] = 1;
                    j++;
                }
                j = 0;
            } // border
           program.Move();
            while (stop != 1)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                if (turn == 0)
                {
                    if (keyInfo.Key == ConsoleKey.UpArrow)
                    {
                        pole[mousey, mousex] = 0;
                        mousey--;
                        if (pole[mousey, mousex] != 0)
                        {
                            error = 1;
                            mousey++;
                        }
                        else
                        {
                            error = 0;
                            turncount ++;
                        }
                        pole[mousey, mousex] = 2;
                        program.Move();
                    }
                    else if (keyInfo.Key == ConsoleKey.LeftArrow)
                    {
                        pole[mousey, mousex] = 0;
                        mousex--;
                        if (pole[mousey, mousex] != 0)
                        {
                            error = 1;
                            mousex++;
                        }
                        else
                        {
                            error = 0;
                            turncount++;
                        }
                        pole[mousey, mousex] = 2;
                        program.Move();
                    }
                    else if (keyInfo.Key == ConsoleKey.DownArrow)
                    {
                        pole[mousey, mousex] = 0;
                        mousey++;
                        if (pole[mousey, mousex] != 0)
                        {
                            error = 1;
                            mousey--;
                        }
                        else
                        {
                            error = 0;
                            turncount++;
                        }
                        pole[mousey, mousex] = 2;
                        program.Move();
                    }
                    else if (keyInfo.Key == ConsoleKey.RightArrow)
                    {
                        pole[mousey, mousex] = 0;
                        mousex++;
                        if (pole[mousey, mousex] != 0)
                        {
                            error = 1;
                            mousex--;
                        }
                        else
                        {
                            error = 0;
                            turncount++;
                        }
                        pole[mousey, mousex] = 2;
                        program.Move();
                    }
                    else if (keyInfo.Key == ConsoleKey.Escape)
                    {
                        stop = 1;
                    }
                } // mouse moveing
                else if (turn == 1)
                {
                    if (keyInfo.Key == ConsoleKey.UpArrow)
                    {
                        pole[caty, catx] = 5;
                        caty--;
                        if (pole[caty, catx] != 0)
                        {
                            if (pole[caty, catx] == 2)
                            {
                                error = 2;
                            }
                            else
                            {
                                error = 1;
                                caty++;
                            }
                        }
                        else error = 0; 
                        pole[caty, catx] = 3;
                        program.Move();
                    }
                    else if (keyInfo.Key == ConsoleKey.LeftArrow)
                    {
                        pole[caty, catx] = 5;
                        catx--;
                        if (pole[caty, catx] != 0)
                        {
                            if (pole[caty, catx] == 2)
                            {
                                error = 2;
                            }
                            else
                            {
                                error = 1;
                                caty++;
                            }
                        }
                        else error = 0;
                        pole[caty, catx] = 3;
                        program.Move();
                    }
                    else if (keyInfo.Key == ConsoleKey.DownArrow)
                    {
                        pole[caty, catx] = 5;
                        caty++;
                        if (pole[caty, catx] != 0)
                        {
                            if (pole[caty, catx] == 2)
                            {
                                error = 2;
                            }
                            else
                            {
                                error = 1;
                                caty++;
                            }
                        }
                        else error = 0;
                        pole[caty, catx] = 3;
                        program.Move();
                    }
                    else if (keyInfo.Key == ConsoleKey.RightArrow)
                    {
                        pole[caty, catx] = 5;
                        catx++;
                        if (pole[caty, catx] != 0)
                        {
                            if (pole[caty, catx] == 2)
                            {
                                error = 2;
                            }
                            else
                            {
                                error = 1;
                                caty++;
                            }
                        }
                        else error = 0;
                        pole[caty, catx] = 3;
                        program.Move();
                    }
                    else if (keyInfo.Key == ConsoleKey.Escape)
                    {
                        stop = 1;
                    }
                } // cat moveing
                else if (turn == 2)
                {
                    stop = 1;
                }

            }
        }
        public void Move()
        {
            Console.Clear();
            for (int i = 0; i < 16; i++)
            {
                while (j < 16)
                {
                    if (pole[i, j] == 0)
                    {
                        Console.Write(" ");
                    }
                    else if (pole[i, j] == 1)
                    {
                        Console.Write("*");
                    }
                    else if (pole[i, j] == 2)
                    {
                        Console.Write("X");
                    }
                    else if (pole[i, j] == 3)
                    {
                        Console.Write("O");
                    }
                    else if (pole[i, j] == 5)
                    {
                        Console.Write("+");
                    }
                    j++;
                }
                j = 0;
                Console.Write("\n");
            } // drawing
            // cat block
            if (pole[caty - 1, catx] != 0 && pole[caty, catx - 1] != 0 && pole[caty + 1, catx] != 0 && pole[caty, catx + 1] != 0)
            {
                error = 3;
            }
            // cat block by mouse protection
            else if (pole[caty - 1, catx] == 2 && pole[caty, catx - 1] == 2 && pole[caty + 1, catx] == 2 && pole[caty, catx + 1] == 2)
            {
                error = 0;
            }
            // mouse block
            if (pole[mousey - 1, mousex] != 0 && pole[mousey, mousex - 1] != 0 && pole[mousey + 1, mousex] != 0 && pole[mousey, mousex + 1] != 0)
            {
                error = 2;
            }
            if (error == 1) Console.WriteLine("\nError: Invalid move."); // error move
            else if (error == 2)
            {
                Console.WriteLine("\nGAME OVER Cat WIN | Mouse's score {0}\nPress any button to Quit.", turncount);
                turn = 2;
            } // cat win + score
            else if (error == 3)
            {
                Console.WriteLine("\nGAME OVER Mouse WIN\nPress any button to Quit.");
                turn = 2;
            } // mouse win
            else if (turn == 0)
            {
                turn = 1;
                Console.WriteLine("\nCat's turn");
            } // turn swap
            else if (turn == 1)
            {
                turn = 0;
                Console.WriteLine("\nMouse's turn");
            } // turn swap
        }
    }
}
