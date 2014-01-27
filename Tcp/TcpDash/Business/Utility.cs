﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TcpDash.Business
{
    public static class Utility
    {
        public static DateTime GetFirst(DateTime dt)
        {
            switch (dt.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    {
                        return dt.Date;
                    }
                case DayOfWeek.Tuesday:
                    {
                        return dt.AddDays(-1).Date;
                    }
                case DayOfWeek.Wednesday:
                    {
                        return dt.AddDays(-2).Date;
                    }
                case DayOfWeek.Thursday:
                    {
                        return dt.AddDays(-3).Date;
                    }
                case DayOfWeek.Friday:
                    {
                        return dt.AddDays(-4).Date;
                    }
                case DayOfWeek.Saturday:
                    {
                        return dt.AddDays(-5).Date;
                    }
                case DayOfWeek.Sunday:
                    {
                        return dt.AddDays(-6).Date;
                    }
                default:
                    return dt;
            }
        }
    }
}
