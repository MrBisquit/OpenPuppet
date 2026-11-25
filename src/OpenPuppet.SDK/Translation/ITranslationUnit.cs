using System;
using System.Collections.Generic;
using System.Text;

namespace OpenPuppet.SDK.Translation
{
    /// <summary>
    /// This interface is the base for translation units.
    /// 
    /// A translation unit is typically a per-plugin thing, where a plugin
    /// can register its own translations for the languages that it supports,
    /// and the translator can relay this data to the settings.
    /// </summary>
    public interface ITranslationUnit
    {
    }
}
