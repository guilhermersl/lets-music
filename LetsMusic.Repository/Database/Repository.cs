using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using LetsMusic.CrossCutting.Interfaces.Data;
using LetsMusic.Data.Contexto;
using System.Data;
using System.Linq.Expressions;

namespace LetsMusic.Data.Database
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected DbSet<T> Query { get; set; }
        protected DbContext Context { get; set; }

        public Repository(LetsMusicContext context)
        {
            Context = context;
            Query = Context.Set<T>();
        }

        public async Task<IDbContextTransaction> CreatTransaction()
        {
            return await Context.Database.BeginTransactionAsync();
        }

        public async Task<IDbContextTransaction> CreatTransaction(IsolationLevel isolation)
        {
            return await Context.Database.BeginTransactionAsync(isolation);
        }

        public async Task Delete(T entity)
        {
            Query.Remove(entity);
            await Context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T?>> FindAllByCriteria(Expression<Func<T, bool>> expression)
        {
            return await Query.AsNoTrackingWithIdentityResolution()
                              .Where(expression)
                              .ToListAsync();
        }

        public async Task<T?> FindOneByCriteria(Expression<Func<T, bool>> expression)
        {
            return await Query.AsNoTrackingWithIdentityResolution()
                              .FirstOrDefaultAsync(expression);
        }

        public async Task<T?> Get(object id)
        {
            return await Query.FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await Query.AsNoTrackingWithIdentityResolution()
                              .ToListAsync();
        }

        public async Task Save(T entity)
        {
            await Query.AddAsync(entity);
            await Context.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            Query.Update(entity);
            await Context.SaveChangesAsync();
        }
    }
}
