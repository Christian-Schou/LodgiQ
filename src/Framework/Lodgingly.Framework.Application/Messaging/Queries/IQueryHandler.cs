using Lodgingly.Framework.Domain.Results;

namespace Lodgingly.Framework.Application.Messaging.Queries;

public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>;