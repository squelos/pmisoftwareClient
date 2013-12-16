using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TcpDataModel
{
    public partial class Payment
    {
        public override string ToString()
        {
            return this.amount.ToString("C0") + " " + this.raison;
            
        }
    }
}
