namespace Ambev.DeveloperEvaluation.Domain.Common;

public class PaginatedQueryResult<T>
{
    public PaginatedQueryResult(IEnumerable<T> data, int currentPage, int totalItems, int pageSize)
    {
        CurrentPage = currentPage;
        TotalItems = totalItems;
        Data = data;
        TotalPages = (int)Math.Ceiling((decimal)totalItems / (decimal)pageSize);
    }

    public int CurrentPage { get; set; }
    public int TotalPages { get; set; }
    public int TotalItems { get; set; }
    public IEnumerable<T> Data { get; set; } = [];
}