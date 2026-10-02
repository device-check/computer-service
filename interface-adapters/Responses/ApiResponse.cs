namespace interface_adapters.Responses
{
    public class ApiResponse<T>
    {
        public T? Data { get; init; }
        public ApiResponseMetadata MetaData { get; init; }
    }
}
