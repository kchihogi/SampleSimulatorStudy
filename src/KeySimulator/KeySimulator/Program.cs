
using System.Windows.Forms;

namespace KeySimulator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Simulator.SetWindowClassName("Notepad");
            //Check below for Special Keys
            //https://learn.microsoft.com/ja-jp/dotnet/api/system.windows.forms.sendkeys.send?view=windowsdesktop-7.0
            string[] arguments = new string[] { "1000", "3", "Hello", " ", "World", "{ENTER}" };
            try
            {
                int result = Simulator.Run(Func, arguments.Length, arguments);
                if (result == 0)
                {
                    Console.WriteLine("Success");
                }
                else
                {
                    Console.WriteLine("Failed");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Fatal Error: " + ex.Message);
            }
        }

        public static int Func(int argc, string[] argv)
        {
            if (argc < 3)
            {
                return -1;
            }
            int interval = int.Parse(argv[0]);
            int count = int.Parse(argv[1]);
            for (int i = 0; i < count; i++)
            {
                for (int j = 2; j < argc; j++)
                {
                    SendKeys.SendWait(argv[j]);
                    Thread.Sleep(interval);
                }
            }
            return 0;
        }
    }
}
