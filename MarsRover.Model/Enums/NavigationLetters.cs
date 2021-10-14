using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MarsRover.Model.Enums
{
    public enum NavigationLetters : Int16
    {
        [Description("Left")]
        L = -90,
        [Description("Right")]
        R = +90,
        [Description("Move")]
        M = 1
    }
}
