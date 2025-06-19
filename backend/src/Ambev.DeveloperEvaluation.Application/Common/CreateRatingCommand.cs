namespace Ambev.DeveloperEvaluation.Application.Common;

/// <summary>
/// Command to create a new rating in the system.
/// </summary>
public class CreateRatingCommand
{
    /// <summary>
    /// Gets the rating's rate.
    /// Must not be null or empty and between 0 and 5.
    /// </summary>
    public decimal Rate { get; set; }

    /// <summary>
    /// Gets the rating's count.
    /// Must not be null and greater or equal to 0.
    /// </summary>
    public int Count { get; set; }
}