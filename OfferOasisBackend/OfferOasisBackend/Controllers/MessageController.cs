using Microsoft.AspNetCore.Mvc;
using OfferOasisBackend.Model;
using OfferOasisBackend.Service.Repository.Message;


namespace OfferOasisBackend.Controllers;
[ApiController, Route("/message")]

public class MessageController : ControllerBase
{
    private readonly ILogger<ProductController> _logger;
    private readonly IMessageRepository _messageRepository;
    
    public MessageController(ILogger<ProductController> logger, IMessageRepository messageRepository)
    {
        _logger = logger;
        _messageRepository = messageRepository;
    }
    [HttpPost("/add")]
    
    
    public async Task<IActionResult> AddMessage(Message message)
    {
        var success = await _messageRepository.Add(message);
        if (success)
        {
            _logger.LogInformation($"Created message: {message.Content}");
            return CreatedAtAction(nameof(AddMessage), new { id = message.Id }, message);
        }
        _logger.LogError($"Could not create message {message.Content}");
        return NotFound($"Could not create message {message.Content}"); 
    }
}