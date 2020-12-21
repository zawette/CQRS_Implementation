namespace CQRS.Query
{
    public interface IQueryHandler<Query, Result> where Query : class, IQuery<Result>
    {

    }
}