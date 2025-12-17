using System;
using System.Diagnostics.Metrics;

namespace Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //  Simple Calculator
            //  Create a console application that acts as a simple calculator.
            //  This console application must keep running until the user decides to exit on their own.
            //  It should take in two numbers and an operator and provide the result. 
            //  Operators to include:
            //      Add 
            //      Subtract
            //      Multiple
            //      Divide
            //  Implement input validation and error handling.
            //      The calculator can only take in numbers and if it’s not a number have it catch the error and print to the screen that they must enter numbers only.
            //      It must catch the divide by zero error and notify the user.

            bool running = true;

            while (running)
            {
                // These should be reset at the start of each calculation.
                char calculationType = '\0';
                double numA = 0;
                double numB = 0;
                double output = 0;
                int parsedNum = 0;
                string userInput;
                bool validInput = false;

                Console.WriteLine("Which type of calculation would you like to do today?" +
                                 "\nPlease respond with + for Addition" +
                                 "\nPlease respond with - for Subtraction" +
                                 "\nPlease respond with * for Multiplication" +
                                 "\nPlease respond with / for Division");

                do
                {
                    userInput = Console.ReadLine();
                    try
                    {
                        calculationType = char.Parse(userInput);
                        switch (calculationType)
                        {
                            case '+':
                            case '-':
                            case '*':
                            case '/':
                                validInput = true;
                                break;
                            default:
                                Console.WriteLine("Please enter a valid operation.");
                                break;
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Please enter a valid operation.");
                    }
                } while (!validInput);
                validInput = false;


                Console.WriteLine("Enter the first number.");
                do
                {
                    userInput = Console.ReadLine();
                    try
                    {
                        numA = double.Parse(userInput);
                        validInput = true;
                    }
                    catch
                    {
                        Console.WriteLine("Please enter a valid number.");
                    }
                } while (!validInput);
                validInput = false;

                Console.WriteLine("Enter the second number.");
                do
                {
                    userInput = Console.ReadLine();
                    try
                    {
                        numB = double.Parse(userInput);
                        if (numB == 0 && calculationType == '/')
                        {
                            Console.WriteLine("Invalid Operation: Divide by 0 error." +
                                "\nPlease enter a valid second number.");
                            continue;
                        }
                        else
                        {
                            validInput = true;
                            switch (calculationType)
                            {
                                // this is honestly a silly implementation of methods IMO, as none of the work done is duplicated, but i felt like including it just 
                                case '+':
                                    output = numA + numB;
                                    break;
                                case '-':
                                    output = numA - numB;
                                    break;
                                case '*':
                                    output = numA * numB;
                                    break;
                                case '/':
                                    output = numA / numB;
                                    break;
                            }
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Please enter a valid second number.");
                    }
                } while (!validInput);
                validInput = false;

                Console.WriteLine($"The final value is: {output}" +
                                "\n\n" +
                                "Would you like to do another calculation?" +
                                "\n1. Yes" +
                                "\n2. No");
                do
                {
                    userInput = Console.ReadLine();
                    try
                    {
                        parsedNum = int.Parse(userInput);

                        if (parsedNum == 2)
                        {
                            validInput = true;
                            running = false;
                        }
                        else if (parsedNum == 1)
                        {
                            validInput = true;
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Please enter a valid choice.");
                    }
                } while (!validInput);
            }
            Console.WriteLine($"Hit any key to exit!");
            Console.ReadKey();
        }


        // App isnt big enough to warrent OOP class seperation IMO
        static double Add(double numA, double numB)
        {
            return numA + numB;
        }

        static double Subtract(double numA, double numB)
        {
            return numA - numB;
        }

        static double Multiply(double numA, double numB)
        {
            return numA * numB;
        }

        static double Divide(double numA, double numB)
        {
            return numA / numB;
        }
    }
}
