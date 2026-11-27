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
            throw new NotImplementedException();
        }

        public void ReportError(Exception exception, Type type, ErrorReporterAction[] actions)
        {
            throw new NotImplementedException();
        }

        public void ReportWarning(string warning, ErrorReporterAction[] actions)
        {
            throw new NotImplementedException();
        }
    }
}
