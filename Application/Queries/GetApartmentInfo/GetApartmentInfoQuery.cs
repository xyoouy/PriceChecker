using Application.Views;
using MediatR;

namespace Application.Queries.GetApartmentInfo;

public class GetApartmentInfoQuery : IRequest<IList<ApartmentInfo>>
{
    public string Email { get; set; }
}