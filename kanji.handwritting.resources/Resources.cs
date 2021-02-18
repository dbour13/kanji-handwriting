using System;
using System.IO;
using System.IO.Compression;
using System.Xml;
using Svg;

namespace kanji.handwritting.resources
{
    public static class Resources
    {
        public static Stream GetKanjiSVG(char kanji)
        {
            var assembly = typeof(Resources).Assembly;
            Stream resource = assembly.GetManifestResourceStream("kanji.handwritting.resources.KanjiVG.kanji.zip");

            using (var zipArchive = new ZipArchive(resource))
            {
                var entry = zipArchive.GetEntry($"{((int)kanji).ToString("X5").ToLower()}.svg");

                if (entry != null)
                {
                    // Copy into memory stream as we're closing the archive
                    MemoryStream ms = new MemoryStream();
                    entry.Open().CopyTo(ms);
                    ms.Seek(0, SeekOrigin.Begin);
                    // return memory stream
                    return ms;
                }
            }

            return null;
        }
    }
}
