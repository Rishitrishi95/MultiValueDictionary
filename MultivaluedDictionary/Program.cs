using System;

namespace MultivaluedDictionary
{
    class Program
    {
        public static MultiValueDictionary multiValueDict = new MultiValueDictionary();
        static void Main(string[] args)
        {
            Console.WriteLine("Multi-Value Dictionary.");
            Console.WriteLine("Type commands followed by 'ENTER'");
            Console.WriteLine("Type Exit to Terminate");
            Console.WriteLine();
            try
            {
                HandleInput();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public static void HandleInput()
        {
            
            while (true)
            {
                Console.Write(">");
                string? userInput = Console.ReadLine()?.Trim();

                if (!String.IsNullOrWhiteSpace(userInput))
                {
                    try
                    {
                        HandleUserInput(userInput);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Invalid Command.");
                        //throw;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Command.");
                }
            }

        }

        public static void HandleUserInput(string userInput)
        {
            string[] cmdItems = userInput.Split(' ');

            switch (cmdItems[0].ToUpper())
            {
                case "ADD":
                    if (cmdItems.Count() == 3)
                    {
                        Console.WriteLine(multiValueDict.Add(cmdItems[1], cmdItems[2]));
                    }
                    else
                    {
                        Console.WriteLine("Invalid Command.");
                    }
                    break;
                case "KEYS":
                    Console.WriteLine(multiValueDict.Keys());
                    break;
                case "ALLMEMBERS":
                    Console.WriteLine(multiValueDict.AllMembers());
                    break;
                case "MEMBERS":
                    if (cmdItems.Count() == 2)
                    {
                        Console.WriteLine(multiValueDict.Members(cmdItems[1]));
                    }
                    else
                    {
                        Console.WriteLine("Invalid Command.");
                    }
                    break;
                case "REMOVE":
                    if (cmdItems.Count() == 3)
                    {
                        Console.WriteLine(multiValueDict.Remove(cmdItems[1], cmdItems[2]));
                    }
                    else
                    {
                        Console.WriteLine("Invalid Command.");
                    }
                    break;
                case "REMOVEALL":
                    if (cmdItems.Count() == 2)
                    {
                        Console.WriteLine(multiValueDict.Remove(cmdItems[1]));
                    }
                    else
                    {
                        Console.WriteLine("Invalid Command.");
                    }
                    break;
                case "CLEAR":
                    multiValueDict.Clear();
                    Console.WriteLine("Cleared.");
                    break;
                case "KEYEXISTS":
                    if (cmdItems.Count() == 2)
                    {
                        Console.WriteLine(multiValueDict.KeyExists(cmdItems[1]));
                    }
                    else
                    {
                        Console.WriteLine("Invalid Command.");
                    }
                    break;
                case "MEMBEREXISTS":
                    if (cmdItems.Count() == 3)
                    {
                        Console.WriteLine(multiValueDict.MemberExists(cmdItems[1], cmdItems[2]));
                    }
                    else
                    {
                        Console.WriteLine("Invalid Command.");
                    }
                    break;
                case "ITEMS":
                    Console.WriteLine(multiValueDict.PrintAllItems());
                    break;
                case "BATCHPROCESS":
                    if (cmdItems.Count() == 2)
                    {
                        HandleBatchProcess(cmdItems[1]);
                    }
                    else
                    {
                        Console.WriteLine("Invalid Command.");
                    }
                    
                    break;
                case "EXIT":
                    ExitConsoleApp();
                    break;
                default:
                    Console.WriteLine("Invalid Command.");
                    break;
            }
        }

        public static void HandleBatchProcess(string filePath)
        {
            if(!string.IsNullOrWhiteSpace(filePath))
            {
                string[] lines = System.IO.File.ReadAllLines(filePath);
                foreach(string line in lines)
                {
                    HandleUserInput(line);
                }
            }
        }

        public static void ExitConsoleApp()
        {
            Console.WriteLine("Are you sure you want to exit the app?(Yes or No):");
            string? resp = Console.ReadLine();
            if (string.Equals(resp,"yes",StringComparison.OrdinalIgnoreCase))
            {
                Environment.Exit(0);
            }
            else if (string.Equals(resp, "no", StringComparison.OrdinalIgnoreCase))
            {
                return;
            }
            else
            {
                Console.WriteLine("Invalid option for exiting console application");
                ExitConsoleApp();
            }
        }
    }
}