using UnityEngine;
public static class Global {
    public static bool isPause;//控制是否暂停
    public static float volumeRate;//音量比例

    public static void Pause()
    {

        Global.isPause = !Global.isPause;

        Time.timeScale = Global.isPause ? 0 : 1;

    }
}