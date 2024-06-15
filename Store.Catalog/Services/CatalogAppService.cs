using Store.Catalog.Localization;
using Volo.Abp.Application.Services;

namespace Store.Catalog.Services;

/* Inherit your application services from this class. */
public abstract class CatalogAppService : ApplicationService
{
    protected CatalogAppService()
    {
        LocalizationResource = typeof(CatalogResource);
    }
}