namespace Server.Responses
{
    public class PageInsuranceResponse<T> : InsuranceResponse<T>
    {
        public int Page { get; set; }

        public int Limit { get; set; }

        public int Total { get; set; }

        public PageInsuranceResponse(IEnumerable<T> data, int page, int size, int total) : base(data)
        {
            Page = page;
            Limit = size;
            Data = data;
            Total = total;
        }
    }
}
