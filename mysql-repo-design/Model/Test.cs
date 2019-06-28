namespace mysql_repo_design.Model
{
    public class Test
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public int Age { get; set; }

        public Test(int id, string name, int age)
        {
            Id = id;
            Name = name;
            Age = age;
        }

        public Test()
        {
        }
    }
}