namespace Izeem.Domain.Configurations;

public class PaginationMetaData
{
    public int CurrentPage { get; set; }
    public int TotalPages { get; set; }
    public int TotalCount { get; set; }
    public bool HasPrevious => CurrentPage > 1;
    public bool HasNext => CurrentPage < TotalPages;

    public PaginationMetaData(int totalCount, PaginationParams pagination)
    {
        TotalCount = totalCount;
        TotalPages = (int)Math.Ceiling(totalCount / (double)pagination.PageSize);
        CurrentPage = pagination.PageIndex;
    }
}
