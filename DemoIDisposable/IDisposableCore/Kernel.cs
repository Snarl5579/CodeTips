using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDisposableCore
{
    public class Kernel : IDisposable
    {
        List<int> data;

        //  Disposable
        bool disposed = false;

        public Kernel()
        {
            this.data = new List<int>();

            for (int i = 0; i < 300; i++)
                this.data.Add(i);
        }

        ~Kernel()
        {
            this.Dispose();
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (this.disposed) return;

            this.data.Clear();
            this.data = null;

            this.disposed = true;
        }
    }
}
