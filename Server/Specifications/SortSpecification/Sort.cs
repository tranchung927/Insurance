namespace Server.Specifications.SortSpecification
{
    public class Sort<T>
    {
        public OrderBySpecification<T> OrderBy { get; set; }
        public SortingDirectionSpecification SortingDirection { get; set; }
    }
}
