namespace Domain.Repositories;

public interface IRepository<T>
{
    Task Add(T entity);
    void Update(T entity);
    void Delete(T entity);
    Task<T?> Get(Guid id);
    Task<IEnumerable<T>> Get(IEnumerable<Guid> ids);
}
