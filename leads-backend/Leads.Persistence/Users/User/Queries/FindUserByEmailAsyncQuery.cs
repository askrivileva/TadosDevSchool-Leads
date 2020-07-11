﻿namespace Leads.Persistence.Users.User.Queries
{
    using System.Threading;
    using System.Threading.Tasks;
    using Domain.Users.Objects.Entities;
    using Domain.Users.Queries.Criteria;
    using Infrastructure.Linq.AsyncQueryable.Factories.Abstractions;
    using Infrastructure.Linq.Providers.Abstractions;
    using Infrastructure.Queries.Linq.Base;


    public class FindUserByEmailAsyncQuery : LinqAsyncQueryBase<User, FindByEmail, User>
    {
        public FindUserByEmailAsyncQuery(
            ILinqProvider linqProvider,
            IAsyncQueryableFactory asyncQueryableFactory) : base(linqProvider, asyncQueryableFactory)
        {
        }


        public override Task<User> AskAsync(FindByEmail criterion, CancellationToken cancellationToken = default)
        {
            return AsyncQuery.SingleOrDefaultAsync(
                x => x.Email == criterion.Email,
                cancellationToken);
        }
    }
}