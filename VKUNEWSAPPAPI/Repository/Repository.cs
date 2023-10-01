using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using VKUNEWSAPPAPI.Data.Repository.Interface;
using VKUNEWSAPPAPI.Data;

namespace VKUNEWSAPPAPI.Data.Repository;

public abstract class Repository<T> : IRepository<T> where T : class
{
    public Repository(VKUNEWSAPPAPIDbContext vkunewsappapicontext)
    {
        VKUContext = vkunewsappapicontext;
    }

    protected VKUNEWSAPPAPIDbContext VKUContext { get; set; }

    public async Task<IEnumerable<T>> FindAllAsync()
    {
        return await VKUContext.Set<T>().ToListAsync();
    }

    public async Task<IEnumerable<T>> FindByConditionAsync(Expression<Func<T, bool>> expression)
    {
        var query = VKUContext.Set<T>().Where(expression);
        return await query.AnyAsync() ? await query.ToListAsync() : Enumerable.Empty<T>();
    }
    public async Task<IEnumerable<T>> FindByCondition(Expression<Func<T, bool>> expression, Expression<Func<T, object>> criteria, Expression<Func<T, object>> expression1)
    {
        return await VKUContext.Set<T>().Where(expression).Include(expression1).Include(criteria).ToListAsync();
    }

    public async Task<IEnumerable<T>> FindByCondition(Expression<Func<T, bool>> expression, Expression<Func<T, object>> criteria)
    {
        return await VKUContext.Set<T>().Where(expression).Include(criteria).ToListAsync();
    }
    public async Task<IEnumerable<T>> FindByCondition(Expression<Func<T, object>> criteria, Expression<Func<T, object>> expression)
    {
        return await VKUContext.Set<T>().Include(expression).Include(criteria).ToListAsync();
    }
    public async Task<T> CreateAsync(T entity)
    {
        var result = await VKUContext.Set<T>().AddAsync(entity);
        await VKUContext.SaveChangesAsync();

        return result.Entity;
    }

    public async Task<T> UpdateAsync(T entity)
    {
        VKUContext.Entry(entity).State = EntityState.Modified;
        await VKUContext.SaveChangesAsync();
        return entity;
    }

    public async Task<T> DeleteAsync(T entity)
    {
        VKUContext.Set<T>().Remove(entity);
        await VKUContext.SaveChangesAsync();
        return entity;
    }
    public async Task<T> FindById(Expression<Func<T, bool>> expression)
    {
        var result = await VKUContext.Set<T>().Where(expression).FirstAsync();
        return result;
    }
}