using System.DirectoryServices;
using System.Text;

namespace KeySimulator
{
    public class Simulator
    {
        private static IntPtr _windowHandle = IntPtr.Zero;

        public static bool SetWindowTitle(string windowTitle)
        {
            _windowHandle = Dll.FindWindow(null, windowTitle);
            if (_windowHandle == IntPtr.Zero)
            {
                return false;
            }
            return true;
        }

        public static bool SetWindowClassName(string windowClassName)
        {
            _windowHandle = Dll.FindWindow(windowClassName, null);
            if (_windowHandle == IntPtr.Zero)
            {
                return false;
            }
            return true;
        }

        public static bool SetWindowHandle(IntPtr windowHandle)
        {
            _windowHandle = windowHandle;
            return true;
        }

        public delegate int Simulate(int argc, string[] argv);

        public static int Run(Simulate simulate, int argc, string[] argv)
        {
            if (_windowHandle == IntPtr.Zero)
            {
                throw new InvalidOperationException("Window handle is not set. Please set window handle before running.");
            }

            bool isForeground = Dll.SetForegroundWindow(_windowHandle);
            if (!isForeground)
            {
                throw new Exception("Failed to set foreground window.");
            }
            return simulate(argc, argv);
        }
    }
}