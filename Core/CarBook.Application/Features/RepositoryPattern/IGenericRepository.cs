namespace CarBook.Application.Features.RepositoryPattern
{
    public interface IGenericRepository<T> where T : class
    {
        List<T> GetAll();
        void Create(T entity);
        void Delete(int id);
        void Update(T entity);
        T GetById(int id);
    }

}
