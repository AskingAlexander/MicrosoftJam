using System;
using System.Collections.Generic;
using System.Text;

namespace MicrosoftJam.UtilityClasses
{
    public interface ISaveAndLoad
    {
        void SaveText(string filename, string text);
        string LoadText(string filename);
    }
}
