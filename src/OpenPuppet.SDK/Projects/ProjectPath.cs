using System;
using System.Collections.Generic;
using System.Text;

namespace OpenPuppet.SDK.Projects
{
    /// <summary>
    /// The default implementation of IProjectPath
    /// </summary>
    public class ProjectPath : IProjectPath
    {
        private readonly string ProjectBase;
        private readonly string ProjectFile;

        public ProjectPath(string path)
        {
            if(File.Exists(path))
            {
                ProjectBase = Path.GetDirectoryName(path)!;
                ProjectFile = path;
            } else if(Directory.Exists(path))
            {
                ProjectBase = path;
                string file = Path.Join(path, new DirectoryInfo(path).Name + ".opp");
                if(File.Exists(file))
                {
                    ProjectFile = file;
                } else
                {
                    throw new FileNotFoundException(
                        $"Couldn't find a part of the path \"{file}\""
                    );
                }
            } else
            {
                throw new DirectoryNotFoundException(
                    $"Couldn't find a part of the path \"{path}\""
                );
            }
        }

        public ProjectPath(FileInfo file) : this(file.FullName)
        { }

        public ProjectPath(DirectoryInfo dir) : this(dir.FullName)
        { }

        public string GetDirectory() => ProjectBase;

        public string GetProjctFilePath() => ProjectFile;

        public void Dispose() { }
    }
}
