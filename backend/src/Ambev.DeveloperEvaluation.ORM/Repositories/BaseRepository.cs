using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.ORM;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

using System.Linq.Expressions;
using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore.Query;

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

    public async Task<T?> Find(Guid id, CancellationToken cancellationToken, params string[] includes)
    {
        IQueryable<T> query = _context.Set<T>();
        if (includes != null)
        {
            query = includes.Aggregate(query,
                    (current, include) => current.Include(include));
        }
        return await query.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public IQueryable<T> Find(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
    {
        return _context.Set<T>().Where(predicate);
    }

    public async Task<T?> FindFirstOrDefaultAsync(System.Linq.Expressions.Expression<Func<T, bool>> predicate, System.Threading.CancellationToken cancellationToken = default)
    {
        return await _context.Set<T>().FirstOrDefaultAsync<T>(predicate, cancellationToken);
    }

    public async Task<PaginatedQueryResult<T>> ListAsync(int pageNumber, int pageSize, string order, CancellationToken cancellationToken = default, params string[] includes)
    {
        var totalRecords = await _context.Set<T>().AsNoTracking().CountAsync();

        IQueryable<T> query = _context.Set<T>().AsNoTracking();
        if (includes != null)
        {
            query = includes.Aggregate(query,
                    (current, include) => current.Include(include));
        }

        var entities = await query
            .OrderBy(order)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);

        var pagedResponse = new PaginatedQueryResult<T>(entities, pageNumber, totalRecords, pageSize);

        return pagedResponse;
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
