using System;
using System.Runtime.InteropServices;
using System.Windows.Input;

namespace SmartHunter.Core
{
    public class KeyboardInput
    {
        IntPtr m_User32Handle;
        IntPtr m_KeyboardHookHandle;

        WindowsApi.HookProc m_KeyboardHook;

        public event EventHandler<KeyboardInputEventArgs> InputReceived;

        public KeyboardInput()
        {
            Hook();
        }

        ~KeyboardInput()
        {
            Unhook();
        }

        void Hook()
        {
            m_KeyboardHookHandle = IntPtr.Zero;
            m_User32Handle = IntPtr.Zero;
            m_KeyboardHook = KeyboardHook;

            m_User32Handle = WindowsApi.LoadLibrary("User32");
            if (m_User32Handle != IntPtr.Zero)
            {
                m_KeyboardHookHandle = WindowsApi.SetWindowsHookEx((int)WindowsApi.WindowsHook.WH_KEYBOARD_LL, m_KeyboardHook, m_User32Handle, 0);
            }
        }

        void Unhook()
        {
            if (m_KeyboardHookHandle != IntPtr.Zero)
            {
                WindowsApi.UnhookWindowsHookEx(m_KeyboardHookHandle);
                m_KeyboardHookHandle = IntPtr.Zero;
                m_KeyboardHook -= KeyboardHook;
            }

            if (m_User32Handle != IntPtr.Zero)
            {
                WindowsApi.FreeLibrary(m_User32Handle);
                m_User32Handle = IntPtr.Zero;
            }
        }

        static Key KeyFromVirtualCode(uint virtualCode)
        {
            return KeyInterop.KeyFromVirtualKey((int)virtualCode);
        }

        static int VirtualCodeFromKey(Key key)
        {
            return KeyInterop.VirtualKeyFromKey(key);
        }

        IntPtr KeyboardHook(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0)
            {
                var keyboardMessage = (WindowsApi.KeyboardMessage)wParam.ToInt32();
                var keyboardData = (WindowsApi.KBDLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(WindowsApi.KBDLLHOOKSTRUCT));

                var key = KeyFromVirtualCode(keyboardData.VkCode);
                bool isDown = keyboardMessage == WindowsApi.KeyboardMessage.WM_KEYDOWN || keyboardMessage == WindowsApi.KeyboardMessage.WM_SYSKEYDOWN;

                InputReceived?.Invoke(this, new KeyboardInputEventArgs(key, isDown));
            }

            return WindowsApi.CallNextHookEx(IntPtr.Zero, nCode, wParam, lParam);
        }
    }
}
