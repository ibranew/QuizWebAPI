using Microsoft.EntityFrameworkCore;
using QuizWebAPI.Application.Abstractions.Repositories;
using QuizWepAPI.Persistence.Contexts;
using QuizWepAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace QuizWepAPI.Persistence.Concretes.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        public DbSet<T> Table => _context.Set<T>();
        private readonly QuizWebAPIDbContext _context;

        public Repository(QuizWebAPIDbContext context)
        {
            _context = context;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        private IQueryable<T> ApplyTracking(bool tracking)
        {
            return tracking ? Table : Table.AsNoTracking();
        }

        // Add
        public async Task AddAsync(T entity)
        {
            await Table.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await Table.AddRangeAsync(entities);
        }

        // Get
        public async Task<IEnumerable<T>> GetAllAsync(bool tracking = true)
        {
            return await ApplyTracking(tracking).ToListAsync();
        }

        public async Task<IEnumerable<T>> GetByConditionAsync(Expression<Func<T, bool>> expression, bool tracking = true)
        {
            return await ApplyTracking(tracking).Where(expression).ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid id, bool tracking = true)
        {
            var query = ApplyTracking(tracking);
            var entity = await query.FirstOrDefaultAsync(e => EF.Property<Guid>(e, "Id") == id);

            if (entity == null)
            {
                throw new KeyNotFoundException($"The entity with ID '{id}' was not found.");
            }

            return entity;
        }

        // Update
        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void UpdateRange(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                _context.Entry(entity).State = EntityState.Modified;
            }
        }

        // Delete
        public void Delete(T entity)
        {
           Table.Remove(entity);
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            Table.RemoveRange(entities);
        }
    }


}
