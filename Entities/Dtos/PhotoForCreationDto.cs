using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class PhotoForCreationDto
    {
        public PhotoForCreationDto()
        {

            DateAdded = DateTime.Now;
        }
        public string PhotoUrl { get; set; }

        public IFormFile File { get; set; }

        public string PublicId { get; set; }

        public DateTime DateAdded { get; set; }


    }
}
