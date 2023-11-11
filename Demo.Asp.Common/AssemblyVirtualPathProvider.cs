using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Caching;
using System.Web.Hosting;
using System.Web.Mvc;

namespace Demo.Asp.Common
{
    public class AssemblyVirtualPathProvider : VirtualPathProvider
    {
        private readonly Assembly _assembly;
        private readonly IEnumerable<VirtualPathProvider> _providers;

        public AssemblyVirtualPathProvider(Assembly assembly)
        {
            var engines = ViewEngines.Engines.OfType<VirtualPathProviderViewEngine>().ToList();

            this._providers = engines.Select(x => x.GetType().GetProperty("VirtualPathProvider", BindingFlags.NonPublic | BindingFlags.Instance)?.GetValue(x, null) as VirtualPathProvider).Distinct().ToList();
            this._assembly = assembly;
        }

        public override CacheDependency GetCacheDependency(string virtualPath, IEnumerable virtualPathDependencies, DateTime utcStart)
        {
            return this.FindFileByPath(this.CorrectFilePath(virtualPath)) != null 
                ? new AssemblyCacheDependency(_assembly) 
                : base.GetCacheDependency(virtualPath, virtualPathDependencies, utcStart);
        }

        public override bool FileExists(string virtualPath)
        {
            if (this._providers.Any(provider => provider.FileExists(virtualPath)))
            {
                return (true);
            }

            return this.FindFileByPath(this.CorrectFilePath(virtualPath)) != null;
        }

        public override VirtualFile GetFile(string virtualPath)
        {
            foreach (var provider in this._providers)
            {
                var file = provider.GetFile(virtualPath);

                if (file == null) continue;
                try
                {
                    file.Open();
                    return (file);
                }
                catch
                {
                }
            }

            var resourceName = this.FindFileByPath(this.CorrectFilePath(virtualPath));

            return (new AssemblyVirtualFile(virtualPath, this._assembly, resourceName));
        }

        protected string FindFileByPath(string virtualPath)
        {
            var resourceNames = this._assembly.GetManifestResourceNames();

            return (resourceNames.SingleOrDefault(r => r.EndsWith(virtualPath, StringComparison.OrdinalIgnoreCase) == true));
        }

        protected string CorrectFilePath(string virtualPath)
        {
            return (virtualPath.Replace("~", string.Empty).Replace('/', '.'));
        }
    }
}
