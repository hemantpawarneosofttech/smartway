using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartWay.Data.Infrastructure
{
    /// <summary>
    /// Class required for object Disposable
    /// </summary>
    public class Disposable : IDisposable
    {
        /// <summary>
        /// Variables
        /// </summary>
        private bool isDisposed;

        /// <summary>
        /// Destructor
        /// </summary>
        ~Disposable()
        {
            Dispose(false);
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Dispose
        /// </summary>
        /// <param name="disposing"></param>
        private void Dispose(bool disposing)
        {
            if (!isDisposed && disposing)
            {
                DisposeCore();
            }

            isDisposed = true;
        }

        /// <summary>
        /// Ovveride this to dispose custom objects
        /// </summary>
        protected virtual void DisposeCore()
        {

        }
    }
}
