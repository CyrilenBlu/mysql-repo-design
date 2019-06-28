using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using NLog;

namespace mysql_repo_design.Model
{
    public class TestRepository : ITestRepository
    {

        private MySqlConnection _conn = Program.Conn;
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();
        
        public Test GetTest(int id)
        {
            var query = "SELECT * FROM test WHERE id = " + id;
            var cmd = new MySqlCommand(query, _conn);
            var reader = cmd.ExecuteReader();
            var test = new Test();
            
            if (reader.Read())
            {
                var sqlId = Convert.ToInt32(reader.GetString(0));
                var name = reader.GetString(1);
                var age = Convert.ToInt32(reader.GetString(2));
                
                test = new Test(sqlId, name, age);
            }

            reader.Close();
            return test;
        }

        public IEnumerable<Test> GetAllTest()
        {
            var query = "SELECT * FROM test";
            var cmd = new MySqlCommand(query, _conn);
            var reader = cmd.ExecuteReader();
            var tests = new List<Test>();

            while (reader.Read())
            {
                var sqlId = Convert.ToInt32(reader.GetString(0));
                var name = reader.GetString(1);
                var age = Convert.ToInt32(reader.GetString(2));
                
                tests.Add(new Test(sqlId, name, age));
            }
            
            reader.Close();

            return tests;

        }

        public Test Add(Test test)
        {
            var query = "INSERT INTO test(id, name, age) VALUES(" + test.Id + ", '" + test.Name + "', " + test.Age + ")";
            var cmd = _conn.CreateCommand();
            cmd.CommandText = query;
            var recordsAffected = cmd.ExecuteNonQuery();

            Console.WriteLine(recordsAffected);
            
            var query2 = "SELECT * FROM test WHERE id = " + test.Id;
            var cmd2 = new MySqlCommand(query2, _conn);
            var reader = cmd2.ExecuteReader();

            var returnTest = new Test();
            if (reader.Read())
            {
                var sqlId = Convert.ToInt32(reader.GetString(0));
                var name = reader.GetString(1);
                var age = Convert.ToInt32(reader.GetString(2));
                
                returnTest = new Test(sqlId, name, age);
            }

            reader.Close();

            return returnTest;
        }

        public Test Update(Test test)
        {
            throw new System.NotImplementedException();
        }

        public Test Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}