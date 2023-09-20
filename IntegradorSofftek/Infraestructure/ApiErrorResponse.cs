namespace IntegradorSofftek.Infraestructure
{
    public class ApiErrorResponse
    {
        public int Status { get; set; }
        public List<ResponseError> Error { get; set; }

        public class ResponseError
        {
            public String? Error { get; set; }
        }
    }
}
