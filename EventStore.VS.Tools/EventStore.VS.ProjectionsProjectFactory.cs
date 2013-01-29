﻿using System.Runtime.InteropServices;
using Microsoft.VisualStudio.Project;
using IOleServiceProvider = Microsoft.VisualStudio.OLE.Interop.IServiceProvider;
using System;
using System.ComponentModel.Design;

namespace EventStore.EventStore_VS_Tools
{
    [Guid(GuidList.guidEventStore_VS_ProjectionsProjectString)]
    public sealed class ProjectionsProjectFactory : ProjectFactory
    {
        private readonly EventStore_VS_ToolsPackage _package;

        public ProjectionsProjectFactory(EventStore_VS_ToolsPackage package)
            : base(package)
        {
            _package = package;
        }

        protected override ProjectNode CreateProject()
        {
            var project = new ProjectionsProjectNode(_package);

            var serviceProvider = (IServiceProvider) _package;

            project.SetSite((IOleServiceProvider)serviceProvider.GetService(typeof (IOleServiceProvider)));
            return project;
        }
    }
}
