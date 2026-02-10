using UnityEngine;

public class CarAI : MonoBehaviour
{
    [Header("Speeds")]
    public float goSpeed,
                 slowSpeed,
                 accelarationSpeed,
                 brake;

    [Header("Sensor")]
    public float frontCheckingDistance, stopDistance;
    public LayerMask carLayer;

    public TrafficLight ActiveTrafficLight {  get; private set; }
    public float currentSpeed {  get; private set; }
    public bool CarAheadDetected { get; private set; }

    public bool CarAheadStoppedClose { get; private set; }

    private StateMachine sm;

    //state instance
    public CarStopState StopState { get; private set; }
    public CarGoState GoState { get; private set; }
    public CarSlowdownState SlowdownState { get; private set; }

    void Awake()
    {
        sm = new StateMachine();
        StopState =  new CarStopState(this, sm);
        GoState = new CarGoState(this, sm); 
        SlowdownState = new CarSlowdownState(this, sm);
    }

    void Start()
    {
        sm.Change(StopState);
    }

    void Update()
    {
        UpdateSensor();
        sm.tick();
        MoveForward();
    }

    void MoveForward()
    {
        transform.position += transform.forward * (currentSpeed * Time.deltaTime);
    }

    void UpdateSensor()
    {
        CarAheadDetected = false;
        CarAheadStoppedClose = false;
        Vector3 dir = Vector3.forward;
        Debug.DrawRay(transform.position, dir * frontCheckingDistance);
        if (Physics.Raycast(transform.position, dir, out RaycastHit hit, frontCheckingDistance, carLayer))
        {
            CarAheadDetected = true;
            CarAI other  = hit.collider.GetComponent<CarAI>();
            float otherSpeed = other != null ? other.currentSpeed : 0;
            bool otherStopped = otherSpeed <= 0.1f;
            bool veryClose = hit.distance < stopDistance;
            CarAheadStoppedClose = otherStopped && veryClose;
        } 

    }

    public void SetTargetSpeed(float target)
    {
        float rate = (target>currentSpeed) ? currentSpeed : brake;
        currentSpeed = Mathf.MoveTowards(currentSpeed, target, rate * Time.deltaTime);
    }

    public void SetActiveTrafficLight(TrafficLight light)
    {
        ActiveTrafficLight = light;
    }

    public void ClearActiveTrafficLight(TrafficLight light)
    {
        if (ActiveTrafficLight == light)
            ActiveTrafficLight = null;
    }
}
