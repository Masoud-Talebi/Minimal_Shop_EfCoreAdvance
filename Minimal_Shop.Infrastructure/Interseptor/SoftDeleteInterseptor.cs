using Microsoft.EntityFrameworkCore.Diagnostics;
using Minimal_Shop.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minimal_Shop.Infrastructure.Interseptor
{
    public class SoftDeleteInterSeptor : SaveChangesInterceptor
    {
        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
        {
            if (eventData.Context is null) return base.SavingChanges(eventData, result);
            foreach (var entry in eventData.Context.ChangeTracker.Entries().Where(p => p.State == EntityState.Deleted && p.Entity is IDeleted))
            {
                var entity = entry.Entity as IDeleted;
                entity.IsDelete = true;
                entry.State = EntityState.Modified;
            }
            return base.SavingChanges(eventData, result);
        }
        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }
    }
}
