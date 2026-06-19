namespace Order_management.Helper
{
    public class GenricResponse<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T? Data { get; set;}
        public List <string>?Errors { get; set; }

        public GenricResponse() { }
        public GenricResponse(bool success ,string message ,T? data  = default , List<string>? errors = null)
        {
            Success = success;
            Message = message;
            Data = data;
            Errors = errors;
        }
        public static GenricResponse<T>SuccessResponse (T data , string message = "Operation Successful")
        {
            return new GenricResponse<T>(true, message, data, null);
        }
        public static GenricResponse<T>FailureResponse(string message ,List<string>? errors =null)
        {
            return new GenricResponse<T>(false, message, default, errors);
        }   
    }
}
