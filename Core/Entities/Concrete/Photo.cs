 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Concrete
{
    public class Photo:IEntity
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public bool IsMain { get; set; }
        public string PhotoUrl { get; set; }

        public string PublicId { get; set; }
        public DateTime DataAdded { get; set; }

        public Car Car { get; set; }
    }
}
