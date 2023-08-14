using MediatR;

namespace Application.Commands.Subscribe;

public class SubscribeCommand : IRequest<int>
{
    public string Email { get; set; }
    public string Url { get; set; }
}