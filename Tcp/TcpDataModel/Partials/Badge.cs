using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TcpDataModel
{
    public partial class Badge
    {
        public Badge(int id, bool enable, bool master ) : this()
        {
            number = id;
            isEnabled = enable;
            isMaster = master;
            hash = id;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
