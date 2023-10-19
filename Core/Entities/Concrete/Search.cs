using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Concrete
{
   public  class Search
    {
        public int CategoryId { get; set; }

        public  int ModelId  { get; set; }
        public int priceStart { get; set; }
        public int priceEnd { get; set; }
    }
}
