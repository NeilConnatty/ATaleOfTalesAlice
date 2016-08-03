using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Networking;

/*
 * Script describing behaviour of create game button in main menu ui
 */
public class CreateGameButton : MonoBehaviour
{
    public InputField inputField;
    public NetworkManagerHUD managerHUD;

    public void createGame ()
    {
        if (inputField.text.Equals ("")) return;
        managerHUD.CreateMatch (inputField.text);
    }
}
