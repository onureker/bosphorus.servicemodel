﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using Bosphorus.ServiceModel.Hosting.Hosting.Core.Description.Service.DispatchMessageInspector;

namespace Bosphorus.ServiceModel.Hosting.Hosting.Core.Description.Service
{
    public class GenericDispatchMessageInspectorBehavior<TProvider> : IServiceBehavior
        where TProvider : IDispatchMessageInspectorProvider
    {
        private readonly TProvider provider;

        public GenericDispatchMessageInspectorBehavior(TProvider provider)
        {
            this.provider = provider;
        }

        public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
        }

        public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints, BindingParameterCollection bindingParameters)
        {
        }

        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            foreach (ChannelDispatcher channelDispatcher in serviceHostBase.ChannelDispatchers.OfType<ChannelDispatcher>())
            {
                foreach (EndpointDispatcher endpointDispatcher in channelDispatcher.Endpoints)
                {
                    IDispatchMessageInspector dispatchMessageInspector = this.provider.Get(serviceDescription, serviceHostBase);
                    endpointDispatcher.DispatchRuntime.MessageInspectors.Add(dispatchMessageInspector);
                }
            }
        }
    }
}
