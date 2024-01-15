using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Core.Entities
{
    public class Blog:BaseEntity
    {
        
        [StringLength(maximumLength: 100)]
        public string Author {  get; set; }
        [Required]
        [StringLength(maximumLength: 100)]
        public string Name { get; set; }
        
        [StringLength(maximumLength: 200)]
        public string Description { get; set; }
        public string? ImageUrl { get; set; }
        [NotMapped]
        public IFormFile? ImageFile {  get; set; }
       

    }
}
