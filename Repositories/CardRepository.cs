using api_bank.Interfaces;
using api_bank.Models;
using Microsoft.EntityFrameworkCore;

namespace api_bank.Repositories
{

    public class CardRepository : ICardRepository
    {
        private readonly BankContext _context;

        public CardRepository(BankContext context)
        {
            _context = context;
        }

        public async Task<Card?> GetByIdAsync(int id)
        {
            foreach (var card in await _context.Cards.ToListAsync())
            {
                if (card.CardId == id && (!card.IsDeleted.HasValue || !card.IsDeleted.Value))
                {
                    return card;
                }
            }
            return null;
        }

        public async Task<List<Card>> GetAllAsync()
        {
            var result = new List<Card>();
            var allCards = await _context.Cards.ToListAsync();

            foreach (var card in allCards)
            {
                if (!card.IsDeleted.HasValue || !card.IsDeleted.Value)
                {
                    result.Add(card);
                }
            }

            return result;
        }

        public async Task AddAsync(Card card)
        {
            await _context.Cards.AddAsync(card);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Card card)
        {
            var existingCard = await GetByIdAsync(card.CardId);
            if (existingCard != null)
            {
                existingCard.CardNumber = card.CardNumber;
                existingCard.Balance = card.Balance;
                existingCard.IsDeleted = card.IsDeleted;

                _context.Cards.Update(existingCard);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var card = await GetByIdAsync(id);
            if (card != null)
            {
                card.IsDeleted = true;
                _context.Cards.Update(card);
                await _context.SaveChangesAsync();
            }
        }
    }
}
