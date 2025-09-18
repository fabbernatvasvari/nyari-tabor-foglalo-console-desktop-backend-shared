using MyApp.Shared;
using MyApp.Shared.Controllers;

internal class App
{
    HttpRequest myHttpRequest = new HttpRequest();
    HttpResponse myHttpResponse = new HttpResponse();

    public void createEndPoints()
    {
        UserController.Get("/", myHttpRequest, myHttpResponse);
    }
}