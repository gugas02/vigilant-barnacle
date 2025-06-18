using Ambev.DeveloperEvaluation.Common.Transaction;

namespace Ambev.DeveloperEvaluation.ORM.Transaction;

public class UnitOfWork : IUnitOfWork
{
    private readonly DefaultContext _context;

    public UnitOfWork(DefaultContext context)
    {
        _context = context;
    }

    public void Commit()
    {
        _context.SaveChanges();
    }

    public void Rollback()
    {
        // if commit is not called rollback is automatically made
    }
}