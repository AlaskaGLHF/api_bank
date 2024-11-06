namespace api_bank.Interfaces
{
    using api_bank.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICardRepository
    {
        Task<Card?> GetByIdAsync(int id);
        Task<List<Card>> GetAllAsync();
        Task AddAsync(Card card);
        Task UpdateAsync(Card card);
        Task DeleteAsync(int id);
    }
}
