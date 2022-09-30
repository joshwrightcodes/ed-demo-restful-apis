using System.Text.Json.Serialization;

namespace WrightCodes.Demo.RestfulDesign.Application.Common.Results;

public class PaginatedResult<TResult>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PaginatedResult{TResult}" /> class.
    /// </summary>
    /// <param name="items">
    /// Collection of items to add to results page.
    /// </param>
    /// <param name="totalCount">
    /// Total count of items in results.
    /// </param>
    /// <param name="pageIndex">
    /// Position of page in the complete set of results based on
    /// <paramref name="pageSize" />.
    /// </param>
    /// <param name="pageSize">
    /// Maximum number of items in a page of results.
    /// </param>
    public PaginatedResult(List<TResult> items, int totalCount, int pageIndex, int pageSize)
    {
        PageNumber = pageIndex;
        PageCount = (int)Math.Ceiling(totalCount / (double)pageSize);
        TotalCount = totalCount;
        Items = items;
        PageSize = pageSize;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="PaginatedResult{TResult}" /> class.
    /// Constructor for deserialization.
    /// </summary>
    [JsonConstructor]
    public PaginatedResult()
    {
    }

    public int PageNumber { get; }

    public int PageCount { get; }

    public int PageSize { get; }

    public IList<TResult> Items { get; }

    /// <summary>
    /// Gets a value representing the total number of records in a set of results.
    /// </summary>
    [JsonInclude]
    public int TotalCount { get; private set; }

    /// <summary>
    /// Gets a value indicating whether there is a previous set of results.
    /// </summary>
    /// <value>
    /// Returns <c>true</c> if there are more than one page of results and the user
    /// is not on the first page, otherwise <c>false</c> is returned.
    /// </value>
    public bool HasPreviousPage => PageNumber > 1;

    /// <summary>
    /// Gets a value indicating whether there is another set of results.
    /// </summary>
    /// <value>
    /// Returns <c>true</c> if there are more than one page of results and the user
    /// is not on the last page, otherwise <c>false</c> is returned.
    /// </value>
    public bool HasNextPage => PageNumber < PageCount;
}