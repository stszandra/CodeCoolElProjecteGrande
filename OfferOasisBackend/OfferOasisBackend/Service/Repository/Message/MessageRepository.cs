using OfferOasisBackend.Data;
using OfferOasisBackend.Model;
using OfferOasisBackend.Models;

namespace OfferOasisBackend.Service.Message;

public class MessageRepository :IMessageRepository
{
    public MessageRepository(OasisContext oasisContext)
    {
        _oasisContext = oasisContext;
    }

    private readonly OasisContext _oasisContext;
    public Task<Model.Message?> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Model.Message>> GetAll()
    {
        throw new NotImplementedException();
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

    public Task<Model.Message?> Remove(int id)
    {
        throw new NotImplementedException();
    }
}