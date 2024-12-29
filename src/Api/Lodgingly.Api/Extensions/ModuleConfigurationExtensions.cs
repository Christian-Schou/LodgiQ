namespace Lodgingly.Api.Extensions;

internal static class ModuleConfigurationExtensions
{
    internal static void InitializeModuleConfigurations(this IConfigurationBuilder configurationBuilder,
        string[] modules)
    {
        foreach (string moduleName in modules)
        {
            configurationBuilder.AddJsonFile($"module.{moduleName}.json", optional: false, reloadOnChange: true);
            configurationBuilder.AddJsonFile($"module.{moduleName}.Development.json", optional: false, reloadOnChange: true);
        }
    }
}