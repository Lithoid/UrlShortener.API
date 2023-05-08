namespace UrlShortener.API.Models.Requests
{
    public class UpdateUrlRequest
    {
        public Guid Id { get; set; }
        public string OriginalUrl { get; set; }
        public string ShortUrl { get; set; }

        public DateTime CreationDate { get; set; }


    }
}
