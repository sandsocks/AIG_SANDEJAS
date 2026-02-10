/*0 speed
 stay stop if red light
else switch to slowdown or go*/

public class CarStopState : ICarState
{
    private readonly CarAI car;
    private readonly StateMachine sm;

    public CarStopState(CarAI car, StateMachine sm)
    {
        this.car = car;
        this.sm = sm;
    }
    public void Enter()
    {
        
    }

    public void Exit()
    {
        
    }

    public void Tick()
    {
        car.SetTargetSpeed(0);
        //light is only considered in traffic light is not null
        bool red = car.ActiveTrafficLight != null && car.ActiveTrafficLight.IsRed;
        //if red light or front car is stopped, keep stopping
        if (red || car.CarAheadStoppedClose) return;
        //if orange light while near intersection, slow down
        bool orange = car.ActiveTrafficLight != null && car.ActiveTrafficLight.IsOrange;
        //if orange or there is car ahead, just slow down
        if (orange || car.CarAheadDetected) { sm.Change(car.SlowdownState); }
        else {  sm.Change(car.GoState);}
    }
}
