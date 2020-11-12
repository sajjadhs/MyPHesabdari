using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MyPHesabdari.Model
{
    public interface IMyContext
    {
        DbSet<Cost> Costs { get; set; }
        DbSet<Expense> Expenses { get; set; }
        DbSet<CurrencyUnit> CurrencyUnits { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        int SaveChanges();
    }
}
