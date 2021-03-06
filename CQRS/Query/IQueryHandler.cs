﻿using System.Threading.Tasks;

namespace CQRS.Query
{
    public interface IQueryHandler<Query, Result> where Query : class, IQuery<Result>
    {
        public Task<Result> handleAsync(Query query);
    }
}