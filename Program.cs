using Microsoft.Data.Sqlite;

using var connection = new SqliteConnection("Data Source=habit.db");
connection.Open();

var command = connection.CreateCommand();
command.CommandText =
    @"CREATE TABLE IF NOT EXISTS habit (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    date TEXT,
    quantity INTEGER
    )";

command.ExecuteNonQuery();
