using System;

namespace MultivaluedDictionary
{
    class Program
    {
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
            var multiValueDict = new MultiValueDictionary();
            while (true)
            {
                Console.Write(">");
                string? userInput = Console.ReadLine();
                if (!String.IsNullOrWhiteSpace(userInput))
                {
                    try
                    {
                        string[] cmdItems = userInput.Split(' ');

                        switch (cmdItems[0].ToUpper())
                        {
                            case "ADD":
                                Console.WriteLine(multiValueDict.Add(cmdItems[1], cmdItems[2]));
                                break;
                            case "KEYS":
                                Console.WriteLine(multiValueDict.Keys());
                                break;
                            case "ALLMEMBERS":
                                Console.WriteLine(multiValueDict.AllMembers());
                                break;
                            case "MEMBERS":
                                Console.WriteLine(multiValueDict.Members(cmdItems[1]));
                                break;
                            case "REMOVE":
                                Console.WriteLine(multiValueDict.Remove(cmdItems[1], cmdItems[2]));
                                break;
                            case "REMOVEALL":
                                Console.WriteLine(multiValueDict.Remove(cmdItems[1]));
                                break;
                            case "CLEAR":
                                multiValueDict.Clear();
                                Console.WriteLine("Cleared.");
                                break;
                            case "KEYEXISTS":
                                Console.WriteLine(multiValueDict.KeyExists(cmdItems[1]));
                                break;
                            case "MEMBEREXISTS":
                                Console.WriteLine(multiValueDict.MemberExists(cmdItems[1],cmdItems[2]));
                                break;
                            case "ITEMS":
                                Console.WriteLine(multiValueDict.PrintAllItems());
                                break;
                            case "EXIT":
                                ExitConsoleApp();
                                break;
                            default:
                                Console.WriteLine("Invalid Command.");
                                break;
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Invalid Command.");
                        //throw;
                    }
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