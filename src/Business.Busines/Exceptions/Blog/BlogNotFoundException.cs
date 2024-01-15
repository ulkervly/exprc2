using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Busines.Exceptions.Blog
{
    public class BlogNotFoundException:Exception
    {
        public string PropertyName { get; set; }

        public BlogNotFoundException()
        {
        }

        public BlogNotFoundException(string? message) : base(message)
        {
        }

        public BlogNotFoundException(string propertyName, string? message) : base(message)
        {
            PropertyName = propertyName;
        }
    }
}
