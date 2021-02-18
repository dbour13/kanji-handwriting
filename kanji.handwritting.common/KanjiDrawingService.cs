using svgpoints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace kanji.handwritting.common
{
    public class KanjiDrawingService
    {
        private ICanvasService _canvas;

        public KanjiDrawingService(ICanvasService canvas)
        {
            _canvas = canvas;
        }

        public void DrawKanji(char kanjiChar)
        {
            List<List<Point>> pointsList = new List<List<Point>>();

            // Get the SVG resource
            using (var stream = resources.Resources.GetKanjiSVG(kanjiChar))
            {
                // Read the SVG Paths from XML
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.DtdProcessing = DtdProcessing.Parse;

                using (XmlReader reader = XmlReader.Create(stream, settings))
                {
                    while (reader.ReadToFollowing("path"))
                    {
                        string s = reader.GetAttribute("d");
                        try
                        {
                            pointsList.Add(svgpoints.SvgPoints.GetPointsFromSVGPathsString(s).ToList());
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                }
            }

            foreach (var points in pointsList)
            {
                for (int i = 0; i < points.Count()-1; i++)
                {
                    _canvas.DrawLine(points[i].X, points[i].Y, points[i + 1].X, points[i + 1].Y);
                }
            }
        }
    }
}
