using System.Linq;

namespace Shorty
{
    public static class IdentifierGenerator
    {
        private const string Alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        private static readonly int _base = Alphabet.Length;

        public static string Encode(int index)
        {
            if (index == 0) 
                return Alphabet[0].ToString();

            var encoded = string.Empty;
            while (index > 0) 
            {
                encoded += Alphabet[index % _base];
                index = index / _base;
            }

            return string.Join(string.Empty, encoded.Reverse());
        }
    }
}