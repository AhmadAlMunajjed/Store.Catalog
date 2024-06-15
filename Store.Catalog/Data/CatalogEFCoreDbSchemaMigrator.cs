using Microsoft.EntityFrameworkCore;
using Volo.Abp.DependencyInjection;

namespace Store.Catalog.Data;

public class CatalogEFCoreDbSchemaMigrator : ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public CatalogEFCoreDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolve the CatalogDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<CatalogDbContext>()
            .Database
            .MigrateAsync();
    }
}
