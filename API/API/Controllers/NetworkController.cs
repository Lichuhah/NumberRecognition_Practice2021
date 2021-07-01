using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using System.Data.SqlClient;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NetworkController : ControllerBase
    {
        // GET: api/<NetworkController>
        [HttpGet]
        public List<Network> Get()
        {
            List<Network> networks = new List<Network>();
            SqlConnection sqlConnection = new SqlConnection("Data Source=DESKTOP-FC16M2F;Initial Catalog=BDNeuralNetworks;Integrated Security=True");
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM [dbo].[Network]", sqlConnection);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                Network network = new Network();
                network.Id = (int)sqlDataReader[0];
                network.Name = sqlDataReader[1].ToString();
                network.Data = (byte[])sqlDataReader[2];
                networks.Add(network);
            }
            sqlConnection.Close();
            return networks;
        }

        // GET api/<NetworkController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<NetworkController>
        [HttpPost]
        public void Post([FromBody] Network network)
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source=DESKTOP-FC16M2F;Initial Catalog=BDNeuralNetworks;Integrated Security=True");
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand("INSERT INTO [dbo].[Network] VALUES (@name, @data)", sqlConnection);
            sqlCommand.Parameters.AddWithValue("name", network.Name);
            sqlCommand.Parameters.AddWithValue("data", network.Data);
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }

        // PUT api/<NetworkController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<NetworkController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
