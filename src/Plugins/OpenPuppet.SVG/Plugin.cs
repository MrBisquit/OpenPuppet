using ImGuiNET;
using Microsoft.Extensions.DependencyInjection;
using OpenPuppet;
using OpenPuppet.SDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenPuppet.SVG
{
    public class Plugin : IPlugin
    {
        public const string PluginID = "com.openpuppet.svg";

        private bool shutdown = false;

        public void OnInitialized(IServiceCollection services)
        {
            Logger.InitLogger(PluginID);
            bool hasProject = SDK.Projects.ProjectManager.ActiveProject != null;

            Logger.LogInfo("Hello SVG Plugin");

            IUIDialog.Register("openpuppet.svg.import", typeof(ImportSVG));

            ContextMenu.AddMenuItem("File.Import.SVG", () => IUIDialog.Open("openpuppet.svg.import"), "Import SVG", hasProject);
        }

        public void OnShutdown()
        {
            if (shutdown) return;
            ContextMenu.Remove("File.Import.SVG");
            shutdown = true;
        }

        public void Dispose()
        {
            OnShutdown();
        }
    }
}