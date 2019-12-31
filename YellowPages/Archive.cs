using Microsoft.Win32.SafeHandles;
using System.Runtime.InteropServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YellowPages
{
    public abstract class Archive: IDisposable
    {
        private bool disposed = false;
        public Dictionary<string, string> Store;
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true); 
        public IEnumerable<KeyValuePair<string, string>> getStore() {
            return Store;
        }
        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed) return;

            if (disposing) { handle.Dispose();  finalize(); }
        }

        private void finalize() {
            this.Store = null;
        }
    }
}
