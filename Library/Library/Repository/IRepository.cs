using System;

public interface IRepository<T, TId> where T : Entity<TId>
{
    T GetById(TId id);
    IEnumerable<T> GetAll();
    void Add(T entity);
    void Update(T entity);
    void Delete(TId id);
}