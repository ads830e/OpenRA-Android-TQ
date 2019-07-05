using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using SDL2;

using System.Runtime.InteropServices;
using Android.Content.Res;
using Android.Util;

using OpenRA;

namespace SDL2Droid_CS {
    delegate void Main();

    // Delegates for the example code
    delegate void DglClearColor(
        float red,
        float green,
        float blue,
        float alpha
    );
    delegate void DglClear(int mask);

    static class Bootstrap {
        /*
        [DllImport("openal", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr alcOpenDevice(
            [In()] [MarshalAs(UnmanagedType.LPStr)]
                string devicename
        );

        [DllImport("openal", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool alcCloseDevice(IntPtr device);
        */

        public static void SDL_Main() {
            //IntPtr dev = alcOpenDevice(null);
            //alcCloseDevice(dev);

            

            //dev = AL10.alcOpenDevice(null);
            //AL10.alcCloseDevice(dev);


            String[] a = new String[2];
            a[0] = "OpenRA.Game";
            a[1] = "Game.Mod=ra";
            OpenRA.Program.Main(a);

            //OpenRA_Mod_Common_ForceDependence.ForceDependence.ForceDependenceFunc();

            //Console.WriteLine("ForceDependence.a:{0}", OpenRA_Mod_Cnc_ForceDependence.ForceDependence.a);
            //Console.WriteLine("ForceDependence.a:{0}", OpenRA_Mod_Common_ForceDependence.ForceDependence.a);



            // Example code.

            // OPTIONAL: Hide action bar (top bar). Otherwise it just shows the window title.
            // MainActivity.Instance.RunOnUiThread(MainActivity.Instance.ActionBar.Hide);

            // OPTIONAL: Fullscreen (immersive), handled by the activity
            MainActivity.SDL2DCS_Fullscreen = true;

            SDL.SDL_Init(
                SDL.SDL_INIT_VIDEO |
                SDL.SDL_INIT_JOYSTICK |
                SDL.SDL_INIT_GAMECONTROLLER |
                SDL.SDL_INIT_HAPTIC
            );

            // OPTIONAL: Get WM. Required to set the backbuffer size to the screen size
            DisplayMetrics dm = new DisplayMetrics();
            MainActivity.SDL2DCS_Instance.WindowManager.DefaultDisplay.GetMetrics(dm);

            IntPtr window = SDL.SDL_CreateWindow(
                "HEY, LISTEN!",
                SDL.SDL_WINDOWPOS_CENTERED,
                SDL.SDL_WINDOWPOS_CENTERED,
                dm.WidthPixels,
                dm.HeightPixels,
                SDL.SDL_WindowFlags.SDL_WINDOW_OPENGL |
                SDL.SDL_WindowFlags.SDL_WINDOW_INPUT_FOCUS |
                SDL.SDL_WindowFlags.SDL_WINDOW_MOUSE_FOCUS
            );

            SDL.SDL_GL_SetAttribute(SDL.SDL_GLattr.SDL_GL_SHARE_WITH_CURRENT_CONTEXT, 1);

            IntPtr glContext = SDL.SDL_GL_CreateContext(window);
            SDL.SDL_GL_MakeCurrent(window, glContext);

            SDL.SDL_DisableScreenSaver();

            DglClearColor glClearColor = (DglClearColor) Marshal.GetDelegateForFunctionPointer(
                SDL.SDL_GL_GetProcAddress("glClearColor"),
                typeof(DglClearColor)
            );
            DglClear glClear = (DglClear) Marshal.GetDelegateForFunctionPointer(
                SDL.SDL_GL_GetProcAddress("glClear"),
                typeof(DglClear)
            );

            DateTime start = DateTime.UtcNow;

            SDL.SDL_Event evt;
            DateTime now;
            TimeSpan span;
            while (true) {
                while (SDL.SDL_PollEvent(out evt) == 1) {
                    if (evt.type == SDL.SDL_EventType.SDL_QUIT) {
                        goto QUIT;
                    }
                }

                now = DateTime.UtcNow;
                span = now - start;

                float t = (float) (Math.Sin(span.TotalSeconds) * 0.5 + 0.5);

                glClearColor(t, t, t, 1f);
                glClear(0x4000); // GL_COLOR_BUFFER_BIT

                SDL.SDL_GL_SwapWindow(window);
            }

            QUIT:
            SDL.SDL_Quit();

        }

        public static void SetupMain() {
            // Give the main library something to call in Mono-Land afterwards
            SetMain(SDL_Main);

            // Insert your own post-lib-load, pre-SDL2 code here.
        }

        [DllImport("main")]
        static extern void SetMain(Main main);

    }
}