using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entityframeworkrepository
{


    public partial class FakeWorkBenchContext : IWorkBenchContext
    {
      

    }


    /// <summary>
    /// WorkBenchContext
    /// </summary>
    public partial class WorkBenchContext : System.Data.Entity.DbContext, IWorkBenchContext
    {
        /// <summary>
        /// Init 0
        /// </summary>
        private static void WorkBenchContextStaticPartial()
        {
            // TODO: put here any needed static initialization code you need
        }
    }
}
