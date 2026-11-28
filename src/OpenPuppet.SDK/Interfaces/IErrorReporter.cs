using System;
using System.Collections.Generic;
using System.Text;

namespace OpenPuppet.SDK
{
    /// <summary>
    /// Error reporting service, this should be as an unavoidable dialog popup.
    /// </summary>
    public interface IErrorReporter : IDisposable
    {
        public void ReportError(Exception exception, ErrorReporterAction[] actions);

        public void ReportError(Exception exception, Type type, ErrorReporterAction[] actions);

        public void ReportWarning(string warning, ErrorReporterAction[] actions);
    }

    public class ErrorReporterAction
    {
        public enum ActionType
        {
            Retry,
            Continue,
            Abort
        };

        public ActionType Type;
        public string Command; // TODO: Replace with an actual command link
    }
}
