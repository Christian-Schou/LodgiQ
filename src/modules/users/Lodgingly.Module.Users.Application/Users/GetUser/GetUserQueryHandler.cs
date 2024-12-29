using System.Data.Common;
using Dapper;
using Lodgingly.Framework.Application.Data;
using Lodgingly.Framework.Application.Messaging.Queries;
using Lodgingly.Framework.Domain.Results;
using Lodgingly.Module.Users.Domain.Users;

namespace Lodgingly.Module.Users.Application.Users.GetUser;

internal sealed class GetUserQueryHandler(IDatabaseConnectionFactory dbConnectionFactory) : IQueryHandler<GetUserQuery, UserResponse>
{
    public async Task<Result<UserResponse>> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        await using DbConnection connection = await dbConnectionFactory.OpenConnectionAsync();

        const string sql =
            $"""
             SELECT
                id AS {nameof(UserResponse.Id)},
                email AS {nameof(UserResponse.Email)},
                first_name AS AS {nameof(UserResponse.FirstName)},
                last_name AS AS {nameof(UserResponse.LastName)}
             FROM users.users
             WHERE id = @UserId
             """;

        UserResponse? user = await connection.QuerySingleOrDefaultAsync<UserResponse>(sql, request);

        return user ?? Result.Failure<UserResponse>(UserErrors.NotFound(request.UserId));
    }
}