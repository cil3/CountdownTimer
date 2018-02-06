using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace CountdownTimer
{
    class Program
    {
        private static int remainingTime;
        public static Timer oneSecondElapsed;

        static void Main(string[] args)
        {

            // Request start time from user.
            remainingTime = GetStartTime();

            // Initialize counter; wait on keyboard input to start.
            UpdateScreen();
            Console.Write("Press Enter key to begin countdown.");
            Console.ReadLine();

            // Create a timer that will trigger an event every 1000 ms.
            const int MILLISEC_PER_SEC = 1000;
            oneSecondElapsed = new Timer(MILLISEC_PER_SEC);

            // Hook up elapsed event timer
            oneSecondElapsed.Elapsed += EventHandler;

            // Set timer to operate continually, and begin
            oneSecondElapsed.AutoReset = true;
            oneSecondElapsed.Enabled = true;

            // Allow user to end timer prematurely by pressing enter.
            while (remainingTime > 0)
            {
                string userInput = Console.ReadLine();
                if (userInput.Length > 0 && userInput.ToLower()[0] == 'q')
                {
                    break;
                }
                else
                {
                    oneSecondElapsed.Enabled = !oneSecondElapsed.Enabled;
                    UpdateScreen();
                    Console.Write("Press Enter key to {0}.", oneSecondElapsed.Enabled ? "pause" : "resume");
                }
            }

            // Cleanup
            oneSecondElapsed.Stop();
            oneSecondElapsed.Dispose();
            UpdateScreen();

        }

        static void EventHandler(Object source, ElapsedEventArgs e)
        {

            remainingTime--;
            UpdateScreen();

            Console.Write("Press Enter key to pause.");

        }

        static int GetStartTime()
        {

            int input;

            do
            {
                Console.Write("Enter start time for countdown timer (in seconds): ");
                input = int.TryParse(Console.ReadLine(), out input) ? input : 0;
            } while (input <= 0);

            return input;

        }



        static void UpdateScreen()
        {

            const int ART_ROWS = 14;
            int currentMinutes = remainingTime / 60;
            int currentSeconds = remainingTime % 60;

            string[] timeArt = new string[14];

            Action<string[]>[] symbolsZeroThruNine =
            {
                GetArt0,
                GetArt1,
                GetArt2,
                GetArt3,
                GetArt4,
                GetArt5,
                GetArt6,
                GetArt7,
                GetArt8,
                GetArt9
            };

            // Get minutes art
            if (currentMinutes < 10)
            {
                GetArtNull(timeArt);
                symbolsZeroThruNine[currentMinutes](timeArt);
            }
            else if (currentMinutes < 100)
            {
                symbolsZeroThruNine[currentMinutes / 10](timeArt);
                symbolsZeroThruNine[currentMinutes % 10](timeArt);
            }
            else
            {
                Exception tooManyMinutes = new Exception();
            }

            // Get colon art
            GetArtColon(timeArt);

            // Get seconds art
            symbolsZeroThruNine[currentSeconds / 10](timeArt);
            symbolsZeroThruNine[currentSeconds % 10](timeArt);

            Console.Clear();
            for (int i = 0; i < ART_ROWS; i++)
            {
                Console.WriteLine(timeArt[i]);
            }

            if (remainingTime == 0)
            {
                oneSecondElapsed.Stop();
            }

        }

        static void GetArtColon(string[] timeArt)
        {
            timeArt[0] += @"  ______________ ";
            timeArt[1] += @" / ____________ \";
            timeArt[2] += @" ||            ||";
            timeArt[3] += @" ||            ||";
            timeArt[4] += @" ||     o      ||";
            timeArt[5] += @" ||    o o     ||";
            timeArt[6] += @" ||     o      ||";
            timeArt[7] += @" ||            ||";
            timeArt[8] += @" ||     o      ||";
            timeArt[9] += @" ||    o o     ||";
            timeArt[10] += @" ||     o      ||";
            timeArt[11] += @" ||            ||";
            timeArt[12] += @" ||____________||";
            timeArt[13] += @" \______________/";
        }

        static void GetArtNull(string[] timeArt)
        {
            timeArt[0] += @"  ______________ ";
            timeArt[1] += @" / ____________ \";
            timeArt[2] += @" ||            ||";
            timeArt[3] += @" ||            ||";
            timeArt[4] += @" ||            ||";
            timeArt[5] += @" ||            ||";
            timeArt[6] += @" ||            ||";
            timeArt[7] += @" ||            ||";
            timeArt[8] += @" ||            ||";
            timeArt[9] += @" ||            ||";
            timeArt[10] += @" ||            ||";
            timeArt[11] += @" ||            ||";
            timeArt[12] += @" ||____________||";
            timeArt[13] += @" \______________/";
        }

        static void GetArt0(string[] timeArt)
        {
            timeArt[0] += @"  ______________ ";
            timeArt[1] += @" / ____________ \";
            timeArt[2] += @" ||            ||";
            timeArt[3] += @" ||    0000    ||";
            timeArt[4] += @" ||   00  00   ||";
            timeArt[5] += @" ||  00   000  ||";
            timeArt[6] += @" ||  00  0000  ||";
            timeArt[7] += @" ||  00 00 00  ||";
            timeArt[8] += @" ||  0000  00  ||";
            timeArt[9] += @" ||  000   00  ||";
            timeArt[10] += @" ||   00  00   ||";
            timeArt[11] += @" ||    0000    ||";
            timeArt[12] += @" ||____________||";
            timeArt[13] += @" \______________/";
        }

        static void GetArt1(string[] timeArt)
        {
            timeArt[0] += @"  ______________ ";
            timeArt[1] += @" / ____________ \";
            timeArt[2] += @" ||            ||";
            timeArt[3] += @" ||      11    ||";
            timeArt[4] += @" ||     111    ||";
            timeArt[5] += @" ||    1111    ||";
            timeArt[6] += @" ||      11    ||";
            timeArt[7] += @" ||      11    ||";
            timeArt[8] += @" ||      11    ||";
            timeArt[9] += @" ||      11    ||";
            timeArt[10] += @" ||      11    ||";
            timeArt[11] += @" ||   1111111  ||";
            timeArt[12] += @" ||____________||";
            timeArt[13] += @" \______________/";
        }

        static void GetArt2(string[] timeArt)
        {
            timeArt[0] += @"  ______________ ";
            timeArt[1] += @" / ____________ \";
            timeArt[2] += @" ||            ||";
            timeArt[3] += @" ||    2222    ||";
            timeArt[4] += @" ||  22   22   ||";
            timeArt[5] += @" ||       22   ||";
            timeArt[6] += @" ||       22   ||";
            timeArt[7] += @" ||      22    ||";
            timeArt[8] += @" ||     22     ||";
            timeArt[9] += @" ||    22      ||";
            timeArt[10] += @" ||   22       ||";
            timeArt[11] += @" ||  22222222  ||";
            timeArt[12] += @" ||____________||";
            timeArt[13] += @" \______________/";
        }
        static void GetArt3(string[] timeArt)
        {
            timeArt[0] += @"  ______________ ";
            timeArt[1] += @" / ____________ \";
            timeArt[2] += @" ||            ||";
            timeArt[3] += @" ||  33333333  ||";
            timeArt[4] += @" ||        33  ||";
            timeArt[5] += @" ||        33  ||";
            timeArt[6] += @" ||      33    ||";
            timeArt[7] += @" ||    33      ||";
            timeArt[8] += @" ||      333   ||";
            timeArt[9] += @" ||        33  ||";
            timeArt[10] += @" ||  33    33  ||";
            timeArt[11] += @" ||    3333    ||";
            timeArt[12] += @" ||____________||";
            timeArt[13] += @" \______________/";
        }
        static void GetArt4(string[] timeArt)
        {
            timeArt[0] += @"  ______________ ";
            timeArt[1] += @" / ____________ \";
            timeArt[2] += @" ||            ||";
            timeArt[3] += @" ||       44   ||";
            timeArt[4] += @" ||      444   ||";
            timeArt[5] += @" ||     4444   ||";
            timeArt[6] += @" ||    44 44   ||";
            timeArt[7] += @" ||   44  44   ||";
            timeArt[8] += @" ||  4444444   ||";
            timeArt[9] += @" ||       44   ||";
            timeArt[10] += @" ||       44   ||";
            timeArt[11] += @" ||       44   ||";
            timeArt[12] += @" ||____________||";
            timeArt[13] += @" \______________/";
        }
        static void GetArt5(string[] timeArt)
        {
            timeArt[0] += @"  ______________ ";
            timeArt[1] += @" / ____________ \";
            timeArt[2] += @" ||            ||";
            timeArt[3] += @" ||  55555555  ||";
            timeArt[4] += @" ||  55        ||";
            timeArt[5] += @" ||  55        ||";
            timeArt[6] += @" ||  55 555    ||";
            timeArt[7] += @" ||  555  55   ||";
            timeArt[8] += @" ||        55  ||";
            timeArt[9] += @" ||        55  ||";
            timeArt[10] += @" ||  55   55   ||";
            timeArt[11] += @" ||    555     ||";
            timeArt[12] += @" ||____________||";
            timeArt[13] += @" \______________/";
        }
        static void GetArt6(string[] timeArt)
        {
            timeArt[0] += @"  ______________ ";
            timeArt[1] += @" / ____________ \";
            timeArt[2] += @" ||            ||";
            timeArt[3] += @" ||    6666    ||";
            timeArt[4] += @" ||  66    66  ||";
            timeArt[5] += @" ||  66        ||";
            timeArt[6] += @" ||  66        ||";
            timeArt[7] += @" ||  66 666    ||";
            timeArt[8] += @" ||  666   66  ||";
            timeArt[9] += @" ||  66    66  ||";
            timeArt[10] += @" ||  66    66  ||";
            timeArt[11] += @" ||    6666    ||";
            timeArt[12] += @" ||____________||";
            timeArt[13] += @" \______________/";
        }
        static void GetArt7(string[] timeArt)
        {
            timeArt[0] += @"  ______________ ";
            timeArt[1] += @" / ____________ \";
            timeArt[2] += @" ||            ||";
            timeArt[3] += @" ||  77777777  ||";
            timeArt[4] += @" ||  77    77  ||";
            timeArt[5] += @" ||        77  ||";
            timeArt[6] += @" ||      77    ||";
            timeArt[7] += @" ||   777777   ||";
            timeArt[8] += @" ||    77      ||";
            timeArt[9] += @" ||   77       ||";
            timeArt[10] += @" ||   77       ||";
            timeArt[11] += @" ||   77       ||";
            timeArt[12] += @" ||____________||";
            timeArt[13] += @" \______________/";
        }
        static void GetArt8(string[] timeArt)
        {
            timeArt[0] += @"  ______________ ";
            timeArt[1] += @" / ____________ \";
            timeArt[2] += @" ||            ||";
            timeArt[3] += @" ||     888    ||";
            timeArt[4] += @" ||   88   88  ||";
            timeArt[5] += @" ||   88   88  ||";
            timeArt[6] += @" ||     888    ||";
            timeArt[7] += @" ||   88  88   ||";
            timeArt[8] += @" ||  88    88  ||";
            timeArt[9] += @" ||  88    88  ||";
            timeArt[10] += @" ||   88   88  ||";
            timeArt[11] += @" ||    8888    ||";
            timeArt[12] += @" ||____________||";
            timeArt[13] += @" \______________/";
        }
        static void GetArt9(string[] timeArt)
        {
            timeArt[0] += @"  ______________ ";
            timeArt[1] += @" / ____________ \";
            timeArt[2] += @" ||            ||";
            timeArt[3] += @" ||    9999    ||";
            timeArt[4] += @" ||  99   99   ||";
            timeArt[5] += @" ||  99    99  ||";
            timeArt[6] += @" ||  99   999  ||";
            timeArt[7] += @" ||    99999   ||";
            timeArt[8] += @" ||      99    ||";
            timeArt[9] += @" ||     99     ||";
            timeArt[10] += @" ||    99      ||";
            timeArt[11] += @" ||   99       ||";
            timeArt[12] += @" ||____________||";
            timeArt[13] += @" \______________/";
        }
    }
}
