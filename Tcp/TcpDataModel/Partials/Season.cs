using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TcpDataModel
{
    public partial class Season
    {
        public Season(Semester first, Semester second):this()
        {
            Semester.Add(first);
            Semester.Add(second);
            first.Season = this;
            second.Season = this;
        }

        public Semester FirstSemester
        {
            get
            {
                return Semester[0];
            }
            set
            {
                Semester[0] = value;
            }
        }

        public Semester SecondSemester
        {
            get
            {
                return Semester[1];
                
            }
            set
            {
                Semester[1] = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Semester[0].start.ToShortDateString() + " ");
            sb.Append(Semester[1].end.ToShortDateString());

            return sb.ToString();
        }
    }
}
