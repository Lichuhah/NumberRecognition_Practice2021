using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Network
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public byte[] Data { get; set; }
    }
}
