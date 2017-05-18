using System.Runtime.InteropServices;

public class GowIOSBinding
{
    [DllImport("__Internal")]
    private static extern void _gowInit(string serverUrl, string gameKey, string gameId, string publicKey);

    [DllImport("__Internal")]
    private static extern void _gowRegisterForRemoteNotifications();

    [DllImport("__Internal")]
    private static extern void _gowShowDefaultDialog(string title, string message, string buttonOk,
        string buttonCancel);

    [DllImport("__Internal")]
    private static extern void _gowRequestNotifications(bool cleanAfter);

    [DllImport("__Internal")]
    private static extern void _gowRemoveNotification(string pushId);

    [DllImport("__Internal")]
    private static extern void _gowCancelNotification();

    public static void Init(string serverUrl, string gameKey, string gameId, string publicKey)
    {
        _gowInit(serverUrl, gameKey, gameId, publicKey);
    }

    public static void RegisterForRemoteNotifications()
    {
        _gowRegisterForRemoteNotifications();
    }

    public static void ShowDefaultDialog(string title, string messages, string[] buttons)
    {
        var buttonOk = buttons.Length > 0 ? buttons[0] : null;
        var buttonCancel = buttons.Length > 1 ? buttons[1] : null;

        _gowShowDefaultDialog(title, messages, buttonOk, buttonCancel);
    }

    public static void RequestNotifications()
    {
        _gowRequestNotifications(false);
    }

    public static void RemoveNotification(string pushId)
    {
        _gowRemoveNotification(pushId);
    }

    public static void CancelNotification()
    {
        _gowCancelNotification();
    }
}