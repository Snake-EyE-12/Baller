public class BallGame_I
{
    public BallGame_I()
    {
        currentInning = 0;
        outs = 0;
        SetHomeOrAway(true);
    }

    public BallGame_I(BallGameDefinition_I def) : this() {} // when the game changes init

    private void SetHomeOrAway(bool wantsHome)
    {
        battingTeam = new PlayerBallerTeam_I();
        pitchingTeam = new BotBallerTeam_I();
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

    private BallerTeam_I battingTeam;
    private BallerTeam_I pitchingTeam;

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

public class BallGameDefinition_I
{
    
}

public abstract class BallerTeam_I
{
    public void score()
    {
        
    }
}

public class PlayerBallerTeam_I : BallerTeam_I
{
    
}

public class BotBallerTeam_I : BallerTeam_I
{
    
}
