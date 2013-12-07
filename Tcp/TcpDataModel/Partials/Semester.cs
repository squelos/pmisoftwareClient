using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TcpDataModel
{
    public partial class Semester
    {
        public Semester(DateTime startDateTime, DateTime endDateTime)
        {
            this.start = startDateTime;
            this.end = endDateTime;
        }
    }
}
