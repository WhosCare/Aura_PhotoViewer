﻿using AuraPhotoViewer.Modules.Common.Events;
using log4net;
using Microsoft.Practices.Unity;
using Prism.Events;
using System.Windows;

namespace AuraPhotoViewer
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            // Start Bootstrapper            
            var bootstrapper = new AuraBootstrapper();
            bootstrapper.Run();
            // On start up publish opened image
            if (e.Args.Length >= 1)
            {
                bootstrapper.Container.Resolve<IEventAggregator>().GetEvent<OpenedImageEvent>().Publish(e.Args[0]);
            }            
        }
    }
}
