namespace HabitLogger;
using static HabitLogger.HabitRepository;

class InputLoop
{
    public static void GetUserInput()
    {
        Console.Clear();
        bool closeApp = false;

        while (closeApp == false)
        {
            Console.WriteLine("\n\nMAIN MENU");
            Console.WriteLine("\nWhat would you like to do?");
            Console.WriteLine("\nType 0 to Close Application.");
            Console.WriteLine("\nType 1 to View All Records.");
            Console.WriteLine("\nType 2 to Insert new habit.");
            Console.WriteLine("\nType 3 to Delete a habit.");
        
        
            string userInput = Console.ReadLine();
    
            switch (userInput)
            {
                case "0":
                    closeApp = true;
                    break;
                case "1":
                    GetAllRecords();
                    break;
                case "2":
                    Insert();
                    break;
                case "3":
                    Delete();
                    break;
                default:
                    Console.WriteLine("\nInvalid Command. Please type a number from 0 to 4.\n");
                    break;
            }
        
        }

    }    
}