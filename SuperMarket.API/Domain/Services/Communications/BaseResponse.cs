namespace SuperMarket.API.Domain.Services.Communications
{
    public abstract class BaseResponse<T>
    {
        protected BaseResponse(T resource)
        {
            Resource = resource;
            Succes = true;
            Message = string.Empty;
        }

        protected BaseResponse(string message)
        {
            Message = message;
            Succes = true;
            
        }

        public bool Succes { get; set; }
        public string Message { get; protected set; }
        public T Resource { get; set; }
        
        
    }
}