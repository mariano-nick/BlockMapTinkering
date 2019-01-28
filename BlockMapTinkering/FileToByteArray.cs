using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace BlockMapTinkering
{
    public static class FileToByteArray
    {
        public static byte[] GetByteArrayFromFile(string filePath)
        {
            // TODO do file path checking things

            byte[] fileByteArray;

            using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
            {
                using (var memoryStream = new MemoryStream())
                {
                    fileStream.CopyTo(memoryStream);
                    fileByteArray = memoryStream.ToArray();
                }
            }

            return fileByteArray;
        }
    }
}
