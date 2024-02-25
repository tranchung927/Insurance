using System.Collections.Generic;

namespace Server.Responses
{
    public class InsuranceResponse<T>
    {
        public InsuranceResponse(IEnumerable<T> data)
        {
            Data = data;
        }
        public IEnumerable<T> Data { get; set; }
    }
}
