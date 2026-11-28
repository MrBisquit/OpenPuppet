using System;
using System.Collections.Generic;
using System.Text;

namespace OpenPuppet.SDK
{
    /// <summary>
    /// The IProjectPath is an interface for extendability reasons,
    /// it provides very basic utilities.
    /// </summary>
    public interface IProjectPath : IDisposable
    {
        /// <summary>
        /// Get the base directory of the project
        /// </summary>
        /// <returns>The very base directory path</returns>
        public string GetDirectory();

        /// <summary>
        /// Get the project configuration file path
        /// </summary>
        /// <returns>The project file</returns>
        public string GetProjctFilePath();
    }
}
