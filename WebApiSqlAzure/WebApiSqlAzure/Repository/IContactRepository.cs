using WebApiSqlAzure.Model;

namespace WebApiSqlAzure.Repository
{
    public interface IContactRepository
    {
        Task<IEnumerable<Contact>> GetAllAsync();

        Task<Contact> GetAsync(int id); 

        Task<Contact> AddAsync(Contact contact);    
        Task<Contact> UpdateAsync(int id, Contact contact);
        Task<Contact> DeleteAsync(int id);

        Task<bool> ContactExists(int id);
    }
}
