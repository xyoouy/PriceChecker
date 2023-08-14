using DataBase;
using Domain;
using MediatR;

namespace Application.Commands.Subscribe;

public class SubscribeCommandHandler : IRequestHandler<SubscribeCommand, int>
{
    private readonly IDbContext context;
    
    public SubscribeCommandHandler(IDbContext context) => this.context = context;
    
    public async Task<int> Handle(SubscribeCommand request, CancellationToken cancellationToken)
    {
        var subscription = new Subscription
        {
            Url = request.Url,
            Email = request.Email
        };

        context.Subscriptions.Add(subscription);
        await context.SaveChangesAsync(cancellationToken);

        return subscription.Id;
    }
}