using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloUWP.Entities
{
    public class Song
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string singer { get; set; }
        public string author { get; set; }
        public string thumbnail { get; set; }
        public string link { get; set; }
        public string message { get; set; }
        public override string ToString()
        {
            return $"ID {id}, Name {name}, Description {description}, Singer {singer}, Author {author}," +
                $"Thumbnail {thumbnail}, Link {link}, Messsage {message}";
        }
    }
}
