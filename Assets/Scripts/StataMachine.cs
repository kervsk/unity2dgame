

public class StataMachine 
{
    public EnitityStata CurrentState { get;private set; }
    public EnitityStata LastCurrstate { get;private set; }

    public void Init(EnitityStata state)
    {
        CurrentState = state;
        CurrentState.Enter();
        
    }
    
    public void ChangeState(EnitityStata newState)
    {
        LastCurrstate = CurrentState;
        CurrentState.Exit();
        CurrentState = newState;
        CurrentState.Enter();
    }
  
}
