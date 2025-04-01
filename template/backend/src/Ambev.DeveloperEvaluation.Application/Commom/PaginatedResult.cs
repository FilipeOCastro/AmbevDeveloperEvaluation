namespace Ambev.DeveloperEvaluation.Application.Common
{
    public abstract class PaginatedResult
    {
        public int TotalItems { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
    }
}
