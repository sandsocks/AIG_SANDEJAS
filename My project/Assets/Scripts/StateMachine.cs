/*Statemachine is responsible for:
storting current state
switching states (exit->enter)
updated current state*/

public class StateMachine 
{
    //holds active state

    public ICarState CurrentCarState { get; private set; }

    //change switches the active stte to "next"

    public void Change(ICarState next)
    {
        //if there is a current state, call Exit() before switching.
        CurrentCarState?.Exit();

        //Set the new state
        CurrentCarState = next;

        //call enter once new state begins
        CurrentCarState.Enter();
    }

    public void tick()
    {

    }
}
