﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FastAgile.DomainModel.Commands;
using Ncqrs;
using Ncqrs.Commanding.CommandExecution.Mapping.Attributes;
using Ncqrs.Commanding.ServiceModel;
using Ncqrs.CommandService.Infrastructure;
using Ncqrs.Config;

namespace FastAgile.DomainModel.Tests
{
    public class Configuration : IEnvironmentConfiguration
    {

        public static void Configure()
        {
            if (NcqrsEnvironment.IsConfigured) return;
            var cfg = new Configuration();
            NcqrsEnvironment.Configure(cfg);
        }

        private static ICommandService InitializeCommandService()
        {
            var commandAssembly = typeof(CreateNewProject).Assembly;

            var service = new CommandService();
            service.RegisterExecutorsInAssembly(commandAssembly);
            service.AddInterceptor(new ThrowOnExceptionInterceptor());

            return service;
        }


        private readonly ICommandService _commandService;

        private Configuration()
        {
            _commandService = InitializeCommandService();
        }

        public bool TryGet<T>(out T result) where T : class
        {
            result = null;
            if (typeof(T) == typeof(ICommandService))
                result = (T)_commandService;
            return result != null;
        }

    }
}