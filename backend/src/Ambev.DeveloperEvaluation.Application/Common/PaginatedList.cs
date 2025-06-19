using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.Application.Common;

public class PaginatedList<T>
{
    public PaginatedList(IEnumerable<T> data, int currentPage, int totalPages, int totalItems)
    {
        CurrentPage = currentPage;
        TotalPages = totalPages;
        TotalItems = totalItems;
        Data = data;
    }

    public int CurrentPage { get; set; }
    public int TotalPages { get; set; }
    public int TotalItems { get; set; }
    public IEnumerable<T> Data { get; set; } = [];
}