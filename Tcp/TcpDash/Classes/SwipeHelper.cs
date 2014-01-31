using System.Threading;
using System.Threading.Tasks;

namespace TcpDash.Classes
{
    public class SwipeHelper
    {
        private bool _swiped = false;
        private Task t;
        private bool _running = false;
        public SwipeHelper()
        {
            
        }

        public bool Swipped
        {
            get { return _swiped; }
            set
            {
                _swiped = value;
                if (value && !_running)
                {
                    
                    Task t = new Task(() =>
                    {
                        _running = true;
                        Thread.Sleep(750);
                        Swipped = false;
                        _running = false;
                    });
                    t.Start();
                }
            }
        }
    }
}
