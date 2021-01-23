using _01Logger.Models.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace _01Logger.Models.PathManagment
{
    public class PathManager : IPathManager
    {
       // private const string PATH_DELIMITER = "\\";

        private readonly string currentPath;
        private readonly string folderName;
        private readonly string fileName;

        //tells me where my app is runnin on user pc
        private PathManager()
        {
            this.currentPath = this.GetCurrentPath();
        }

        //they should pass folder name and file name
        public PathManager(string folderName, string fileName)
            : this()
        {
            this.fileName = fileName;
            this.folderName = folderName;
        }

        public string CurrentDirectoryPath
            => Path.Combine(this.currentPath, this.folderName);


        public string CurrentFilePath
            => Path.Combine( this.CurrentDirectoryPath , this.fileName);

        public string GetCurrentPath()
        {
            return Directory.GetCurrentDirectory();
        }

        public void EnsureDirectoryAndFileExist()
        {
            if (!Directory.Exists(this.CurrentDirectoryPath))
            {
                Directory.CreateDirectory(this.CurrentDirectoryPath);
            }
            File.AppendAllText(this.CurrentFilePath, string.Empty);
        }
    }
}
