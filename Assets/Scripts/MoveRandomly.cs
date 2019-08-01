using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;
using UnityEngine.AI;

public class MoveRandomly : MonoBehaviour
{
    [SerializeField]
    [Range(1.0f, 10f)]
    private float moveSpeed = 5.0f;
    
    private Vector3 destination;
    public NavMeshAgent agent;
    public ThirdPersonCharacter character;

    // Start is called before the first frame update
    void Start()
    {
        // Find a new random destination
        destination = FindNewDestination();
        agent.updateRotation = false;
        agent.SetDestination(destination);
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = Vector3.MoveTowards(transform.position, destination, Time.deltaTime * moveSpeed);
        character.Move(agent.desiredVelocity, false, false);

        //if (transform.position == destination)
        if (agent.remainingDistance <= agent.stoppingDistance)
            {
            // Find a new random destination
            character.Move(Vector3.zero, false, false);
            destination = FindNewDestination();
            agent.SetDestination(destination);
        }
    }

    private Vector3 FindNewDestination()
    {
        return new Vector3(Random.Range(-10.0f, 10.0f), transform.position.y, Random.Range(1.0f, 10.0f));
    }
    /*
    private void LateUpdate()
    {
        transform.LookAt(2 * transform.position - Camera.main.transform.position);
        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
    }
    */
}
