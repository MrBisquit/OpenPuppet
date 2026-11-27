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

        internal static ServiceCollection Services { get; } = new ServiceCollection();
    }
}
