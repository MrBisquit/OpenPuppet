using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenPuppet.SDK
{
    public static class SDK
    {
        public static string LocalDataPath = Path.Join(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "OpenPuppet");
        public static string DataPath = Path.Join(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "OpenPuppet");

        public static SafeTypeBinder JsonTypeBinder { get; } = new();

        internal static ObservableServiceCollection Services { get; } = [];
        internal static ServiceProvider Provider { get; private set; } = Services.BuildServiceProvider();

        public static void Init()
        {
            Services.OnAdded += Services_OnAdded;
            Services.OnCleared += Services_OnCleared;
            Services.OnRemoved += Services_OnRemoved;
            Services.OnReplaced += Services_OnReplaced;
        }

        private static void Services_OnReplaced(ServiceDescriptor arg1, ServiceDescriptor arg2)
        {
            Logger.LogDebug($"Service {arg1} replaced with {arg2}");

            RebuildServiceProvider();
        }

        private static void Services_OnRemoved(ServiceDescriptor obj)
        {
            Logger.LogDebug($"Service {obj} removed");

            RebuildServiceProvider();
        }

        private static void Services_OnCleared()
        {
            Logger.LogDebug($"Services cleared");

            RebuildServiceProvider();
        }

        private static void Services_OnAdded(ServiceDescriptor obj)
        {
            Logger.LogDebug($"Service {obj} added");

            RebuildServiceProvider();
        }

        public static void RebuildServiceProvider()
        {
            Logger.LogInfo("Rebuilding service provider");
            Provider = Services.BuildServiceProvider();
            Logger.LogDebug("Rebuilt service provider successfully");
        }
    }
}
