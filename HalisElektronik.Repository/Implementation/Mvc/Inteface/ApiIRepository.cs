using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface ApiIRepository<T> where T : class
{
    Task<T> GetItemByIdAsync(string ApiAction, int id);
    Task<IEnumerable<T>> GetAllItemsAsync(string ApiAction);
    Task<bool> AddItemAsync(string ApiAction, T item);
    Task<bool> UpdateItemAsync(string ApiAction, T item);
    Task<bool> DeleteItemAsync(string ApiAction, int id);
    Task<IEnumerable<T>> GetListById(string ApiAction, int id);
}
