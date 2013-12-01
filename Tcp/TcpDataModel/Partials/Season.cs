using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TcpDataModel
{
    public partial class Season
    {
        public Semester FirstSemester
        { get { return Semester[0]; } }

        public Semester SecondSemester
        { get { return Semester[1]; } }
        public Season(Semester first, Semester second)
            : this()
        {

            this.Semester.Add(first);
            this.Semester.Add(second);
        }
    }
}
