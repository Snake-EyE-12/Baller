public class BallGame
{
    public BallGame()
    {
        currentInning = 0;
        outs = 0;
        SetHomeOrAway(true);
    }

    public BallGame(BallGameDefinition def) : this() {} // when the game changes init

    private void SetHomeOrAway(bool wantsHome)
    {
        battingTeam = new PlayerBallerTeam();
        pitchingTeam = new BotBallerTeam();
        if (wantsHome) swapTeams();
    }
    
    private int currentInning;
    private int outs;
    private void advanceInning()
    {
        currentInning++;
        swapTeams();
    }

    private void swapTeams()
    {
        (battingTeam, pitchingTeam) = (pitchingTeam, battingTeam);
    }

    private BallerTeam battingTeam;
    private BallerTeam pitchingTeam;

    public void crossHome()
    {
        battingTeam.score();
    }

    public void getOut()
    {
        outs++;
        if (outs >= 3)
        {
            advanceInning();
        }
    }
}

public class BallGameDefinition
{
    
}

public abstract class BallerTeam
{
    public void score()
    {
        
    }
}

public class PlayerBallerTeam : BallerTeam
{
    
}

public class BotBallerTeam : BallerTeam
{
    
}
