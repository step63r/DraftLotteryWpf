﻿using DraftLotteryWpf.Content;
using DraftLotteryWpf.Content.Views;
using DraftLotteryWpf.Views;
using Prism.Ioc;
using Prism.Modularity;
using System.Windows;

namespace DraftLotteryWpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<TopPage>();
            containerRegistry.RegisterForNavigation<ConfigureUsersPage>();
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            // モジュールの登録
            moduleCatalog.AddModule<ContentModule>();
        }
    }
}
