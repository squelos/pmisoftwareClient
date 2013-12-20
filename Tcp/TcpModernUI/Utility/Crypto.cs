using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TcpModernUI.Utility
{
    public class Crypto
    {

        private static Random random = new Random((int)DateTime.Now.Ticks);
        public static string GenerateSaltedHash(string text, string saltStr)
        {
            byte[] plainText = Encoding.UTF8.GetBytes(text);
            byte[] salt = Encoding.UTF8.GetBytes(saltStr);
            HashAlgorithm algo = new SHA256Managed();
            byte[] plainTextWithSaltBytes =
                new byte[plainText.Length + salt.Length];

            for (int i = 0; i < plainText.Length; i++)
            {
                plainTextWithSaltBytes[i] = plainText[i];
            }
            for (int i = 0; i < salt.Length; i++)
            {
                plainTextWithSaltBytes[plainText.Length + i] = salt[i];
            }

            return Encoding.UTF8.GetString(algo.ComputeHash(plainTextWithSaltBytes));
        }

        public static bool CompareByteArrays(byte[] array1, byte[] array2)
        {
            if (array1.Length != array2.Length)
            {
                return false;
            }

            for (int i = 0; i < array1.Length; i++)
            {
                if (array1[i] != array2[i])
                {
                    return false;
                }
            }

            return true;
        }

        public static bool CompareStrings(string str1, string str2)
        {
            byte[] array1 = Encoding.UTF8.GetBytes(str1);
            byte[] array2 = Encoding.UTF8.GetBytes(str2);
            if (array1.Length != array2.Length)
            {
                return false;
            }

            for (int i = 0; i < array1.Length; i++)
            {
                if (array1[i] != array2[i])
                {
                    return false;
                }
            }

            return true;
        }

       

        public static string GetRandomString(int size)
        {
            StringBuilder builder = new StringBuilder();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }

            return builder.ToString();
        }
    }
}
