using kanji.handwritting.common;
using System;
using System.Collections.Generic;
using System.Text;

namespace kanji.handwritting.ui.services
{
    public class CanvasService : ICanvasService
    {
        public void DrawLine(double x1, double y1, double x2, double y2)
        {
            ((MainPage)App.Current.MainPage).DrawLine(x1, y1, x2, y2);
        }
    }
}
