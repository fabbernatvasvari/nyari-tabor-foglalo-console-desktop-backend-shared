using MyApp.Shared.Models;
using Params;
namespace MyApp.Shared
{
    public class HttpRequest
    {
        private string _myHttpRequest = null;
        Params Params = new Params();
        HttpBody Body = new HttpBody();

        public string MyHttpRequest { get => _myHttpRequest; set => _myHttpRequest = value; }
        
    }
}