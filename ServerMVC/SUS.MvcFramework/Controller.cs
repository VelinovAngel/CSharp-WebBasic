namespace SUS.MvcFramework
{
    using System.Text;
    using System.Runtime.CompilerServices;

    using SUS.Http;
    using SUS.Http.Enums;
    using SUS.MvcFramework.ViewEngine;

    public abstract class Controller
    {
        private const string UserIdSessionName = "UserId";
        private SusViewEngine viewEngine;

        public Controller()
        {
            this.viewEngine = new SusViewEngine();
        }

        protected void SignIn(string userId)
        {
            this.Request.Session[UserIdSessionName] = userId;
        }

        protected void SignOut()
        {
            this.Request.Session[UserIdSessionName] = null;
        }

        protected bool IsUserSignIn() =>
            this.Request.Session.ContainsKey(UserIdSessionName) &&
            this.Request.Session.ContainsKey(UserIdSessionName) != null;
            

        protected string GetUserId() =>
            this.Request.Session.ContainsKey(UserIdSessionName) ?
            this.Request.Session[UserIdSessionName] : null;


        protected HttpResponse View(object viewModel = null, [CallerMemberName] string viewPath = null)
        {
            var viewContent = System.IO.File.ReadAllText("Views/" + this.GetType().Name.Replace("Controller", string.Empty) + "/" + viewPath + ".cshtml");
            viewContent = this.viewEngine.GetHtml(viewContent, viewModel, this.GetUserId());
            var responseHtml = this.PutViewLayout(viewContent, viewModel);
            var responseBodyBytes = Encoding.UTF8.GetBytes(responseHtml);
            var response = new HttpResponse("text/html", responseBodyBytes);
            return response;
        }

        protected HttpResponse Error(string errorText)
        {
            var viewContent = $"<div class=\"alert alert-danger\" role=\"alert\">{errorText}</div>";
            var responseHtml = this.PutViewLayout(viewContent);
            var responseBodyBytes = Encoding.UTF8.GetBytes(responseHtml);
            var response = new HttpResponse("text/html", responseBodyBytes, HttpStatusCode.ServerError);
            return response;
        }

        protected HttpResponse Successful(string successful)
        {
            var viewContent = $"<div class=\"alert alert-success\" role=\"alert\">{successful}</div>";
            var responseHtml = this.PutViewLayout(viewContent);
            var responseBodyBytes = Encoding.UTF8.GetBytes(responseHtml);
            var response = new HttpResponse("text/html", responseBodyBytes, HttpStatusCode.ServerError);
            return response;
        }

        private string PutViewLayout(string viewContent, object viewModel = null)
        {
            var layout = System.IO.File.ReadAllText("Views/Shared/_Layout.cshtml");
            layout = layout.Replace("@RenderBody()", "_____VIEW_GOES_HERE_____");
            layout = this.viewEngine.GetHtml(layout, viewModel, this.GetUserId());
            var responseHtml = layout.Replace("_____VIEW_GOES_HERE_____", viewContent);
            return responseHtml;
        }

        public HttpRequest Request { get; set; }

        protected HttpResponse File(string filePath, string contentType)
        {
            var fileBytes = System.IO.File.ReadAllBytes(filePath);
            var response = new HttpResponse(contentType, fileBytes);
            return response;
        }

        protected HttpResponse Redirect(string url)
        {
            var response = new HttpResponse(HttpStatusCode.Found);
            response.Headers.Add(new Header("Location", url));
            return response;
        }
    }
}
