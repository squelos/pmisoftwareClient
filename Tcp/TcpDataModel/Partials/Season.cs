﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TcpDataModel
{
    public partial class Season
    {

        public Season(Semester first, Semester second)
        {
            this.Semester1 = first;
            this.Semester2 = second;
        }

      

       
    }
}
