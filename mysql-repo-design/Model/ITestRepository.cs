using System.Collections;
using System.Collections.Generic;

namespace mysql_repo_design.Model
{
    public interface ITestRepository
    {
        Test GetTest(int id);

        IEnumerable<Test> GetAllTest();

        Test Add(Test test);

        Test Update(Test test);

        Test Delete(int id);
    }
}