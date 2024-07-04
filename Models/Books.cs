using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrmTask_04072024.Models
{
    public class Books
    {
        public int Id { get; set; }
        public int GenreId { get; set; }
        public string Name { get; set; }
        public decimal CostPrice { get; set; }
        public decimal SalePrice { get; set; }

        public Genre Genres { get; set; }

        public override string ToString()
        {
            return $"{Id}-{Name}-{SalePrice}-{Genres.Name}";
        }
    }

}
