namespace Ambev.DeveloperEvaluation.Common.Transaction;

/// <summary>
/// interface for unit of work pattern
/// </summary>
public interface IUnitOfWork
{
    /// <summary>
    /// Commit db transactions
    /// </summary>
    void Commit();

    /// <summary>
    /// Rollback db transactions
    /// </summary>
    void Rollback();
}