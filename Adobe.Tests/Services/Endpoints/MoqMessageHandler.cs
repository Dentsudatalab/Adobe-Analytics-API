namespace Adobe.Tests.Services.Endpoints
{
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using RichardSzalay.MockHttp;

    public class MoqMessageHandler : MockHttpMessageHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            Intermediate(request);
            return await base.SendAsync(request, cancellationToken);
        }

        public virtual void Intermediate(HttpRequestMessage request)
        {
        }
    }
}