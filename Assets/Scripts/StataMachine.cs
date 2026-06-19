

public class StataMachine 
{
    public EntityState CurrentState { get;private set; }
    public EntityState LastCurrstate { get;private set; }

    public void Init(EntityState state)
    {
        CurrentState = state;
        CurrentState.Enter();
        
    }
    
    public void ChangeState(EntityState newState)
    {
        LastCurrstate = CurrentState;
        CurrentState.Exit();
        CurrentState = newState;
        CurrentState.Enter();
    }
  
}
