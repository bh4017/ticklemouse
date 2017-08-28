namespace ticklemouse
{
    using System;
    using System.Runtime.InteropServices;

    public static class Tickler
    {
        [DllImport("user32.dll")]
        static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);
        public static void MoveMouse(int dx, int dy)
        {
            mouse_event(0x0001, dx, dy, 0, 0);
        }
    }
}

