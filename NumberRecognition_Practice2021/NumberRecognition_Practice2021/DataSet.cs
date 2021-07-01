using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Picture
    {
        int Id { get; set; }
        int Data { get; set; }
        byte[] Image { get; set; }
    }
    public class DataSet
    {
        int Id { get; set; }

        string Name { get; set; }
        List<Picture> Pictures { get; set; }
    }
}
