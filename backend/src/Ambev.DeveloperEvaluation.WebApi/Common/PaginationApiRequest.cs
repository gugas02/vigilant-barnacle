﻿namespace Ambev.DeveloperEvaluation.WebApi.Common;

public class PaginationApiRequest : ApiRequest
{
    public int Page { get; set; } = 1;
    public int Size { get; set; } = 10;
    public string Order { get; set; } = "createdAt asc";
}
