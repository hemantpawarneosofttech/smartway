using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartWay.Data.Infrastructure
{
    /// <summary>
    /// Class required to initialise database in Model first development
    /// </summary>
    public interface IDbFactory : IDisposable
    {
        /// <summary>
        /// Init
        /// </summary>
        /// <returns></returns>
        SmartWayEntities Init();
    }
}
