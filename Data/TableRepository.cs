using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SQLite;
using DEUProject_CSharp_OutbackPOS.Model;
using DEUProject_CSharp_OutbackPOS.Data;
using System.Drawing;

public class TableRepository
{
    public void AddTableIcon(Table table)
    {
        using (var connection = DatabaseHelper.GetConnection())
        {
            connection.Open();
            string query = "INSERT INTO TableLayout (Name, X, Y, ImagePath) VALUES (@Name, @X, @Y, @ImagePath)";
            using (var command = new SQLiteCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Name", table.Name);
                command.Parameters.AddWithValue("@X", table.X);
                command.Parameters.AddWithValue("@Y", table.Y);
                command.Parameters.AddWithValue("@ImagePath", table.ImagePath);
                command.ExecuteNonQuery();
            }
        }
    }

    public List<Table> GetAllTableIcons()
    {
        var icons = new List<Table>();
        using (var connection = DatabaseHelper.GetConnection())
        {
            connection.Open();
            string query = "SELECT * FROM TableLayout";
            using (var command = new SQLiteCommand(query, connection))
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    icons.Add(new Table
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        X = reader.GetInt32(2),
                        Y = reader.GetInt32(3),
                        ImagePath = reader.GetString(4)
                    });
                }
            }
        }
        return icons;
    }

    public void UpdateTableIcon(Table icon)
    {
        using (var connection = DatabaseHelper.GetConnection())
        {
            connection.Open();
            string query = "UPDATE TableIcons SET X = @X, Y = @Y, ImagePath = @ImagePath WHERE Id = @Id";
            using (var command = new SQLiteCommand(query, connection))
            {
                command.Parameters.AddWithValue("@X", icon.X);
                command.Parameters.AddWithValue("@Y", icon.Y);
                command.Parameters.AddWithValue("@ImagePath", icon.ImagePath);
                command.Parameters.AddWithValue("@Id", icon.Id);
                command.ExecuteNonQuery();
            }
        }
    }

    public void DeleteTableIcon(int id)
    {
        using (var connection = DatabaseHelper.GetConnection())
        {
            connection.Open();
            string query = "DELETE FROM TableLayout WHERE Id = @Id";
            using (var command = new SQLiteCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Id", id);
                command.ExecuteNonQuery();
            }
        }
    }

    public void ClearAllTableIcons()
    {
        using (var connection = DatabaseHelper.GetConnection())
        {
            connection.Open();
            string query = "DELETE FROM TableLayout";
            using (var command = new SQLiteCommand(query, connection))
            {
                command.ExecuteNonQuery();
            }
        }
    }
}