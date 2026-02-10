using UnityEngine;

public class CarGoState : ICarState
{
    private readonly CarAI car;
    private readonly StateMachine sm;

    public CarGoState(CarAI car, StateMachine sm)
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

        //if orange light
        bool orange = car.ActiveTrafficLight != car.ActiveTrafficLight.IsOrange;
        if (orange || car.CarAheadStoppedClose)
        {
            sm.Change(car.SlowdownState);
            return;
        }

        car.SetTargetSpeed(car.goSpeed);
    }
}
