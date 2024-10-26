using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PhAppUser.Domain.Interfaces
{
    /// <summary>
    /// Interfaz genérica que define las operaciones CRUD básicas.
    /// </summary>
    /// <typeparam name="TEntity">Entidad de dominio con la que trabajará el repositorio.</typeparam>
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetByIdAsync(int id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);
        Task AddAsync(TEntity entity);
        void Update(TEntity entity);
        void Remove(TEntity entity);
        Task<int> SaveChangesAsync();
    }
}
