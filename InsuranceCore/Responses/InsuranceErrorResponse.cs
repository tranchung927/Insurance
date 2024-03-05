namespace InsuranceCore.Responses
{
    public class InsuranceErrorResponse
    {
        public string Type { get; }

        public string Message { get; }

        public InsuranceErrorResponse(string type, string message)
        {
            Type = type;
            Message = message;
        }
    }
}
