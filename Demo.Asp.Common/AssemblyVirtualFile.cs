using System.IO;
using System.Reflection;
using System.Web.Hosting;

namespace Demo.Asp.Common
{
    public class AssemblyVirtualFile : VirtualFile
    {
        private readonly Assembly _assembly;
        private readonly string _resourceName;

        public AssemblyVirtualFile(string virtualPath, Assembly assembly, string resourceName) : base(virtualPath)
        {
            this._assembly = assembly;
            this._resourceName = resourceName;
        }

        public override Stream Open()
        {
            return this._assembly.GetManifestResourceStream(this._resourceName);
        }
    }
}