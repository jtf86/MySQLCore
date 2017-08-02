using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System;

namespace MySqlCore.Models
{
    public class Task
    {
        private string _name;
        private int _id;

        public Task(string name, int id = 0)
        {
            _name = name;
            _id = id;
        }

        public string GetName()
        {
            return _name;
        }

        public int GetId()
        {
            return _id;
        }

        public void Save()
        {
            AppDb db = new AppDb();
            db.conn.Open();

            var cmd = db.conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO `tasks` (`name`) VALUES (@name);";

            MySqlParameter name = new MySqlParameter();
            name.ParameterName = "@name";
            name.Value = this._name;
            cmd.Parameters.Add(name);

            cmd.ExecuteNonQueryAsync();
            Console.Write("Id inserted is ");
            Console.WriteLine(cmd.LastInsertedId);
            _id = (int) cmd.LastInsertedId;
            Console.Write("Id assigned is ");
            Console.WriteLine(_id);

        }

        public static List<Task> GetAll()
        {
            List<Task> allTasks = new List<Task> {};

            AppDb db = new AppDb();
            db.conn.Open();

            var cmd = db.conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM tasks;";

            var rdr = cmd.ExecuteReader() as MySqlDataReader;

            while(rdr.Read())
            {
              int taskId = rdr.GetInt32(0);
              string taskName = rdr.GetString(1);
              Task newTask = new Task(taskName, taskId);
              Console.Write("Recovered task id is ");
              Console.WriteLine(taskId);
              allTasks.Add(newTask);
            }
            return allTasks;
        }

        public static void DeleteAll()
        {
            AppDb db = new AppDb();
            db.conn.Open();

            var cmd = db.conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"DELETE FROM tasks;";
            cmd.ExecuteNonQuery();

        }

        public override bool Equals(System.Object otherTask)
        {
          if (!(otherTask is Task))
          {
            return false;
          }
          else
          {
            Task newTask = (Task) otherTask;
            return this.GetId().Equals(newTask.GetId());
          }
        }

        public override int GetHashCode()
        {
             return this.GetId().GetHashCode();
        }


    }
}
