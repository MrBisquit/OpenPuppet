using System;
using System.Collections.Generic;
using System.Text;

namespace OpenPuppet.SDK
{
    /// <summary>
    /// The project manager service.
    /// 
    /// This service provides the tools required for managing the creation, opening, saving
    /// of projects, and handling the recent projects list.
    /// </summary>
    public interface IProjectManager
    {
        public List<string> RecentProjects { get; }

        /* Also just a note here:
         * It would be nice if these returned maybe some kind of result,
         * this could help reference to the project just opened, or provide
         * some kind of user feedback later in the chain
         * */

        /// <summary>
        /// Open a project based on project metadata
        /// </summary>
        /// <param name="meta">The project metadata</param>
        public void OpenProject(Projects.ProjectMetadata meta);

        /// <summary>
        /// Open a project based on a path
        /// </summary>
        /// <remarks>
        /// The path provided should <i>either</i> be a path
        /// to a directory containing a project file, or a direct
        /// path to a project file
        /// </remarks>
        /// <param name="path">The path</param>
        public void OpenProject(string path);

        /// <summary>
        /// Open a project based on an IProjectPath
        /// </summary>
        /// <param name="path">The IProjectPath</param>
        public void OpenProject(IProjectPath path);

        /// <summary>
        /// Save a project based on project metadata
        /// </summary>
        /// <param name="meta">The project metadata</param>
        public void SaveProject(Projects.ProjectMetadata meta);

        /// <summary>
        /// Save a project based on project metadata and a path
        /// </summary>
        /// <remarks>
        /// The path provided should <i>either</i> be a path
        /// to a directory containing a project file, or a direct
        /// path to a project file
        /// </remarks>
        /// <param name="meta">The project metadata</param>
        /// <param name="path">The path</param>
        public void SaveProject(Projects.ProjectMetadata meta, string path);

        /// <summary>
        /// Save a project based on project metadata and an IProjectPath
        /// </summary>
        /// <param name="meta">The project metadata</param>
        /// <param name="path">The path</param>
        public void SaveProject(Projects.ProjectMetadata meta, IProjectPath path);

        /// <summary>
        /// Create a project
        /// </summary>
        /// <remarks>
        /// The path provided should <i>either</i> be a path
        /// to a directory containing a project file, or a direct
        /// path to a project file
        /// </remarks>
        /// <param name="name">The project name</param>
        /// <param name="path">The path<param>
        public void Create(string name, string path);

        /// <summary>
        /// Create a project
        /// </summary>
        /// <param name="name">The project path</param>
        /// <param name="path">The path</param>
        public void Create(string name, IProjectPath path);

        /// <summary>
        /// Asynchronous version of <see cref="OpenProject(Projects.ProjectMetadata)"/>
        /// </summary>
        public Task OpenProjectAsync(Projects.ProjectMetadata meta, CancellationToken? ct);

        /// <summary>
        /// Asynchronous version of <see cref="OpenProject(string)"/>
        /// </summary>
        public Task OpenProjectAsync(string path, CancellationToken? ct);

        /// <summary>
        /// Asynchronous version of <see cref="OpenProject(IProjectPath)"/>
        /// </summary>
        public Task OpenProjectAsync(IProjectPath path, CancellationToken? ct);

        /// <summary>
        /// Asynchronous version of <see cref="SaveProject(Projects.ProjectMetadata)"/>
        /// </summary>
        public Task SaveProjectAsync(Projects.ProjectMetadata meta, CancellationToken? ct);

        /// <summary>
        /// Asynchronous version of <see cref="SaveProject(Projects.ProjectMetadata, string)"/>
        /// </summary>
        public Task SaveProjectAsync(Projects.ProjectMetadata meta, string path, CancellationToken? ct);

        /// <summary>
        /// Asynchronous version of <see cref="SaveProject(Projects.ProjectMetadata, IProjectPath)"/>
        /// </summary>
        public Task SaveProjectAsync(Projects.ProjectMetadata meta, IProjectPath path, CancellationToken? ct);

        /// <summary>
        /// Asynchronous version of <see cref="Create(string, string)"/>
        /// </summary>
        public Task CreateAsync(string name, string path, CancellationToken? ct);

        /// <summary>
        /// Asynchronous version of <see cref="Create(string, IProjectPath)"/>
        /// </summary>
        public Task CreateAsync(string name, IProjectPath path, CancellationToken? ct);
    }
}
