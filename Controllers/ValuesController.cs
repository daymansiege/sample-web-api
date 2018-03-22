using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Npgsql;

namespace SampleWebApi.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            var dbUrl = Environment.GetEnvironmentVariable("DATABASE_URL");
            var connString = dbUrl.GetConnectionString();
            NpgsqlConnection conn = new NpgsqlConnection(connString);
            conn.Open();

            NpgsqlCommand command = new NpgsqlCommand("SELECT id, name FROM test;", conn);

            NpgsqlDataReader dr = command.ExecuteReader();

            while (dr.Read())
            {
                yield return $"{dr.GetInt64(0)} - {dr.GetString(1)}";
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
