using Core.Entities;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class CarForDetailDto:IDto
    {
        public int CarId { get; set; }

        public string ModelName { get; set; }

        public decimal Price { get; set; }

        public string CategoryName { get; set; }

        public List<Photo> Photos { get; set; }

        public int UserId { get; set; }

        public string City { get; set; }

        public int Year { get; set; }

        public string Type { get; set; }

        public string Color { get; set; }
        public bool Vip { get; set; }

        public string OtherNotes { get; set; }

        public DateTime AddedData { get; set; }

        public string Engine { get; set; }

        public string EnginePower { get; set; }

        public int TotalWay { get; set; }

        public string Transmittor { get; set; }
        public int PhoneNumber { get; set; }


    }
}
