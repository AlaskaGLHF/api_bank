using api_bank.Interfaces;
using api_bank.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api_bank.Services
{
    public class CardService
    {
        private readonly ICardRepository _cardRepository;

        public CardService(ICardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }

        public Task<Card?> GetCardByIdAsync(int id)
        {
            return _cardRepository.GetByIdAsync(id);
        }

        public Task<List<Card>> GetAllCardsAsync()
        {
            return _cardRepository.GetAllAsync();
        }

        public Task AddCardAsync(Card card)
        {
            return _cardRepository.AddAsync(card);
        }

        public Task UpdateCardAsync(Card card)
        {
            return _cardRepository.UpdateAsync(card);
        }

        public Task DeleteCardAsync(int id)
        {
            return _cardRepository.DeleteAsync(id);
        }
    }
}
