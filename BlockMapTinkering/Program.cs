using System;
using System.IO;

namespace BlockMapTinkering
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input a file path");
            string filePath = Console.ReadLine();
            byte[] fileByteArray = FileToByteArray.GetByteArrayFromFile(filePath);

            // tested using this file https://archive.apache.org/dist/openoffice/4.1.6/binaries/en-US/Apache_OpenOffice_4.1.6_Win_x86_langpack_en-US.exe.sha256
            string knownHash = "b4e8df732268c55f66ade288ba9d2600398ad94f28d24681c919b25a0366bf1d";
            //string computedHash = Sha256Hasher.GetSha256Hash(fileByteArray);

            if (Sha256Hasher.CompareByteStreamHashToSha256Hash(fileByteArray, knownHash))
            {
                Console.WriteLine("Hashes are the same");
            }
            else
            {
                Console.WriteLine("Hashes are different");
            }

            Console.WriteLine(fileByteArray.Length);

            var splitByteArray = ByteArraySplitter.SplitByteArrayInto64KbChunks(fileByteArray);

            foreach(byte[] byteArray in splitByteArray)
            {
                Console.WriteLine(Sha256Hasher.GetSha256Hash(byteArray));
            }

            Console.ReadLine();
        }
    }
}
