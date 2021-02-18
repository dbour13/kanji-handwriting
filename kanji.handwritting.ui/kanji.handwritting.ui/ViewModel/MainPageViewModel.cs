using kanji.handwritting.common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace kanji.handwritting.ui.ViewModel
{
    public class MainPageViewModel
    {
        public MainPageViewModel(KanjiDrawingService kanjiDrawingService)
        {
            new Task(async () =>
            {
                await Task.Delay(5000);

                App.Current.Dispatcher.BeginInvokeOnMainThread(() =>
                {
                    kanjiDrawingService.DrawKanji('悪');
                });
            }).Start();
        }

        public string Test { get; set; } = "Hello asdf";
    }
}
