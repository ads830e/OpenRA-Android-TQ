# OpenRA-Android-TQ

Move the resource file to sdcard/OpenRA.Now the program can read the files such as settings.yaml.
In OpenRA there are two paths:./ and ^/.I just move all things to /sdcard/OpenRA.The sdcard path is got by Android.OS.Environment.ExternalStorageDirectory.Path.

2017-11-26
************************************************************

SDL2 works.But there are errors when loading game files.Besides ,there are differences between OpenGL and GLES,which makes the init failed.

2017-11-25
************************************************************
It's too complicated.Fail at sdl_createwindow.

2017-11-19
