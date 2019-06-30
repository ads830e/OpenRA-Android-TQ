# OpenRA-Android-TQ

Opengl may works.Failed on libgdiplus.It seems depending on windows gdiplus or linux x-windows.How to move it to Android?

2018-11-04

************************************************************

Use gl4es to replace opengl...
Use glsl from gles branch of openra

Now a new problem occurs. OpenAL failed when calling alcOpenDevice:
10-05 09:29:37.554 F/        ( 4655): * Assertion at /Users/builder/jenkins/workspace/xamarin-android-d15-8/xamarin-android/external/mono/mono/metadata/metadata.c:1117, condition `idx < t->rows' not met
10-05 09:29:37.554 F/libc    ( 4655): Fatal signal 6 (SIGABRT), code -6 in tid 4681 (SDLThread), pid 4655 (RA_TQ.OpenRA_TQ)

I don't know the reason at all.I have tried to recompile openal and openal-cs.But it is not useful...

2018-10-05

************************************************************

Move the resource file to sdcard/OpenRA.Now the program can read the files such as settings.yaml.
In OpenRA there are two paths:./ and ^/.I just move all things to /sdcard/OpenRA.The sdcard path is got by Android.OS.Environment.ExternalStorageDirectory.Path.

2017-11-26
************************************************************

SDL2 works.But there are errors when loading game files.Besides ,there are differences between OpenGL and GLES,which makes the init failed.

2017-11-25
************************************************************
It's too complicated.Fail at sdl_createwindow.

2017-11-19
