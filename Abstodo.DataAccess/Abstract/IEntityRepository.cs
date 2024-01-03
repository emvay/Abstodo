namespace Abstodo.DataAccess.Abstract
{
    public interface IEntityRepository<T> where T : class/*, IEntity, new()*/ // We are restricting the T type with the entities that are an IEntity objects and It new() can be used for them
    {
        //List<T> GetAll(Expression<Func<T, bool>> filter = null);
        //T Get(Expression<Func<T, bool>> filter); // (int id)
        //void Add(T entity);
        //void Update(T entity);
        //void Delete(T entity);
        Task<List<T>> GetAllAsync();
        Task<T?> GetByIdAsync(object Id);
        Task InsertAsync(T Entity);
        Task UpdateAsync(T Entity);
        Task DeleteAsync(object Id);
        Task SaveAsync();
    }
}
