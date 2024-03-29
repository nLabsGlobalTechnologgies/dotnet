﻿using NewRepositoryDesignPattern.Context;
using NewRepositoryDesignPattern.Interfaces;

namespace NewRepositoryDesignPattern.Repositories;

public class Repository<T>(AppDbContext context, IUnitOfWork unitOfWork) : IRepository<T>
    where T : class
{
    public void Add(T entity)
    {
        context.Set<T>().Add(entity);
        unitOfWork.SaveChanges();
    }

    public void Update(T entity)
    {
        context.Set<T>().Update(entity);
    }

    public void Delete(T entity)
    {
        context.Set<T>().Remove(entity);
    }

    public List<T> GetAll()
    {
        return context.Set<T>().ToList();
    }
}
