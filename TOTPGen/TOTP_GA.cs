using System;
using System.Security.Cryptography;

namespace TOTPGen
{
    /// <summary>
    /// The core TOTP generator code
    /// </summary>
    public static class TOTP_GA
    {
        public static string DummySecret {
            get {
                return "0000000000000000";
            }
        }
        
        /// <summary>
        /// The original code at
        /// http://www.codeproject.com/Articles/403355/Implementing-Two-Factor-Authentication-in-ASP-NET
        /// by Rick Bassham, http://www.codeproject.com/script/Membership/View.aspx?mid=4294419
        /// under MIT License, http://opensource.org/licenses/mit-license.php
        /// 
        /// Modified by HouYu Li <lihouyu@phpex.net>
        /// </summary>
        /// <param name="secret"></param>
        /// <param name="iterationNumber"></param>
        /// <param name="digits"></param>
        /// <returns></returns>
        public static string GeneratePassword(string secret, long iterationNumber, int digits = 6)
        {
            byte[] counter = BitConverter.GetBytes(iterationNumber);
        
            if (BitConverter.IsLittleEndian)
                Array.Reverse(counter);

            byte[] key = Base32Decode.Decode(secret);
        
            HMACSHA1 hmac = new HMACSHA1(key, true);
        
            byte[] hash = hmac.ComputeHash(counter);
        
            int offset = hash[hash.Length - 1] & 0xf;
        
            int binary =
                ((hash[offset] & 0x7f) << 24)
                | ((hash[offset + 1] & 0xff) << 16)
                | ((hash[offset + 2] & 0xff) << 8)
                | (hash[offset + 3] & 0xff);
        
            int password = binary % (int)Math.Pow(10, digits);
        
            return password.ToString(new string('0', digits));
        }

    }
}
