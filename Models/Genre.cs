using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrmTask_04072024.Models
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Books> Books { get; set; }
    }
}
