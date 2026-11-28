using OpenPuppet.SDK;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenPuppet.Core
{
    public class ErrorReporter : IErrorReporter
    {
        public void ReportError(Exception exception, ErrorReporterAction[] actions)
        {
            IUIDialog.Open("openpuppet.core.error");
            var dialog = IUIDialog.ActiveDialog;
            var error = dialog as Dialogs.ErrorDialog;
            error?.RelayError(exception);
        }

        public void ReportError(Exception exception, Type type, ErrorReporterAction[] actions)
        {
            IUIDialog.Open("openpuppet.core.error");
            var dialog = IUIDialog.ActiveDialog;
            var error = dialog as Dialogs.ErrorDialog;
            error?.RelayError(exception);
        }

        public void ReportWarning(string warning, ErrorReporterAction[] actions)
        {
            IUIDialog.Open("openpuppet.core.error");
            var dialog = IUIDialog.ActiveDialog;
            var error = dialog as Dialogs.ErrorDialog;
            error?.RelayWarning(warning);
        }

        public void Dispose()
        {

        }
    }
}
