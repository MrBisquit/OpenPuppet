using Microsoft.Extensions.DependencyInjection;
using OpenPuppet.Preferences.Layouts;
using OpenPuppet.SDK;

namespace OpenPuppet.Preferences
{
    public class Plugin : IPlugin
    {
        public const string PluginID = "com.openpuppet.preferences";

        private bool shutdown = false;

        public void OnInitialized(IServiceCollection services)
        {
            Logger.InitLogger(PluginID);
            Global.MainPlugin = this;
            Logger.LogInfo("Hello Preferences Plugin");

            IUIDialog.Register("openpuppet.layouts.new_layout", typeof(NewLayout));

            ContextMenu.AddMenuList("view.layouts");
            ContextMenu.AddMenuItem("view.layouts.new", () => IUIDialog.Open("openpuppet.layouts.new_layout"));
            ContextMenu.AddMenuList("view.layouts.layouts");
            ContextMenu.AddMenuItem("view.layouts.layouts.default", () => { });

            ISettingsSection.RegisterSection("Layouts", new Settings.Layouts());

            Windows.SubscribeToEvents();
        }

        public void OnShutdown()
        {
            if (shutdown) return;
            Logger.LogInfo("Saving current window layout");
            Windows.SavePreviousWindows();
            Windows.SaveLayout("default");
            ContextMenu.Remove("view.layouts");
            //ContextMenu.Remove("view.layouts.new");
            //ContextMenu.Remove("view.layouts.layouts");
            //ContextMenu.Remove("view.layouts.layouts.default");
            Windows.UnsubscribeToEvents();
            shutdown = true;
        }

        public void Dispose()
        {
            OnShutdown();
        }
    }

    public static class Global
    {
        public static Plugin MainPlugin;
    }
}