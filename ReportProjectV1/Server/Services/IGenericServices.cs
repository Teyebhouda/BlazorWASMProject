using ReportProjectV1.Shared.Models;

namespace ReportProjectV1.Server.Services
{
    public interface IGenericServices<T>
    {

        Task<List<User>> getAll();
      /*  T this[int id] { get; }
        T AddUser(T obj);
        T UpdateUser(T obj);
        void DeleteUser(int id);*/
    }
}
