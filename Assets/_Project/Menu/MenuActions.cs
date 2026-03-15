using UnityEngine;

public class MenuActions : MonoBehaviour
{
    public void OnClickPlay()
    {
        Controller.instance.view.sceneControl.mainMenu.OnPlay();
    }

    public void OnClickExit()
    {
        Controller.instance.view.sceneControl.mainMenu.OnExit();
    }
}
