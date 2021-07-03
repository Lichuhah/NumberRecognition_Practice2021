using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using System.Data.SqlClient;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataSetController : ControllerBase
    {
        // GET: api/<DataSetController>
        [HttpGet]
        public DataSet Get()
        {
            DataSet ds = new DataSet();
            return ds;
        }

        // GET api/<DataSetController>/5
        [HttpGet("{id}")]
        public DataSet Get(int id)
        {
            DataSet ds = new DataSet();
            ds.Id = id;
            //List<string> networksNames = new List<string>();
            SqlConnection sqlConnection = LiteSQLConnection.getSQLConnection();
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM [dbo].[Picture] JOIN [dbo].[DataSet] ON Picture.Id = DataSet.Id_Picture WHERE DataSet.Id_Network=@id", sqlConnection);
            sqlCommand.Parameters.AddWithValue("id", id);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                Picture pic = new Picture();
                pic.Id = (int)sqlDataReader[0];
                pic.Value = (int)sqlDataReader[1];
                pic.Image = (byte[])sqlDataReader[2];
                ds.Pictures.Add(pic);
            }
            //sqlConnection.Close();
            //return networksNames;
            return ds;
        }

        // POST api/<DataSetController>/5
        [HttpPost("{id}")]
        public void Post(int id, [FromBody] Picture picture)
        {
            SqlConnection sqlConnection = LiteSQLConnection.getSQLConnection();
            SqlCommand sqlCommand = new SqlCommand("INSERT INTO [dbo].[Picture] VALUES (@Value, @Image)", sqlConnection);
            sqlCommand.Parameters.AddWithValue("Value", picture.Value);
            sqlCommand.Parameters.AddWithValue("Image", picture.Image);
            sqlCommand.ExecuteNonQuery();
            sqlCommand.CommandText = "SELECT @@IDENTITY";
            int lastId = Convert.ToInt32(sqlCommand.ExecuteScalar());



            sqlCommand = new SqlCommand("INSERT INTO [dbo].[DataSet] VALUES (@idNet, @idImg)", sqlConnection);
            sqlCommand.Parameters.AddWithValue("idNet", id);
            sqlCommand.Parameters.AddWithValue("idImg", lastId);
            sqlCommand.ExecuteNonQuery();

            sqlConnection.Close();
        }

        // PUT api/<DataSetController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DataSetController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
