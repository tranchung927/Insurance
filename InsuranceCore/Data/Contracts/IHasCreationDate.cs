namespace InsuranceCore.Data.Contracts
{
    public interface IHasCreationDate
    {
        public DateTimeOffset PublishedAt { get; set; }
    }
}
