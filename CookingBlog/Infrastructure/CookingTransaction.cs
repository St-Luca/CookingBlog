//using Microsoft.EntityFrameworkCore.Storage;
//using System.Data;
//using System.Data.Common;

//namespace CookingBlog.Infrastructure;

//public class CookingTransaction : IDbContextTransaction
//{
//    public IDbTransaction Transaction { get; }

//    public Guid TransactionId => default;

//    public CookingTransaction(DbConnection connection)
//    {
//        Transaction = connection.BeginTransaction();
//    }

//    public void Commit()
//    {
//        Transaction.Commit();
//    }

//    public void Rollback()
//    {
//        Transaction.Rollback();
//    }

//    public void Dispose()
//    {
//        Transaction.Connection?.Dispose();
//        Transaction.Dispose();
//    }

//    public async Task CommitAsync(CancellationToken cancellationToken = default)
//    {
//        Transaction.Commit();
//    }

//    public async Task RollbackAsync(CancellationToken cancellationToken = default)
//    {
//        Transaction.Rollback();
//    }

//    public ValueTask DisposeAsync()
//    {
//        return Transaction.Connection?.Dispose();
//        Transaction.Dispose();
//    }
//}
