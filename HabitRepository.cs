using System.Globalization;
using Microsoft.Data.Sqlite;
using static HabitLogger.InputHelper;

namespace HabitLogger;

public class HabitRepository
{
    private static readonly string ConnectionString = "Data Source=habit.db";
    
    public static void GetAllRecords()
    {
        Console.Clear();
        using var connection = new SqliteConnection(ConnectionString);

        {
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = $"SELECT * FROM habit ";

            List<Habit> tableData = new List<Habit>();

            SqliteDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    tableData.Add(
                        new Habit
                        {
                            Id = reader.GetInt32(0), 
                            Name = reader.GetString(1),
                            Date = DateTime.ParseExact(reader.GetString(2), "dd-MM-yyyy", new CultureInfo("en-US")),
                            Quantity = reader.GetInt32(3)
                        });
                }
            }
            else
            {
                Console.WriteLine("No rows found");
            }
            
            connection.Close();

            Console.WriteLine("------------------------------------------\n");
            foreach (var h in tableData)
            {
                Console.WriteLine($"{h.Id} - {h.Name} - {h.Date.ToString("dd-MMM-yyyy")} - Quantity: {h.Quantity}");
            }
            Console.WriteLine("------------------------------------------\n");
        }
    }

    public static void Insert()
    {
        string name = GetNameInput();
        string date = GetDateInput();
        int quantity = GetQuantityInput();

        using var connection = new SqliteConnection(ConnectionString);

        {
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = $"INSERT INTO habit(name, date, quantity) VALUES('{name}', '{date}', {quantity})";

            command.ExecuteNonQuery();
            
            connection.Close();
        }

    }
}