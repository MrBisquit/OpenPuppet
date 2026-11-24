using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenPuppet.SDK.Exceptions
{
    /// <summary>
    /// Thrown when the plugin being loaded doesn't implement the interface required.
    /// </summary>
    /// <param name="message">Extra details</param>
    public class NotImplementedInterfaceException(string message) : Exception(message)
    { }

    /// <summary>
    /// Thrown when something is trying to use something that isn't registered.
    /// </summary>
    /// <param name="message">Extra details</param>
    public class NotRegisteredException(string message) : Exception(message)
    { }
}
