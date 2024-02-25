namespace Server.Data.Contracts
{
    public interface IHasLastLogin
    {
        public DateTimeOffset LastLogin { get; set; }
    }
}
