using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MarsRover.Model.Enums
{
    public enum NavigationFace : UInt16
    {
        [Description("North")]
        N = 0,
        [Description("East")]
        E = 90,
        [Description("South")]
        S = 180,
        [Description("West")]
        W = 270
    }
}
