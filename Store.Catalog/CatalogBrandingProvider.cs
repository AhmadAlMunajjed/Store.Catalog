using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Store.Catalog;

[Dependency(ReplaceServices = true)]
public class CatalogBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "Catalog";
}
