using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace SimpleBlogProject.Core.Helper.Cryption
{
    public static class HashingHelper
    {
        public static string Hash(string originalString)
        {
            using(SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(originalString));
                return Convert.ToBase64String(bytes);
            }
        }
    }
}
