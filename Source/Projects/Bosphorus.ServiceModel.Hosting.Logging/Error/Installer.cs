﻿using System;
using System.Collections.Generic;
using System.Linq;
using Bosphorus.Container.Castle.Registration;
using Bosphorus.Library.Logging.Core;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Bosphorus.ServiceModel.Hosting.Logging.Error
{
    public class Installer :AbstractWindsorInstaller
    {
        protected override void Install(IWindsorContainer container, IConfigurationStore store, FromTypesDescriptor allLoadedTypes)
        {
            container.Register(
                Component
                    .For<ILogger<ExceptionLog>>()
                    .ImplementedBy<ConsoleExceptionLogger>()
            );
        }
    }
}
