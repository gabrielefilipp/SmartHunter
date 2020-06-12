using System;
using System.Collections.Generic;
using System.Globalization;
using SmartHunter.Game.Config;

namespace SmartHunter.Core
{
    public class BytePattern
    {
        public BytePatternConfig Config { get; }
        public byte?[] Bytes { get; private set; }
        public List<ulong> MatchedAddresses { get; private set; }

        public BytePattern(BytePatternConfig config)
        {
            Config = config;
            Bytes = BytesFromString(config.PatternString);
            MatchedAddresses = new List<ulong>();
        }

        public static byte?[] BytesFromString(string byteString)
        {
            List<byte?> byteList = new List<byte?>();

            var singleByteStrings = byteString.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var singleByteString in singleByteStrings)
            {
                byte parsedByte = 0;
                if (byte.TryParse(singleByteString, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out parsedByte))
                {
                    byteList.Add(parsedByte);
                }
                else
                {
                    byteList.Add(null);
                }
            }

            return byteList.ToArray();
        }
    }
}
