using System.Collections;
using Application.Views;
using DataBase;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;

namespace Application.Queries.GetApartmentInfo;

public class GetApartmentInfoQueryHandler : IRequestHandler<GetApartmentInfoQuery, IList<ApartmentInfo>>
{
    private readonly IDbContext context;

    public GetApartmentInfoQueryHandler(IDbContext context) => this.context = context;
    
    public async Task<IList<ApartmentInfo>> Handle(GetApartmentInfoQuery request, CancellationToken cancellationToken)
    {
        var urls = await context.Subscriptions
            .Where(s => s.Email == request.Email)
            .ToListAsync(cancellationToken);

        
        return await Task.WhenAll(urls.Select(async subscription => new ApartmentInfo
        {
            Price = await GetPrice(subscription.Url),
            Url = subscription.Url
        }));
    }

    private async Task<int> GetPrice(string url)
    {
        url += "?ajax=1&similar=1";
        using var client = new HttpClient();
        
        var response = await client.GetAsync(url);

        response.EnsureSuccessStatusCode();

        var responseBody = await response.Content.ReadAsStringAsync();

        var json = JObject.Parse(responseBody);
        var price = int.Parse(json["price"].ToString());
        return price;
    }
}