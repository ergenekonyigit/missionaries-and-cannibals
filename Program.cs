using System;

namespace MissionariesAndCannibals
{
    class Program
    {
        static int initialMiss = 3;
        static int initialCann = 3;
        static int finishMiss = 0;
        static int finishCann = 0;
        static int select = 0;
        static bool flag = false;
        
        static void Main(string[] args)
        {
            Console.WriteLine("\n\tMissionaries and Cannibals Problem");
            print(" ", " ");
            solution();
            print(" ", " ");
        }

        static void print(string pass1, string pass2)
        {
            Console.WriteLine("\n");
            for (int i = 0; i < finishMiss; i++)
            {
                Console.Write(" M ");
            }

            for (int i = 0; i < finishCann; i++)
            {
                Console.Write(" C ");
            }

            if (!flag)
            {
                Console.Write("       ~~~~~WATER~~~~~< {0} , {1} >       ", pass1, pass2);
            }
            else
            {
                Console.Write("       < {0} , {1} >~~~~~WATER~~~~~       ", pass1, pass2);
            }

            for (int i = 0; i < initialMiss; i++)
            {
                Console.Write(" M ");
            }

            for (int i = 0; i < initialCann; i++)
            {
                Console.Write(" C ");
            }
        }

        static bool finish()
        {
            return (finishMiss == 3 && finishCann == 3) ? false : true;
        }

        static void solution()
        {
            while (finish())
            {
                if (!flag)
                {
                    switch (select)
                    {
                        case 1:
                            print("C", " ");
                            initialCann++;
                            break;
                        case 2:
                            print("M", "C");
                            initialCann++;
                            initialMiss++;
                            break;
                        default:
                            break;
                    }

                    if (((initialMiss - 2) >= initialCann) && ((finishMiss + 2) >= finishCann) || ((initialMiss - 2) == 0))
                    {
                        initialMiss -= 2;
                        select = 1;
                        print("M", "M");
                        flag = true;
                    }
                    else if (((initialCann - 2) < initialMiss) && ((finishMiss == 0) || ((finishCann + 2) <= finishMiss)) || (initialMiss == 0))
                    {
                        initialCann -= 2;
                        select = 2;
                        print("C", "C");
                        flag = true;
                    }
                    else if (((initialCann--) <= (initialMiss--)) && ((finishMiss++) >= (finishCann++)))
                    {
                        initialCann -= 1;
                        initialMiss -= 1;
                        select = 3;
                        print("M", "C");
                        flag = true;
                    }
                }
                else
                {
                    switch (select)
                    {
                        case 1:
                            print("M", "M");
                            finishMiss += 2;
                            break;
                        case 2:
                            print("C", "C");
                            finishCann += 2;
                            break;
                        case 3:
                            print("M", "C");
                            finishCann += 1;
                            finishMiss += 1;
                            break;
                        default:
                            break;
                    }

                    if (finish())
                    {
                        if (((finishCann > 1 && finishMiss == 0) || initialMiss == 0))
                        {
                            finishCann--;
                            select = 1;
                            print("C", " ");
                            flag = false;
                        }
                        else if ((initialCann + 2) > initialMiss)
                        {
                            finishCann--;
                            finishMiss--;
                            select = 2;
                            print("M", "C");
                            flag = false;
                        }
                    }
                }
            }
        }
    }
}
