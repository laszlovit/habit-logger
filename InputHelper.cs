using System.Globalization;
using static HabitLogger.InputLoop;

namespace HabitLogger;

public class InputHelper
{
    public static string GetDateInput()
    {
        Console.WriteLine("\n\nPlease insert the date: (Format: dd-mm-yyyy). Type 0 to return to main menu.\n\n");

        string dateInput = Console.ReadLine();

        if (dateInput == "0")
        {
            GetUserInput();
        }
        
        while (!DateTime.TryParseExact(dateInput, "dd-MM-yyyy", new CultureInfo("en-US"), DateTimeStyles.None, out _))
        {
            Console.WriteLine("\n\nInvalid date. (Format: dd-mm--yyyy). Type 0 to return to main menu or try again:\n\n");
            dateInput = Console.ReadLine();
        }

        return dateInput;
    }

    public static string GetNameInput()
    {
        Console.WriteLine("\n\nPlease insert the name or type 0 to return to main menu.\n\n");

        string nameInput = Console.ReadLine();

        if (nameInput == "0") GetUserInput();

        while (nameInput is null)
        {
            Console.WriteLine("\n\nInvalid text. Try again.\n\n");
            nameInput = Console.ReadLine();
        }

        return nameInput;
    }

    public static int GetQuantityInput()
    {
        Console.WriteLine("\n\nPlease insert number of minutes or type 0 to return to main menu.\n\n");

        string quantityInput = Console.ReadLine();
        
        if (quantityInput == "0") GetUserInput();

        while (!Int32.TryParse(quantityInput, out _) || Convert.ToInt32(quantityInput) < 0)
        {
            Console.WriteLine("\n\nInvalid number. Try again.\n\n");
            quantityInput = Console.ReadLine();
        }

        return Convert.ToInt32(quantityInput);
    }

    public static int GetIdInput()
    {
        Console.WriteLine("\n\nPlease insert the id of the record you want to delete or type 0 to return to main menu.\\n\\n\")\n\n");

        string idInput = Console.ReadLine();

        if (idInput == "0") GetUserInput();

        while (!Int32.TryParse(idInput, out _) || Convert.ToInt32(idInput) < 1)
        {
            Console.WriteLine("\n\nInvalid number. Try again");
            idInput = Console.ReadLine();
        }

        return Convert.ToInt32(idInput);
    }
}