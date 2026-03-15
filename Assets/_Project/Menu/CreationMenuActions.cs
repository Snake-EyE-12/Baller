using UnityEngine;
using UnityEngine.SceneManagement;

public class CreationMenuActions : MonoBehaviour
{
    public void OnClickStandard()
    {
        Controller.instance.view.sceneControl.creationMenu.OnCreate();
        SceneManager.LoadScene("BallGame");
    }

}
