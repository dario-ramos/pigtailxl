using System;
using System.IO;

namespace NJCourts.Models
{
    public class Model
    {
        public event Action<string> Error;

        /**
         * Check if input directory exists 
         */
        public void Init()
        {
            if (!Directory.Exists(Configuration.InputDirectory))
            {
                Error?.Invoke("Input directory " + Configuration.InputDirectory + " does not exist");
            }
        }
    }
}
