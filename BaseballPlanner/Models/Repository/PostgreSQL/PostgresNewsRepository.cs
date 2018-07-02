using ClubGrid.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ClubGrid.Repository.PostgreSQL
{
    public class PostgresNewsRepository : INewsRepository
    {
        private readonly AppDbContext _appDbContext;

        public PostgresNewsRepository(AppDbContext context)
        {
            _appDbContext = context;
        }

        public void Add(News entity, bool commit = true)
        {
            _appDbContext.News.Add(entity);

            if (commit)
                _appDbContext.SaveChanges();
        }

        public void AddRange(IEnumerable<News> entities, bool commit = true)
        {
            _appDbContext.News.AddRange(entities);

            if (commit)
                _appDbContext.SaveChanges();
        }

        public void CommitChanges()
        {
            _appDbContext.SaveChanges();
        }

        public IEnumerable<News> Find(Expression<Func<News, bool>> predicate)
        {
            return _appDbContext.News.Where(predicate.Compile()).ToList();
        }

        public News Get(int id)
        {
            return _appDbContext.News.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<News> GetAll()
        {
            return _appDbContext.News;
        }

        public IEnumerable<News> GetLastItems(int count)
        {
            return _appDbContext.News.OrderBy(x => x.Created).Take(count);
        }

        public void Remove(News entity, bool commit = true)
        {
            _appDbContext.News.Remove(entity);

            if (commit)
                _appDbContext.SaveChanges();
        }

        public void RemoveRange(IEnumerable<News> entities, bool commit = true)
        {
            _appDbContext.News.RemoveRange(entities);

            if (commit)
                _appDbContext.SaveChanges();
        }
    }
}
