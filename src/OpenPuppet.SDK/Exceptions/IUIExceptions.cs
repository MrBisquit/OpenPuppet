using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenPuppet.SDK.Exceptions
{
    public class NotImplementedInterfaceException(string message) : Exception(message)
    { }

    public class NotRegisteredException(string message) : Exception(message)
    { }
}
