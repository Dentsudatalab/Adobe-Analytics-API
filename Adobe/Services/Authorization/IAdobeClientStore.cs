namespace Adobe.Services.Authorization
{
    using Utility.Auth;

    public interface IAdobeClientStore
    {
        IdentityClient Client { get; set; }
    }
}