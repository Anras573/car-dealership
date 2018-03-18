using CarDealership.Domain.Framework.QueryHandlers;

namespace CarDealership.Domain.Framework.Queries
{
    public interface IQueryProcessor
    {
        TResult Process<TResult>(IQuery<TResult> query);
        void AddQueryProcessor<T>(T processor) where T : IQueryHandler;
    }
}
