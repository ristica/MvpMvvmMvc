using System.IO;
using System.Reflection;
using System.Web.Caching;

namespace Demo.Asp.Common
{
    public class AssemblyCacheDependency : CacheDependency
    {
        private readonly Assembly _assembly;

        public AssemblyCacheDependency(Assembly assembly)
        {
            this._assembly = assembly;
            this.SetUtcLastModified(File.GetCreationTimeUtc(assembly.Location));
        }
    }
}