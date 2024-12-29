using Microsoft.AspNetCore.Routing;

namespace Lodgingly.Framework.Presentation.Endpoints.Contracts;

public interface IEndpoint
{
    void MapEndpoint(IEndpointRouteBuilder app);
}