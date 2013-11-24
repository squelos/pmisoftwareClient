using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TcpDataModel
{
    public partial class Semester
    {
        public Semester(DateTime start, DateTime end):this()
        {
            this.start = start;
            this.end = end;
        }
    }
}
