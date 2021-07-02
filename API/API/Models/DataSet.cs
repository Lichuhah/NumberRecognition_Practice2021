using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Picture
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public byte[] Image { get; set; }
    }
    public class DataSet
    {
        public int Id { get; set; }
        public List<Picture> Pictures { get; set; }

        public DataSet()
        {
            Pictures = new List<Picture>();
        }
    }
}
