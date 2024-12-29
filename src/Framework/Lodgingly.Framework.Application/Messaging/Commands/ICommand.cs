using Lodgingly.Framework.Domain.Results;

namespace Lodgingly.Framework.Application.Messaging.Commands;

public interface IBaseCommand;

public interface ICommand : IRequest<Result>, IBaseCommand;

public interface ICommand<TResponse> : IRequest<Result<TResponse>>, IBaseCommand;