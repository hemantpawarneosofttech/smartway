using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartWay.Data.Infrastructure
{
    /// <summary>
    /// This class is required for Entity Framework Model first development
    /// </summary>
    public class DbFactory : Disposable, IDbFactory
    {
        /// <summary>
        /// SmartWayEntities
        /// </summary>
        SmartWayEntities dbContext;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <returns></returns>
        public SmartWayEntities Init()
        {
            return dbContext ?? (dbContext = new SmartWayEntities());
        }

        /// <summary>
        /// DisposeCore
        /// </summary>
        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
