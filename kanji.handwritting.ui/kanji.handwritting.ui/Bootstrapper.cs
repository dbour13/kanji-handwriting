using kanji.handwritting.common;
using kanji.handwritting.ui.services;
using kanji.handwritting.ui.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace kanji.handwritting.ui
{
    public class Bootstrapper
    {
        private readonly Application _app;
        private static IServiceCollection _services;
        private static IServiceProvider _serviceProvider;

        public Bootstrapper(Application app)
        {
            _app = app;
        }

        public void Start()
        {
            ConfigureServices();
        }

        private void ConfigureServices()
        {
            _services = new ServiceCollection();

            // TODO: add services here
            _services.AddSingleton<ICanvasService, CanvasService>();
            _services.AddSingleton<KanjiDrawingService, KanjiDrawingService>();

            _serviceProvider = _services.BuildServiceProvider();
        }

        private static MainPageViewModel _mainPageViewModel;
        public static MainPageViewModel MainPageViewModel
        {
            get
            {
                return _mainPageViewModel ?? (_mainPageViewModel = ActivatorUtilities.CreateInstance<MainPageViewModel>(_serviceProvider));
            }
        }
    }
}
