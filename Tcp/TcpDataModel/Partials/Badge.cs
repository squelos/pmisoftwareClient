using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TcpDataModel
{
    public partial class Badge
    {
        public Badge(long id, bool enable, bool master )
        {
            number = id;
            isEnabled = enable;
            isMaster = master;
           
        }

        public Badge()
        {
            
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
