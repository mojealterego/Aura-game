using UnityEngine;

namespace Aura.Haptics
{
    public static class AuraHaptics
    {
        public static bool Enabled { get; set; } = true;

        public static void Confirm()
        {
            if (!Enabled || Application.platform != RuntimePlatform.Android) return;
            try
            {
                using (var player = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
                using (var activity = player.GetStatic<AndroidJavaObject>("currentActivity"))
                using (var window = activity.Call<AndroidJavaObject>("getWindow"))
                using (var decor = window.Call<AndroidJavaObject>("getDecorView"))
                {
                    decor.Call<bool>("performHapticFeedback", 1);
                }
            }
            catch (AndroidJavaException exception)
            {
                Debug.LogWarning("Aura haptic unavailable: " + exception.Message);
            }
        }
    }
}
