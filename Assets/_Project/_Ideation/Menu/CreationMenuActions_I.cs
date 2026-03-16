using UnityEngine;
using UnityEngine.SceneManagement;

public class CreationMenuActions_I : MonoBehaviour
{
    public void OnClickStandard()
    {
        Controller_I.instance.view.sceneControl.creationMenu.OnCreate();
        SceneManager.LoadScene("BallGame");
    }

}
