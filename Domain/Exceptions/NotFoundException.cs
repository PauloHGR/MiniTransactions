using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException() { }
        public NotFoundException(string message) : base(message) { }
        public NotFoundException(string message, Exception exception) : base(message, exception) { }
        public NotFoundException(string name, object key) : base($"Product \"{name}\" ({key}) was not found.") { }
    }
}
