using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace OpenPuppet.SDK
{
    /*public static class Logger
    {
        internal static string? LocalPath
        {
            get
            {
                return Path.Join(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "OpenPuppet");
            }
        }

        public static string? LogPath
        {
            get
            {
                return LocalPath != null ? Path.Join(LocalPath, "Logs") : null;
            }
        }

        public static class LogManager
        {
            public static string RequestPluginLogFile(string pluginName)
            {
                if (!Directory.Exists(Path.Join(LogPath!, IPlugin.SafePluginName(pluginName))))
                {
                    Directory.CreateDirectory(Path.Join(LogPath!, IPlugin.SafePluginName(pluginName)));
                }

                string path = Path.Join(
                    LogPath!,
                    IPlugin.SafePluginName(pluginName),
                    DateTime.Now.ToString("dd'-'MM'-'yyyy'.txt'")
                );

                if (!File.Exists(path)) File.WriteAllText(path, null);
                return path;
            }

            public static PluginLogger RequestPluginLogger(string pluginName)
            {
                return new PluginLogger(pluginName, RequestPluginLogFile(pluginName));
            }
        }

        public interface ILogger : IDisposable
        {
            //public string LogFile               { get; internal set; }
            //internal FileStream fileStream      { get; set; }
            //internal StreamWriter fileWriter    { get; set; }

            public enum Level
            {
                Log,
                OK,
                Error,
                Warn
            }

            abstract void Write(string message);
            abstract void WriteLine(string message, bool write = true);

            abstract void WriteLine(Level level, string message, bool forceWrite = false);
        }

        public class PluginLogger : ILogger
        {
            public string PluginName { get; internal set; } = string.Empty;
            public string LogFile { get; internal set; } = string.Empty;
            //internal FileStream FileStream { get; set; }
            internal StreamWriter FileWriter { get; set; }

            public PluginLogger(string name, string path)
            {
                PluginName = name;
                LogFile = path;
                //FileStream = new FileStream(path, FileMode.Append, FileAccess.Write);
                FileWriter = new StreamWriter(path, true);

                Assembly pluginAssembly = Assembly.GetEntryAssembly() ?? Assembly.GetCallingAssembly();
                FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(pluginAssembly.Location);

                FileWriter.WriteLine("==================== OpenPuppet.SDK Log ====================");
                FileWriter.WriteLine($"\tPlugin name:\t\t{name}");
                FileWriter.WriteLine($"\tPlugin version:\t\t{fvi.FileVersion}");
                FileWriter.WriteLine($"\tAssembly name:\t\t{pluginAssembly.GetName().Name}");
                FileWriter.WriteLine($"\tProduct version:\t{fvi.ProductVersion}");

                FileWriter.Flush();
            }

            // TODO: Set up some kind of better flushing system so the file stream doesn't get clogged

            public void Write(string message)
            {
                FileWriter.Write(message);
                Console.Write(message);
                Debug.Write(message);

                FileWriter.Flush();
            }

            public void WriteLine(string message, bool write = true)
            {
                string msg = $"[{PluginName}] ({DateTime.Now:dd'-'MM'-'yyyy HH':'mm':'ss}) {message}";
                if (write) FileWriter.WriteLine(msg);
                Console.WriteLine(msg);
                Debug.WriteLine(msg);

                FileWriter.Flush();
            }

            public void WriteLine(ILogger.Level level, string message, bool forceWrite = false)
            {
                // Cut down on the excessive logging to disk
                WriteLine($"{level}: {message}", level != ILogger.Level.Log || forceWrite);
            }

            public void Close(bool dispose = false)
            {
                FileWriter.WriteLine("==================== OpenPuppet.SDK End ====================");
                FileWriter.WriteLine();
                FileWriter.Flush();

                if (dispose) Dispose();
            }

            public void Dispose()
            {
                GC.SuppressFinalize(this);

                WriteLine("Logger disposed");

                Close();

                FileWriter.Flush();

                FileWriter.Close();
                //FileStream.Close();

                FileWriter.Dispose();
                //FileStream.Dispose();
            }
        }
    }*/

    public static class Logger
    {
        private static readonly AsyncLocal<string?> Source = new();
        private static readonly string Version = Assembly.GetExecutingAssembly().GetCustomAttribute<AssemblyFileVersionAttribute>()?.Version ?? "Unknown";

        public static string CurrentVerLogDirPath { get; private set; }
        public static string CurrentLogFile { get; private set; }
        public static string AppLogDirPath { get; private set; }

        public static void InitLogger(string appLogPath, bool console = false)
        {
            string versionedPath = Path.Join(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "OpenPuppet", appLogPath, Version);
            string basePath = Path.GetDirectoryName(versionedPath);

            if (!Directory.Exists(versionedPath))
            {
                Directory.CreateDirectory(versionedPath);
            }

            AppLogDirPath = basePath;
            CurrentVerLogDirPath = versionedPath;

            var logFile = $"Log_{DateTime.Now.ToString(@"yyyy-MM-dd", CultureInfo.InvariantCulture)}.log";
            var logFilePath = Path.Join(versionedPath, logFile);
            CurrentLogFile = logFilePath;

            Source.Value = appLogPath;

            Trace.Listeners.Add(new TextWriterTraceListener(logFilePath));
            if (console)
            {
                Trace.Listeners.Add(new ConsoleTraceListener());
            }
            Trace.AutoFlush = true;
        }

        private static string GetCallerInfo(string memberName, string sourceFilePath, int sourceLineNumber)
        {
            string callerFileName = "Unknown";
            try
            {
                string fileName = Path.GetFileName(sourceFilePath);
                if (!string.IsNullOrEmpty(fileName))
                {
                    callerFileName = fileName;
                }
            }
            catch (Exception)
            {
                callerFileName = "Unknown";
                throw;
            }

            return $"{callerFileName}::{memberName}::{sourceLineNumber}";
        }

        private static void Log(string msg, string type, string memberName, string sourceFilePath, int sourceLineNumber)
        {
            var source = Source.Value ?? "Unknown";
            Trace.WriteLine($"{source} [{DateTime.Now.TimeOfDay} {DateTime.Now.ToString(@"yyyy-MM-dd", CultureInfo.InvariantCulture)}] [{type}] {GetCallerInfo(memberName, sourceFilePath, sourceLineNumber)}");
            if (msg != string.Empty)
            {
                Trace.Indent();
                Trace.WriteLine(msg);
                Trace.Unindent();
            }
        }

        public static void LogWarning(string msg, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            Log(msg, "Warning", memberName, sourceFilePath, sourceLineNumber);
        }

        public static void LogInfo(string msg, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            Log(msg, "Info", memberName, sourceFilePath, sourceLineNumber);
        }

        public static void LogTrace(string msg, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            Log(msg, "Trace", memberName, sourceFilePath, sourceLineNumber);
        }

        public static void LogDebug(string msg, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
#if DEBUG
            Log(msg, "Debug", memberName, sourceFilePath, sourceLineNumber);
#endif
        }
    }
}