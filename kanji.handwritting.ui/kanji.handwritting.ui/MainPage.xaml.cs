using kanji.handwritting.ui.ViewModel;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace kanji.handwritting.ui
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private List<Tuple<double, double, double, double>> itemsToDraw = new List<Tuple<double, double, double, double>>();

        public void DrawLine(double x1, double y1, double x2, double y2)
        {
            itemsToDraw.Add(new Tuple<double,double,double,double>(x1, y1, x2, y2));

            cvArea.InvalidateSurface();
        }

        private void cvArea_PaintSurface(object sender, SkiaSharp.Views.Forms.SKPaintSurfaceEventArgs args)
        {
            var info = args.Info;
            var surface = args.Surface;
            var canvas = surface.Canvas;

            canvas.Clear();

            // In this example, we will draw a circle in the middle of the canvas
            var paint = new SKPaint
            {
                Style = SKPaintStyle.Fill,
                Color = Color.Black.ToSKColor(), // Alternatively: SKColors.Red
            };

            canvas.DrawLine(0, 0, 100, 100, paint);

            foreach (var item in itemsToDraw)
            {
                canvas.DrawLine((float)item.Item1, (float)item.Item2, (float)item.Item3, (float)item.Item4, paint);
            }
        }
    }
}
