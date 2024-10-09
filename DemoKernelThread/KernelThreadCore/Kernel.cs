using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KernelThreadCore
{
    public class Kernel : IDisposable
    {
        public event LogMessageDelegate LogMessage;

        //  Thread
        readonly Thread kernelThread;
        bool isKernelEnd = false;
        bool isEmergencyStop = false;

        //  Disposable
        bool disposed = false;
        readonly SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        public Kernel()
        {
            this.kernelThread = new Thread(KernelFunction)
            {
                Name = "Kernel"
            };
            this.kernelThread.SetApartmentState(ApartmentState.STA);
            this.kernelThread.Start();
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

            if (disposing)
            {
                this.handle.Dispose();

                this.isKernelEnd = true;
                this.isEmergencyStop = true;
            }

            this.disposed = true;
        }

        void KernelFunction()
        {
            //  Endless Loop for command
            while (!this.isKernelEnd)
            {
                try
                {
                    Thread.Sleep(1000);
                    if (this.isEmergencyStop) continue;

                    this.LogMessage?.Invoke(
                        $"{DateTime.Now:yyyy/MM/dd, HH:mm:ss:ffff} - Kernel Thread Event.");
                }
                catch
                {
                    //  Command Exception                    
                }
            }
        }
    }
}
