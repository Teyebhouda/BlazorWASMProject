using ReportProjectV1.Shared.Models;

namespace ReportProjectV1.Client.Services
{
    public interface IGenericServices<T> where T : BaseEntity
    { 
        Task<IEnumerable<T>> GetAll();
        Task<T> GetByIdAsync(int id);
        Task<T> CreateAsync(T obj);
        Task<bool> DeleteAsync(int id);
        Task<bool> UpdateAsync(T obj);
       /* Task<IEnumerable<T>> SearchAsync(string searchText);*/


       
    }
}
