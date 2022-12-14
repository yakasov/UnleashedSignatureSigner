using System.Security.Cryptography;

namespace UnleashedSignatureSigner
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter API key: ");
            string privateKey = Console.ReadLine()!;
            Console.Clear();
            while (true)
            {
                Console.Write("\nEnter URL query: ");
                string urlQuery = Console.ReadLine()!;
                if (urlQuery.Contains("?"))  // split and only use query to generate signature
                {
                    urlQuery = urlQuery.Split("?")[1];
                } else if (urlQuery.Contains(":"))  // https:// (from colon presence) but not ? means empty query
                {
                    urlQuery = "";
                }
                Console.WriteLine(GetSignature(urlQuery, privateKey));
            }
        }
        private static string GetSignature(string args, string privatekey)
        {
            var encoding = new System.Text.UTF8Encoding();
            byte[] key = encoding.GetBytes(privatekey);
            var myhmacsha256 = new HMACSHA256(key);
            byte[] hashValue = myhmacsha256.ComputeHash(encoding.GetBytes(args));
            string hmac64 = Convert.ToBase64String(hashValue);
            myhmacsha256.Clear();
            return hmac64;
        }
    }
}