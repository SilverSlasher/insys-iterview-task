using Microsoft.EntityFrameworkCore;
using MovieLibrary.Data.Entities;
using MovieLibrary.Data.Exceptions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieLibrary.Data.Repositories.Base
{
    public abstract class BaseRepository<T> where T : DbEntity
    {
        private readonly MovieLibraryContext _context;

        public BaseRepository(MovieLibraryContext context)
        {
            _context = context;
        }

        protected async Task<IEnumerable<T>> GetAllEntitiesAsync() => await _context.Set<T>().AsNoTracking().ToListAsync();

        protected async Task<T> GetEntityByIdAsync(int id)
        {
            var entity = await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
            ThrowIfNotExists(entity);
            return entity;
        }

        protected async Task<int> AddEntityAsync(T entity)
        {
            var nextId = (await _context.Set<T>().MaxAsync(x => (int?)x.Id) ?? 0) + 1;
            entity.Id = nextId;
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        protected async Task<int> UpdateEntityAsync(T entity)
        {
            var dbEntity = await GetEntityByIdAsync(entity.Id);
            _context.Entry(dbEntity).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
            return dbEntity.Id;
        }

        protected async Task<int> DeleteEntityAsync(int id)
        {
            var entity = await GetEntityByIdAsync(id);
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        private void ThrowIfNotExists(object obj)
        {
            if (obj == default)
                throw new EntityNotExistException();
        }
    }
}