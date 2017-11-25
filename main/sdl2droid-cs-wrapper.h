#ifndef SDL2DROID_CS_WRAPPER_H
#define SDL2DROID_CS_WRAPPER_H

#include <android/log.h>
#include <SDL.h>

#define  LOG_TAG    "SDL2DROID-CS-wrapper"
#define  LOGI(...)  __android_log_print(ANDROID_LOG_INFO,LOG_TAG,__VA_ARGS__)
#define  LOGW(...)  __android_log_print(ANDROID_LOG_WARN,LOG_TAG,__VA_ARGS__)
#define  LOGE(...)  __android_log_print(ANDROID_LOG_ERROR,LOG_TAG,__VA_ARGS__)

// We're passing a function pointer to "return" to C# land here
typedef void (*Main)();
Main CurrentMain;

extern DECLSPEC void SDLCALL SetMain(Main main);

#endif
