using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrlShortener.Application
{
    public class UrlShortener
    {
        private const string Characters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        private const int Base = 62;

        private Dictionary<string, string> shortToLongUrlMap;
        private Dictionary<string, string> longToShortUrlMap;

        public UrlShortener()
        {
            shortToLongUrlMap = new Dictionary<string, string>();
            longToShortUrlMap = new Dictionary<string, string>();
        }

        public string ShortenUrl(string longUrl)
        {
            if (longToShortUrlMap.ContainsKey(longUrl))
            {
                return longToShortUrlMap[longUrl];
            }

            var shortUrl = GenerateShortUrl();
            shortToLongUrlMap[shortUrl] = longUrl;
            longToShortUrlMap[longUrl] = shortUrl;

            return shortUrl;
        }
        private string GenerateShortUrl()
        {
            var random = new Random();
            var buffer = new char[8];

            for (var i = 0; i < buffer.Length; i++)
            {
                buffer[i] = Characters[random.Next(Characters.Length)];
            }

            return new string(buffer);
        }
    }
}
