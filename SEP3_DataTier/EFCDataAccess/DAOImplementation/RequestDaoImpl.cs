using EFCDataAccess.DAOInterface;
using Entity.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EFCDataAccess.DAOImplementation;

public class RequestDaoImpl : IRequestDao
{
    private readonly CanPayDbAccess context;

    public RequestDaoImpl(CanPayDbAccess context)
    {
        this.context = context;
    }

    /// <summary>
    /// Creates a request asynchronously.
    /// </summary>
    /// <param name="requestEntity">The request entity to create.</param>
    /// <returns>The created request entity.</returns>
    public async Task<RequestEntity> CreateRequestAsync(RequestEntity requestEntity)

    {
        try
        {
            //Attach the payer(user) entity to the context if not attached already
            if (!context.Users.Local.Contains(requestEntity.RequestReceiver))
            {
                context.Users.Attach(requestEntity.RequestReceiver);
                context.Cards.Attach(requestEntity.RequestReceiver!.Card);
            }

            if (!context.Users.Local.Contains(requestEntity.RequestSender))
            {
                context.Users.Attach(requestEntity.RequestSender);
                context.Cards.Attach(requestEntity.RequestSender!.Card);
            }

            EntityEntry<RequestEntity?> addedRequest = await context.Requests.AddAsync(requestEntity);
            await context.SaveChangesAsync();
            return addedRequest.Entity;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new Exception("Cannot create a request.");
        }
    }

    /// <summary>
    /// Fetches a request by its ID asynchronously.
    /// </summary>
    /// <param name="id">The ID of the request to fetch.</param>
    /// <returns>The fetched request entity.</returns>
    public async Task<RequestEntity> FetchRequestByIdAsync(long id)

    {
        try
        {
            RequestEntity? requestEntity = await context.Requests.Include(entity => entity.RequestSender)
                .Include(entity => entity.RequestSender.Card)
                .Include(entity => entity.RequestReceiver.Card)
                .Include(entity => entity.RequestReceiver).FirstOrDefaultAsync(entity => entity.Id == id);
            return requestEntity;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new Exception($"No request with id {id} found.");
        }
    }

   
    /// <summary>
    /// Updates a request asynchronously.
    /// </summary>
    /// <param name="requestEntity">The request entity to update.</param>
    /// <returns>The updated request entity.</returns>
    public async Task<RequestEntity> UpdateRequest(RequestEntity requestEntity)

    {
        long currentId = await context.Requests.Where(e => e.Id == requestEntity.Id).Select(e => e.Id)
            .FirstOrDefaultAsync();
        if (currentId != 0)
        {
            requestEntity.Id = currentId;
        }

        //Attach the payer(user) entity to the context if not attached already
        if (!context.Requests.Local.Contains(requestEntity))
        {
            context.Requests.Attach(requestEntity);
            context.Users.Attach(requestEntity.RequestSender);
            context.Cards.Attach(requestEntity.RequestSender!.Card);
            context.Users.Attach(requestEntity.RequestReceiver);
            context.Cards.Attach(requestEntity.RequestReceiver!.Card);
        }

        context.Entry(requestEntity).State = EntityState.Modified;
        await context.SaveChangesAsync();
        return requestEntity;
    }
}