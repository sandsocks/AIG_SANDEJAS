using UnityEngine;

public interface ICarState
{
    void Enter();

    void Tick();

    void Exit();
}
