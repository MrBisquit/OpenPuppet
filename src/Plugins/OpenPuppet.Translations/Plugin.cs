using Microsoft.Extensions.DependencyInjection;
using OpenPuppet.SDK;

namespace OpenPuppet.Translations
{
    public class Plugin : IPlugin
    {
        public const string PluginID = "com.openpuppet.translations";

        public void OnInitialized(IServiceCollection services)
        {
            Logger.InitLogger(PluginID);

            Logger.LogInfo("Hello Translations");

            ISettingsSection.RegisterSection("Language", null);
        }

        public void OnShutdown()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
