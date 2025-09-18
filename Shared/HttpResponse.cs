
namespace MyApp.Shared
{
    public class HttpResponse
    {
        private string _myHttpResponse = null;
        private int _status;
        public string MyHttpResponse { get => _myHttpResponse; set => _myHttpResponse = value; }
        public int Status { get => _status; set => _status = value; }
        internal void Send(string rawHtml)
        {
            HttpBody.Put(rawHtml);
        }

    }
}