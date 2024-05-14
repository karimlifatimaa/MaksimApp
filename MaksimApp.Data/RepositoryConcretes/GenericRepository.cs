﻿using MaksimApp.Core.Models;
using MaksimApp.Core.RepositoryAbstracts;
using MaksimApp.Data.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaksimApp.Data.RepositoryConcretes
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity, new()
    {
        private readonly AppDbContext _context;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public int Commit()
        {
            return _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public List<T> GetAll(Func<T, bool>? func = null)
        {
            return func == null ?
                _context.Set<T>().ToList() :
                _context.Set<T>().Where(func).ToList();

        }

        public T Get(Func<T, bool>? func = null)
        {
            return func == null ?
                _context.Set<T>().FirstOrDefault() :
                _context.Set<T>().FirstOrDefault(func);
        }
    }
}
