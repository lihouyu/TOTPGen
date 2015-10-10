using System;
using System.Collections.Generic;

namespace TOTPGen
{
    /// <summary>
    /// Just a simple Base32 string decoder
    /// </summary>
    public static class Base32Decode
    {
        /// <summary>
        /// Decode a Base32 string
        /// This will only work on a multiple of 40 bits (5 bytes)
        /// http://www.garykessler.net/library/base64.html
        /// 
        /// Original code at http://stackoverflow.com/questions/641361/base32-decoding
        /// by Chirs http://stackoverflow.com/users/59198/chris
        /// 
        /// Modified by HouYu Li <lihouyu@phpex.net>
        /// </summary>
        public static byte[] Decode(string Base32String)
        {
            string Base32Chars = "abcdefghijklmnopqrstuvwxyz234567";
            string str = Base32String.Trim().ToLower();
            
            // Convert it to bits
            List<byte> bits = new List<byte>();
            foreach (char c in str)
            {
                int i = Base32Chars.IndexOf(c);
                if (i == -1)
                    throw new Exception("Not a base32 string");
                bits.Add((byte)((i & 16) > 0 ? 1 : 0));
                bits.Add((byte)((i & 8) > 0 ? 1 : 0));
                bits.Add((byte)((i & 4) > 0 ? 1 : 0));
                bits.Add((byte)((i & 2) > 0 ? 1 : 0));
                bits.Add((byte)((i & 1) > 0 ? 1 : 0));
            }
            
            // Convert bits into bytes
            List<byte> bytes = new List<byte>();
            for (int i = 0; i < bits.Count; i += 8)
            {
                bytes.Add((byte)(
                    (bits[i + 0] << 7) +
                    (bits[i + 1] << 6) +
                    (bits[i + 2] << 5) +
                    (bits[i + 3] << 4) +
                    (bits[i + 4] << 3) +
                    (bits[i + 5] << 2) +
                    (bits[i + 6] << 1) +
                    (bits[i + 7] << 0)));
            }
            
            return bytes.ToArray();
        }
    }
}
