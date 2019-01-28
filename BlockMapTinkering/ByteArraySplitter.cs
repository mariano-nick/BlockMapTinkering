using System;
using System.Collections.Generic;
using System.Text;

namespace BlockMapTinkering
{
    public static class ByteArraySplitter
    {
        public static List<byte[]> SplitByteArrayInto64KbChunks(byte[] inputArray)
        {
            int total64KbChunks = Calculate64KbChunksByTotalByteLength(inputArray.Length);
            var byteArrayList = new List<byte[]>();

            for (int i = 0; i < total64KbChunks; i++)
            {
                byteArrayList.Add(Extract64KbFromByteArray(i, inputArray));
            }

            return byteArrayList;
        }

        private static int Calculate64KbChunksByTotalByteLength(int totalByteArrayLength)
        {
            return (int)Math.Ceiling(totalByteArrayLength / 64000f);
        }

        private static byte[] Extract64KbFromByteArray(int iterator, byte[] sourceByteArray)
        {
            int startingCount = iterator * 64000;
            byte[] extractedByteStream = new byte[64000];
            for (int i = 0; i < 64000; i++)
            {
                extractedByteStream[i] = sourceByteArray[startingCount];
                startingCount++;
                if (startingCount >= sourceByteArray.Length)
                {
                    break;
                }
            }

            return extractedByteStream;
        }
    }
}
