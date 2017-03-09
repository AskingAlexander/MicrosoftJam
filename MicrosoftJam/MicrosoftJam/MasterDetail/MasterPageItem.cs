using System;
using System.Collections.Generic;
using System.Text;

namespace MicrosoftJam.MasterDetail
{
    class MasterPageItem
    {
        public string Title { get; internal set; }
        public string IconSource { get; internal set; }
        public Type TargetType { get; internal set; }
    }
}
