using System;
using System.Security.Cryptography;
using System.Text;
using System.Web.Mvc;

public class Utilities
{
    public static string setRelativePath(string relativePath)
    {
        return System.Web.HttpContext.Current.Request.PhysicalApplicationPath + relativePath;
    }
}

namespace Helpers
{
    class FileAdapter
    {
        public byte[] fileContent;
        public string fileType;
    }
    class CategoryAdapter
    {
        public int categoryId;
        public string categoryName;
    }

    class QuestionAdapter
    {
        public int questionID;
        public string questionText;
    }

    class OptionAdapter
    {
        public int optionId;
        public string optionsText;

        public (int, string) toTuple()
        {
            return (optionId, optionsText);
        }
    }

    public class Hasher
    {
        public static string hash(string password)
        {
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);

            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);

            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            return Convert.ToBase64String(hashBytes);
        }

        public static bool comparation(string password, string hash)
        {
            bool isEqual = true;
            byte[] hashBytes = Convert.FromBase64String(hash);

            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);

            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);
            byte[] hashedPswd = pbkdf2.GetBytes(20);
            for (int i = 0; i < 20; i++)
            {
                if (hashBytes[i + 16] != hashedPswd[i])
                {
                    isEqual = false;
                    break;
                }
            }
            return isEqual;
        }

    }

    class FileMaker
    {
        public static FileContentResult FileWriter(string fileName, string data, string contentType)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(data);
            var file = new FileContentResult(bytes, contentType);
            file.FileDownloadName = fileName;
            return file;
        }
    }
}