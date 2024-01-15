using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Busines.Exceptions.Blog
{
    public class BlogInvalidImageFileException:Exception
    {
        public string PropertyName { get; set; }

        public BlogInvalidImageFileException()
        {
        }

        public BlogInvalidImageFileException(string? message) : base(message)
        {
        }

        public BlogInvalidImageFileException(string propertyName, string? message) : base(message)
        {
            PropertyName = propertyName;
        }
    }
}
