using System.Net;

namespace WealthCompany.Core.Model
{
    public class ResultModel
    {
        public HttpStatusCode Code { get; set; }

        public string Message { get; set; }

        public object Data { get; set; }
    }
}