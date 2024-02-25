namespace Server.Data.Contracts
{
    public interface IHasModificationDate
    {
        public DateTimeOffset? ModifiedAt { get; set; }
    }
}
