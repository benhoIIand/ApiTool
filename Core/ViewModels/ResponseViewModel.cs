namespace Core.ViewModels
{
    public class ResponseViewModel
    {
        public string Response { get; set; }
        public string AuthHeaders { get; set; }
        public string Url { get; set; }
        public string PostParameters { get; set; }
        public string PartnerId { get; set; }
        public string ConsumerKey { get; set; }
        public string ConsumerSecret { get; set; }
    }
}