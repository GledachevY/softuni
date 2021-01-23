using System;
using System.Collections.Generic;
using System.Text;

namespace _01Logger.Models.Contracts
{
  public  interface IPathManager
    {
        //bin/debug
        string CurrentDirectoryPath { get; }
        //bind/debug/logfile.txt
        string CurrentFilePath { get; }
        // it tells me where my app is running on user pc
        string GetCurrentPath();
        // it will ensure that selected file and directory will exist
        void EnsureDirectoryAndFileExist();
    }
}
