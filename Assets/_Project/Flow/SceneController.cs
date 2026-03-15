using UnityEngine.SceneManagement;

public class SceneController
{
    public SceneController()
    {
        mainMenu = new MainMenuController();
        creationMenu = new CreationMenuController();
    }
    public MainMenuController mainMenu {get; private set;}
    public CreationMenuController creationMenu {get; private set;}
}

public class MainMenuController
{
    public void OnPlay()
    {
        SceneManager.LoadScene("Creation");
    }

    public void OnExit()
    {
        
    }
}

public class CreationMenuController
{
    public void OnCreate()
    {
        Controller.instance.StartGame(ConvertDataToGame());
    }

    private BallGameDefinition ConvertDataToGame()
    {
        return new BallGameDefinition();
    }

    private bool allTheData;
    public void ChangeData()
    {
        // do something to data
    }
}