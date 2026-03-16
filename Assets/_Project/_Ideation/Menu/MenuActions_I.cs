using UnityEngine;

public class MenuActions_I : MonoBehaviour
{
    public void OnClickPlay()
    {
        Controller_I.instance.view.sceneControl.mainMenu.OnPlay();
    }

    public void OnClickExit()
    {
        Controller_I.instance.view.sceneControl.mainMenu.OnExit();
    }
}
