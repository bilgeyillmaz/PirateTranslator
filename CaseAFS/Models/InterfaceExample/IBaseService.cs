namespace CaseAFS.Models.InterfaceExample
{
    public interface IBaseService<T>
    {
        void Add(T t);
        void Delete(T t);
        void Update(T t);
        List<T> GetAll();
        T GetById(int id);
    }
}
