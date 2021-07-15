using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain.Interfaces;
using AutoMapper.QueryableExtensions;

namespace Domain
{
    public abstract class TeenyURLRepository<TEntity, TEntityMapping> : ITeenyURLRepository<TEntity, TEntityMapping>
        where TEntity : class
        where TEntityMapping : class
    {
        public readonly TeenyURLContext Context;
        public readonly IMapper Mapper;

        public TeenyURLRepository(TeenyURLContext context, IMapper mapper)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
            Mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        protected async Task<TEntity> AddAsync(TEntity entity)
        {
            Context.Add(entity);
            await Context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> exp)
        {
            return await Context.Set<TEntity>().AnyAsync(exp);
        }

        public async Task<TEntityMapping> FindAsync(Expression<Func<TEntity, bool>> exp)
        {
            TEntityMapping entity = null;
            try
            {
                entity = await Context.Set<TEntity>()
                .Where(exp)
                .ProjectTo<TEntityMapping>(Mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
            }
            catch(Exception ex)
            {

            }
            return entity;
        }
    }
}
