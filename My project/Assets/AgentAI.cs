using UnityEngine;
using UnityEngine.AI;

public class AgentAI : MonoBehaviour
{
    private NavMeshAgent agent;
    public Transform pointA, pointB;
    public Transform currentTarget;
    public bool destinationReached;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        //makes the agent go to the target destination (Vector3)
        agent.SetDestination(pointA.position);
        destinationReached = false;
    }

    // Update is called once per frame
    void Update()
    {
        //DestinationCheck();
        if (agent.pathPending) return;
        if (agent.remainingDistance <= agent.stoppingDistance && agent.velocity.sqrMagnitude == 0)
            {
                currentTarget = (currentTarget == pointA) ? pointB : pointA;
                agent.SetDestination(currentTarget.position);
            }
                
    }

    /*public void DestinationCheck()
    {
        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            ////destinationReached = true;

            ////checks velocity of agent
            //if (agent.velocity.sqrMagnitude == 0)
            //{
            //    //checks if agent has no path
            //    if (!agent.hasPath)
            //    {
            //        //checks if ai has next destination
            //        if (agent.pathPending)
            //        {
            //            destinationReached = true;
            //        }

            //    }
            //}
        }

    }*/

    public void ToPointA()
    {

    }
}
