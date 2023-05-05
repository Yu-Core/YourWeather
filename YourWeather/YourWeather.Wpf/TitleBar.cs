using PInvoke;
using System.Runtime.InteropServices;
using YourWeather.Shared;
using static PInvoke.User32;

namespace YourWeather.Wpf
{
    public static class TitleBar
    {
        private static IntPtr _handle;
        public static void Init(IntPtr handle)
        {
            _handle = handle;
        }

        public static void EnableDarkMode(bool value)
        {
            UseImmersiveDarkMode(_handle, value);
        }

        [DllImport("dwmapi.dll")]
        private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);

        private const int DWMWA_USE_IMMERSIVE_DARK_MODE_BEFORE_20H1 = 19;
        private const int DWMWA_USE_IMMERSIVE_DARK_MODE = 20;

        private static bool UseImmersiveDarkMode(IntPtr handle, bool enabled)
        {
            if (IsWindows10OrGreater(17763))
            {
                var attribute = DWMWA_USE_IMMERSIVE_DARK_MODE_BEFORE_20H1;
                if (IsWindows10OrGreater(18985))
                {
                    attribute = DWMWA_USE_IMMERSIVE_DARK_MODE;
                }

                int useImmersiveDarkMode = enabled ? 1 : 0;
                bool flag = DwmSetWindowAttribute(handle, (int)attribute, ref useImmersiveDarkMode, sizeof(int)) == 0;
                var activeWindow = User32.GetActiveWindow();
                if (_handle == activeWindow)
                {
                    User32.PostMessage(_handle, WindowMessage.WM_NCACTIVATE, new IntPtr((int)0x00), IntPtr.Zero);
                    User32.PostMessage(_handle, WindowMessage.WM_NCACTIVATE, new IntPtr((int)0x01), IntPtr.Zero);
                }
                else
                {
                    User32.PostMessage(_handle, WindowMessage.WM_NCACTIVATE, new IntPtr((int)0x01), IntPtr.Zero);
                    User32.PostMessage(_handle, WindowMessage.WM_NCACTIVATE, new IntPtr((int)0x00), IntPtr.Zero);
                }

                return flag;
            }

            return false;
        }

        private static bool IsWindows10OrGreater(int build = -1)
        {
            return Environment.OSVersion.Version.Major >= 10 && Environment.OSVersion.Version.Build >= build;
        }
    }
}
