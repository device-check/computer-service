namespace interface_adapters.Responses
{
    public class MetadataPagination
    {
        public int CurrentPage { get; init; }
        public int PageSize { get; init; }
        public int TotalItems { get; init; }
        public int TotalPages { get; init; }
    }
}