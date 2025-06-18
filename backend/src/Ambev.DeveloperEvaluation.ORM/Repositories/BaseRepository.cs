using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.ORM;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

[ExcludeFromCodeCoverage]
public class BaseRepository<T>
    : IDisposable where T : BaseEntity
{
    private readonly DefaultContext _context;
    public BaseRepository(DefaultContext context)
    {
        _context = context;
    }

    public async Task<T?> Find(Guid id, CancellationToken cancellationToken)
    {
        return await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public IQueryable<T> Find(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
    {
        return _context.Set<T>().Where(predicate);
    }

    public async Task<T?> FindFirstOrDefaultAsync(System.Linq.Expressions.Expression<Func<T, bool>> predicate, System.Threading.CancellationToken cancellationToken = default)
    {
        return await _context.Set<T>().FirstOrDefaultAsync<T>(predicate, cancellationToken);
    }

    public IQueryable<T> List()
    {
        return _context.Set<T>();
    }

    public async Task Add(T item, CancellationToken cancellationToken)
    {
        await _context.Set<T>().AddAsync(item, cancellationToken);
    }

    public void Remove(T item)
    {
        _context.Set<T>().Remove(item);
    }

    public void Update(T item)
    {
        _context.Entry(item).State = EntityState.Modified;
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
