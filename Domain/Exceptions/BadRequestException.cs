using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException() { }
        public BadRequestException(string message) : base(message) { }
        public BadRequestException(string message, Exception exception) : base(message, exception) { }
        public BadRequestException(string name, object key) : base($"Customer \"{name}\" ({key}) was not found.") { }
    }
}
