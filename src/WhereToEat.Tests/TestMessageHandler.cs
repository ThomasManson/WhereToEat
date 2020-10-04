namespace WhereToEat.Tests
{
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading;
    using System.Threading.Tasks;

    public class TestMessageHandler : HttpMessageHandler
    {
        private readonly HttpStatusCode responseCode;
        private readonly string responseMessage;

        public TestMessageHandler(HttpStatusCode responseCode, string responseMessage)
        {
            this.responseCode = responseCode;
            this.responseMessage = responseMessage;
        }

        public HttpRequestHeaders RequestHeaders { get; private set; }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            this.RequestHeaders = request.Headers;

            return Task.FromResult(new HttpResponseMessage(this.responseCode) { Content = new StringContent(this.responseMessage) });
        }
    }
}
