namespace InsuranceCore.Data.Contracts
{
    public interface IHasModificationDate
    {
        public DateTimeOffset? ModifiedAt { get; set; }
    }
}
