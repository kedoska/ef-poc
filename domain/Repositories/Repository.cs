using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

public class Repository<T> where T : class
{
    private readonly AppDbContext _context;
    private DbSet<T> entities;

    public Repository(AppDbContext context)
    {
        _context = context;
        entities = context.Set<T>();
    }

    public async Task<IEnumerable<T>> GetAll()
    {
        return await entities.ToListAsync();
    }

    public async Task Add(T entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }

        await entities.AddAsync(entity);
    }

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }
}