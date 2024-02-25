namespace Server.Specifications.SortSpecification
{
    public class SortSpecification<T>
    {

        public List<Sort<T>> SortElements { get; }

        public SortSpecification(OrderBySpecification<T> sort, SortingDirectionSpecification order)
        {
            SortElements = new List<Sort<T>>()
            {
                new() {OrderBy = sort, SortingDirection = order}
            };
        }

        public static SortSpecification<T> operator &(SortSpecification<T> left, SortSpecification<T> right) => CombineSpecification(left, right);

        private static SortSpecification<T> CombineSpecification(SortSpecification<T> left, SortSpecification<T> right)
        {
            left.SortElements.AddRange(right.SortElements);
            return left;
        }

        public SortSpecification<T> And(SortSpecification<T> other)
        {
            return this & other;
        }
    }
}
