using UnityEngine.SceneManagement;

public class SceneController_I
{
    public SceneController_I()
    {
        mainMenu = new MainMenuController_I();
        creationMenu = new CreationMenuController_I();
    }
    public MainMenuController_I mainMenu {get; private set;}
    public CreationMenuController_I creationMenu {get; private set;}
}

public class MainMenuController_I
{
    public void OnPlay()
    {
        SceneManager.LoadScene("Creation");
    }

    public void OnExit()
    {
        
    }
}

public class CreationMenuController_I
{
    public void OnCreate()
    {
        Controller_I.instance.StartGame(ConvertDataToGame());
    }

    private BallGameDefinition_I ConvertDataToGame()
    {
        return new BallGameDefinition_I();
    }

    private bool allTheData;
    public void ChangeData()
    {
        // do something to data
    }
}