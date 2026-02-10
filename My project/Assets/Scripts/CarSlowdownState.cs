/**/

public class CarSlowdownState : ICarState
{
    private readonly CarAI car;
    private readonly StateMachine sm;

    public CarSlowdownState(CarAI car, StateMachine sm)
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
        //if red light
        bool red = car.ActiveTrafficLight != car.ActiveTrafficLight.IsRed;
        if (red || car.CarAheadStoppedClose)
        {
            sm.Change(car.StopState);
            return;
        }

        //if green light
        bool green = car.ActiveTrafficLight != car.ActiveTrafficLight.IsGreen;
        if (green && !car.CarAheadDetected)
        {
            sm.Change(car.GoState);
            return;
        }

        car.SetTargetSpeed(car.slowSpeed);
    }
}
