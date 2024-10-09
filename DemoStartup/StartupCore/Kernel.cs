using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StartupCore
{
    public class Kernel : IDisposable
    {
        public UserInterfaceDelegate InitializeMessage;

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

        public void Initialize()
        {
            this.kernelThread.Start();
        }

        void KernelFunction()
        {
            try
            {
                Thread.Sleep(500);

                this.InitializeMessage?.Invoke(
                   UserInterfaceMessageType.InitializeStart, new string[] { "" });

                //  Initialize
                this.KernelInitialize();
            }
            catch
            {
                //  Initialize Exception
            }
            finally
            {
                this.InitializeMessage?.Invoke(
                    UserInterfaceMessageType.InitializeFinshed, new string[] { "" });
            }

            //  Endless Loop for command
            while (!this.isKernelEnd)
            {
                try
                {
                    Thread.Sleep(10);
                    if (this.isEmergencyStop) continue;
                }
                catch
                {
                    //  Command Exception
                }
            }
        }

        void KernelInitialize()
        {
            this.InitializeMessage?.Invoke(
                UserInterfaceMessageType.InitializeMessage,
                new string[] { "Unit 1" });
            Thread.Sleep(1000);

            this.InitializeMessage?.Invoke(
                UserInterfaceMessageType.InitializeMessage,
                new string[] { "Unit 2" });
            Thread.Sleep(1000);

            this.InitializeMessage?.Invoke(
                UserInterfaceMessageType.InitializeMessage,
                new string[] { "Unit 3" });
            Thread.Sleep(1000);
        }
    }
}
