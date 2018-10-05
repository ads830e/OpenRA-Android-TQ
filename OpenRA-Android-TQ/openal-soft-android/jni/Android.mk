#
# Android.mk
#
# Created by wistone on 16/7/8.
# Author  : wistone
# Email   : xiyanglu@gmail.com
#

TARGET_PLATFORM := android-21
ROOT_PATH := $(call my-dir)

LOCAL_MODULE := openal-soft-android

########################################################################################################
include $(CLEAR_VARS)

OPENAL_ROOT      := $(ROOT_PATH)/openal
OPENAL_ALC       := $(OPENAL_ROOT)/Alc
OPENAL_AL32      := $(OPENAL_ROOT)/OpenAL32

$(warning OpenAL Root = $(OPENAL_ROOT))
$(warning $(OPENAL_ALC))
$(warning $(OPENAL_AL32))

LOCAL_MODULE     := openal-soft-android
LOCAL_ARM_MODE   := arm
LOCAL_PATH       := $(ROOT_PATH)
LOCAL_C_INCLUDES := $(LOCAL_PATH)                          \
                    $(OPENAL_ROOT)                         \
                    $(OPENAL_ROOT)/include                     \
                    $(OPENAL_ROOT)/Alc                         \
                    $(OPENAL_ROOT)/OpenAL32                \
                    $(OPENAL_ROOT)/OpenAL32/Include

LOCAL_SRC_FILES  := \
            $(OPENAL_ALC)/ALc.c \
            $(OPENAL_ALC)/alcConfig.c \
            $(OPENAL_ALC)/alcDedicated.c \
            $(OPENAL_ALC)/alcEcho.c \
            $(OPENAL_ALC)/alcModulator.c \
            $(OPENAL_ALC)/alcReverb.c \
            $(OPENAL_ALC)/alcRing.c \
            $(OPENAL_ALC)/alcThread.c \
            $(OPENAL_ALC)/ALu.c \
            $(OPENAL_ALC)/bs2b.c \
            $(OPENAL_ALC)/helpers.c \
            $(OPENAL_ALC)/hrtf.c \
            $(OPENAL_ALC)/mixer.c \
            $(OPENAL_ALC)/panning.c \
            \
            $(OPENAL_ALC)/backends/android.c \
            $(OPENAL_ALC)/backends/loopback.c \
            $(OPENAL_ALC)/backends/null.c \
            $(OPENAL_ALC)/backends/opensl.c \
            $(OPENAL_ALC)/backends/wave.c \
            \
            $(OPENAL_AL32)/alAuxEffectSlot.c \
            $(OPENAL_AL32)/alBuffer.c \
            $(OPENAL_AL32)/alEffect.c \
            $(OPENAL_AL32)/alError.c \
            $(OPENAL_AL32)/alExtension.c \
            $(OPENAL_AL32)/alFilter.c \
            $(OPENAL_AL32)/alListener.c \
            $(OPENAL_AL32)/alSource.c \
            $(OPENAL_AL32)/alState.c \
            $(OPENAL_AL32)/alThunk.c \
            \
            $(OPENAL_ROOT)/utils/openal-info.c \

LOCAL_CFLAGS     := -DAL_BUILD_LIBRARY \
                    -DAL_ALEXT_PROTOTYPES \
                    -DANDROID \
                    -fpic \
                    -ffunction-sections \
                    -funwind-tables \
                    -fstack-protector \
                    -fno-short-enums \
                    -DHAVE_GCC_VISIBILITY \
                    -ffast-math \
                    -std=c99 \

LOCAL_LDLIBS     := -lOpenSLES -llog



include $(BUILD_SHARED_LIBRARY)
