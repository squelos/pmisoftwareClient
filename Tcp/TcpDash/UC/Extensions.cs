using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MahApps.Metro.Controls;

namespace TcpDash.UC
{
    public static class Extensions
    {
        public static void NextTab(this MetroAnimatedTabControl tc)
        {
            if (tc.Items.Count >= 2)
            {
                if (tc.SelectedIndex < tc.Items.Count - 1)
                {
                    tc.SelectedIndex++;
                }
                else
                {
                    tc.SelectedIndex = 0;
                }
            }
        }

        public static void PreviousTab(this MetroAnimatedTabControl tc)
        {
            if (tc.Items.Count >= 2)
            {
                if (tc.SelectedIndex > 0)
                {
                    tc.SelectedIndex--;
                }
                else
                {
                    tc.SelectedIndex = tc.Items.Count - 1;
                }
            }
        }
    }
}