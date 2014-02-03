using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TcpDataModel
{
    public partial class Court
    {
        public Court(string num, bool covered) : this()
        {
            this.number = num;
            this.isCovered = covered;
        }
    }
}
