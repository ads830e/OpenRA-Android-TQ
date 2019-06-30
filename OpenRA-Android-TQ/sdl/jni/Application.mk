# The ARMv7 is significanly faster due to the use of the hardware FPU
APP_ABI := armeabi-v7a x86 x86_64 mips mips64
APP_STL := gnustl_static
#STLPORT_FORCE_REBUILD := true
APP_PLATFORM := android-21
APP_OPTIM := debug
