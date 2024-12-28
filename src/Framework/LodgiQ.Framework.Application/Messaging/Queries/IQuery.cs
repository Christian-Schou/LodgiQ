namespace LodgiQ.Framework.Application.Messaging.Queries;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>;