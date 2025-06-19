namespace Ambev.DeveloperEvaluation.WebApi.Common;

public class PaginationApiCommand
{
    public int Page { get; set; }
    public int Size { get; set; }
    public string Order { get; set; } = string.Empty;
}
