using UnityEngine;

public enum LightColor { Red, Orange, Green }
public class TrafficLight : MonoBehaviour
{
    public LightColor current = LightColor.Red;
    public TrafficLight light;

    public bool IsRed => current == LightColor.Red;
    public bool IsOrange => current == LightColor.Orange;
    public bool IsGreen => current == LightColor.Green;

    public void OnTriggerEnter(Collider other)
    {
        CarAI car = other.GetComponent<CarAI>();
        if (car != null)
        {
            car.SetActiveTrafficLight(light);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        CarAI car = GetComponent<CarAI>();
        if (car != null)
        {
            car.ClearActiveTrafficLight(light);
        }
    }
}
