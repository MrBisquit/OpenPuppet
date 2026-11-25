using System;
using System.Collections.Generic;
using System.Text;

namespace OpenPuppet.SDK.Translation
{
    /// <summary>
    /// The base class that all translation classes extend from.
    /// 
    /// This sets out the base for all translation strings.
    /// </summary>
    public interface ITranslation
    {
        public string ToString();
    }
}
