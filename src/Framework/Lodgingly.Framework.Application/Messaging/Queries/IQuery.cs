using Lodgingly.Framework.Domain.Results;

namespace Lodgingly.Framework.Application.Messaging.Queries;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>;