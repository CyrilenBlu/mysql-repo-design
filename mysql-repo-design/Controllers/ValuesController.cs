using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using mysql_repo_design.Model;
using NLog;

namespace mysql_repo_design.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] {"value1", "value2"};
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }

    [Route("api/tests")]
    [ApiController]
    public class TestController : Controller
    {
        private TestRepository _service = new TestRepository();

        private Logger _logger = LogManager.GetCurrentClassLogger();

        [HttpGet("{id}")]
        public ActionResult<Test> GetById(int id)
        {
            return _service.GetTest(id);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Test>> GetTests()
        {
            return new ActionResult<IEnumerable<Test>>(_service.GetAllTest());
        }

        [HttpPost]
        public ActionResult<Test> AddTest([FromBody] Test test)
        {
            return _service.Add(test);
        }
    }
}