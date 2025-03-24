using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Repositories.Interceptors;

public class AuditDbContextInterceptor :SaveChangesInterceptor
{
    public override ValueTask<int> SavedChangesAsync(SaveChangesCompletedEventData eventData, int result,
        CancellationToken cancellationToken = new CancellationToken())
    {
         //audit logic

         foreach (var entityEntry in eventData.Context!.ChangeTracker.Entries().ToList())
         {
             switch (entityEntry.Entity)
             {
                 case EntityState.Added:
                     break;
                 
             }
          
         }
         return new ValueTask<int>(result);
        //return base.SavedChangesAsync(eventData, result, cancellationToken);
    }
}