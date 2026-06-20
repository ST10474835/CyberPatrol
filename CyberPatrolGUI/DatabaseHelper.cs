using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberPatrolGUI
{
    internal class DatabaseHelper
  
        {
            // ── Change password here if yours is different ────────
            private static string connectionString =
                "Server=localhost;" +
                "Database=CyberPatrolDB;" +
                "Uid=root;" +
                "Pwd=Wawa_2012;";

            // ── Test connection ───────────────────────────────────
            public static bool TestConnection()
            {
                try
                {
                    using (var conn = new MySqlConnection(
                        connectionString))
                    {
                        conn.Open();
                        return true;
                    }
                }
                catch { return false; }
            }

            // ── Add a new task ────────────────────────────────────
            public static bool AddTask(TaskItem task)
            {
                try
                {
                    using (var conn = new MySqlConnection(
                        connectionString))
                    {
                        conn.Open();
                        string sql =
                            "INSERT INTO Tasks " +
                            "(Title, Description, ReminderDate) " +
                            "VALUES (@title, @desc, @reminder)";
                        var cmd = new MySqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue(
                            "@title", task.Title);
                        cmd.Parameters.AddWithValue(
                            "@desc", task.Description ?? "");
                        cmd.Parameters.AddWithValue(
                            "@reminder", task.ReminderDate ?? "");
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
                catch { return false; }
            }

            // ── Get all tasks ─────────────────────────────────────
            public static List<TaskItem> GetAllTasks()
            {
                var tasks = new List<TaskItem>();
                try
                {
                    using (var conn = new MySqlConnection(
                        connectionString))
                    {
                        conn.Open();
                        string sql =
                            "SELECT * FROM Tasks " +
                            "ORDER BY CreatedAt DESC";
                        var cmd = new MySqlCommand(sql, conn);
                        var reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            tasks.Add(new TaskItem
                            {
                                Id = reader.GetInt32("Id"),
                                Title = reader.GetString("Title"),
                                Description = reader.GetString(
                                    "Description"),
                                ReminderDate = reader.GetString(
                                    "ReminderDate"),
                                IsCompleted = reader.GetBoolean(
                                    "IsCompleted"),
                                CreatedAt = reader.GetDateTime(
                                    "CreatedAt")
                            });
                        }
                    }
                }
                catch { }
                return tasks;
            }

            // ── Mark task as complete ─────────────────────────────
            public static bool CompleteTask(int id)
            {
                try
                {
                    using (var conn = new MySqlConnection(
                        connectionString))
                    {
                        conn.Open();
                        string sql =
                            "UPDATE Tasks SET IsCompleted = TRUE " +
                            "WHERE Id = @id";
                        var cmd = new MySqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
                catch { return false; }
            }

            // ── Delete a task ─────────────────────────────────────
            public static bool DeleteTask(int id)
            {
                try
                {
                    using (var conn = new MySqlConnection(
                        connectionString))
                    {
                        conn.Open();
                        string sql =
                            "DELETE FROM Tasks WHERE Id = @id";
                        var cmd = new MySqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
                catch { return false; }
            }
        }
    }


