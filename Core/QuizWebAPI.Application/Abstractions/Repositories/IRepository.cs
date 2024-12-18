using Microsoft.EntityFrameworkCore;
using QuizWepAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace QuizWebAPI.Application.Abstractions.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        DbSet<T> Table { get; }

        // Okuma işlemleri
        Task<T> GetByIdAsync(Guid id, bool tracking = true);
        Task<IEnumerable<T>> GetAllAsync(bool tracking = true);
        Task<IEnumerable<T>> GetByConditionAsync(Expression<Func<T, bool>> expression, bool tracking = true);

        // Yazma işlemleri
        Task AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);

        // Güncelleme işlemleri
        void Update(T entity);
        void UpdateRange(IEnumerable<T> entities);

        // Silme işlemleri
        void Delete(T entity);
        void DeleteRange(IEnumerable<T> entities);

        // Save işlemi
        Task<int> SaveChangesAsync(); // Etkilenen satır sayısını döndür
    }

}
