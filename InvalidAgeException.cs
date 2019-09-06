using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerApp.Controllers
{
    public class InvalidAgeException: Exception
    {
        public InvalidAgeException(): base()
        {

        }

        public InvalidAgeException(string message): base(message)
        {

        }
    }
}
