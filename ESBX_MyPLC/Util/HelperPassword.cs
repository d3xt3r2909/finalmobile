using PCLCrypto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESBX_MyPLC.Util
{
    public class HelperPassword
    {
        public static string GenerateSalt()
        {
            //byte[] arr = new byte[16];
            //RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();
            var buff = WinRTCrypto.CryptographicBuffer.GenerateRandom(16);
            // crypto.GetBytes(arr);
            return Convert.ToBase64String(buff);
        }

        /**
         * Generate salt with user input for password and salt 
         */
        public static string GenerateHash(string password, string salt)
        {
            byte[] passwordBArray = Encoding.Unicode.GetBytes(password);
            byte[] saltBArray = Convert.FromBase64String(salt);
            byte[] forHash = new byte[passwordBArray.Length + saltBArray.Length + 1];

            Buffer.BlockCopy(passwordBArray, 0, forHash, 0, passwordBArray.Length);
            Buffer.BlockCopy(saltBArray, 0, forHash, passwordBArray.Length, saltBArray.Length);

            // HashAlgorithm alg = HashAlgorithm.Create("SHA1");

            var alg = WinRTCrypto.HashAlgorithmProvider.OpenAlgorithm(HashAlgorithm.Sha1);

            if (alg != null)
            {
                byte[] hashed = alg.HashData(forHash);

                return Convert.ToBase64String(hashed);
            }

            return null;
        }
    }
}
