using Microsoft.EntityFrameworkCore;
using OfferOasisBackend.Data;

namespace OfferOasisBackend.Service.Repository.Message;

public class MessageRepository :IMessageRepository
{
    private readonly OasisContext _oasisContext;

    public MessageRepository(OasisContext oasisContext)
    {
        _oasisContext = oasisContext;
    }

    public async Task<Model.Message?> GetById(int id)
    {
        return await _oasisContext.Messages.FindAsync(id);
    }
    
    public async Task<IEnumerable<Model.Message?>> GetAll()
    {
     
        return await _oasisContext.Messages.ToListAsync();
    }
    
    public async Task<bool> Add(Model.Message message)
    {
        bool success = true;
        try
        {
            await _oasisContext.AddAsync(message);
            await _oasisContext.SaveChangesAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            success = false;
        }

        return success;
    }
    
    public async Task<Model.Message?> Remove(int id)
    {
     
        var messageToRemove = await GetById(id);

        if (messageToRemove == null) return messageToRemove;
        _oasisContext.Remove(messageToRemove);
        await _oasisContext.SaveChangesAsync();

        return messageToRemove;
    }
}