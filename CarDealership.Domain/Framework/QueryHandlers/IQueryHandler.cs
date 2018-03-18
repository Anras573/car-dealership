using CarDealership.Domain.Framework.Queries;

namespace CarDealership.Domain.Framework.QueryHandlers
{
    /// <summary>
    /// Marker interface that makes it easier to discover handlers via reflection.
    /// </summary>
    public interface IQueryHandler { }

    public interface IQueryHandler<in TQuery, out TResult> : IQueryHandler where TQuery : IQuery<TResult>
    {
        TResult Handle(TQuery query);
    }
}