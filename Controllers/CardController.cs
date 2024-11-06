using api_bank.Models;
using api_bank.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class CardsController : ControllerBase
{
    private readonly CardService _cardService;

    public CardsController(CardService cardService)
    {
        _cardService = cardService;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Card>> GetCardById(int id)
    {
        var card = await _cardService.GetCardByIdAsync(id);
        if (card == null)
        {
            return NotFound();
        }
        return Ok(card);
    }

    [HttpGet]
    public async Task<ActionResult<List<Card>>> GetAllCards()
    {
        return Ok(await _cardService.GetAllCardsAsync());
    }

    [HttpPost]
    public async Task<IActionResult> AddCard(Card card)
    {
        await _cardService.AddCardAsync(card);
        return CreatedAtAction(nameof(GetCardById), new { id = card.CardId }, card);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCard(int id, Card card)
    {
        if (id != card.CardId)
        {
            return BadRequest();
        }

        await _cardService.UpdateCardAsync(card);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCard(int id)
    {
        await _cardService.DeleteCardAsync(id);
        return NoContent();
    }
}
