using api_bank.Models;

namespace api_bank.Interfaces
{
    public interface ICardService
    {
        Task AddCardAsync(Card card);
        Task DeleteCardAsync(int id);
        Task<List<Card>> GetAllCardsAsync();
        Task<Card?> GetCardByIdAsync(int id);
        Task UpdateCardAsync(Card card);
    }
}