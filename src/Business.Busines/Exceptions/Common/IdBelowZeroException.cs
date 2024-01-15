using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Busines.Exceptions.Common
{
    public class IdBelowZeroException:Exception
    {
        public string PropertyName { get; set; }
        public IdBelowZeroException()
        {
        }

        public IdBelowZeroException(string? message) : base(message)
        {
        }

        public IdBelowZeroException(string propertyName, string? message) : base(message)
        {
            PropertyName = propertyName;
        }
    }
}
