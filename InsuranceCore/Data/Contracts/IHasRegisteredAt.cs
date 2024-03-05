namespace InsuranceCore.Data.Contracts
{
    public interface IHasRegisteredAt
    {
        public DateTimeOffset RegisteredAt { get; set; }
    }
}
