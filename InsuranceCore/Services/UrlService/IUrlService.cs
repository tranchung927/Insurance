namespace InsuranceCore.Services.UrlService
{
    public interface IUrlService
    {
        public bool IsUrl(string url);

        public Task<bool> IsUrlPicture(string url, CancellationToken token);
    }
}
