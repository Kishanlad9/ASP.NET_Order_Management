namespace Order_management.Helpers
{
    public class ApiResponse<T>
    {
        public bool? Success { get; set; }
        public String Message { get; set; } = string.Empty;
        public T? Data { get; set; }

        public static ApiResponse<T> SuccessResponse(String msg, T getData)
        {
            return new ApiResponse<T>
            {
                Success = true,
                Message = msg,
                Data = getData
            };
        }

        public static ApiResponse<T> ErrorResponse(String msg)
        {
            return new ApiResponse<T>
            {
                Success = false,
                Message = msg,
                Data = default
            };
        }
    }
    
}
