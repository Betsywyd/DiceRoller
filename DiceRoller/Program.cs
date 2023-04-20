using System.Numerics;
using System;
using System.Runtime.InteropServices;

namespace DiceRoller
{
    public class Program
    {
        static void Main()
        {
            Console.WriteLine("Welcome to the Grand Circus Casino!");
            Console.Write("How many sides should each dice have? ");
            int sides = EnterValue();
            Console.WriteLine();
            bool goOn=true;
            int roll = 1;
            do
            {
                Console.WriteLine($"Roll {roll}:");
                int rand1 = CreateRandonNum(sides);
                int rand2 = CreateRandonNum(sides);
                int total= rand1 + rand2;
                Console.WriteLine($"You rolled a {rand1} and a {rand2} (Total is {total})");
                if (sides ==6) 
                {
                    string str1 =IndividulVale(rand1, rand2);
                    string str2 = TotalValue(rand1, rand2);
                    if (str1 !=""&&str2!="")
                    {
                        Console.WriteLine(TotalValue(rand1, rand2));
                        Console.WriteLine(IndividulVale(rand1, rand2));
                        Console.WriteLine();
                    }
                    
                    else
                    {
                     Console.WriteLine(TotalValue(rand1, rand2));
                     Console.WriteLine(IndividulVale(rand1, rand2));
                    }
                   
                }
                
                goOn = Continue();
                roll++;

            } while (goOn == true);

            }

        public static bool Continue()
        {
            Console.WriteLine("Roll again? (y/n):");
            bool check = true;
            do
            {
                string input = Console.ReadLine().ToLower().Trim();

                try
                {

                    if (input == "y")
                    {
                        check = false;
                        return true;
                    }
                    else if (input == "n")
                    {
                        Console.WriteLine("Thanks for playing!");
                        check = false;
                        return false;
                    }
                    else
                    {
                       
                        throw new Exception("Enterd a wrong word, please input again (y/n)");
                        
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    continue;

                }
            } while (check == true);
            return Continue();
        }



        public static int CreateRandonNum(int input)
        {
            Random rand = new Random();
            int num = rand.Next(1, input+1);
            return num;
        }

        public static int EnterValue()
        {

            int value = 0;
            bool check = true;
            do
            {
                try
                {

                    value = int.Parse(Console.ReadLine());
                    if (value < 0)
                    {

                        throw new Exception("That value is not in the range, please inter a positive number :");
                    }
                    else
                    {
                        check = false;
                    }
                    return value; 
                }
                

            catch (FormatException)
            {
                Console.WriteLine("That was not a valid input please input a positive number,let's try again:");
                return EnterValue();

            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return EnterValue();
            }
            } while (check == true);
           
        }

        public static string IndividulVale(int value1, int value2)
        {   
          
            if (value1 == 1 && value2 == 1)
            {
                return "Snake Eyes!";
            }
            else if ((value1 == 1 && value2 == 2) || (value1 == 2 && value2 == 1))
            {
                return "Ace Deuce!";
            }
            else if (value1 == 6 && value2 == 6)
            {
                return "Box Cars!";
            }

            else
            {
                return "";
            }
        }

        public static string TotalValue(int value1, int value2)
        {
            int total = value1 + value2;
            if(total==7||total==11)
            {
                return "Win!";
            }
            else if(total == 2 || total == 3 | total == 12)
            {
                return "Craps!";
            }
            else 
            {
                return "";
            }

        }
    }
}
