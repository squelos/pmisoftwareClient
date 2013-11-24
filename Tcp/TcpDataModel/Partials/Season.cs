using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TcpDataModel
{
    public partial class Season
    {
        public Season(Semester first, Semester second):this()
    {

        this.Semester.Add(first);
        this.Semester.Add(second);
    }
    }
}
