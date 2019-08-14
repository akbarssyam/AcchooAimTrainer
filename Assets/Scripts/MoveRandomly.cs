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

    public float stoppingDistance = 2.0f;

    [HideInInspector]
    public GameObject groundObject;

    public bool jumping = false;

    private Vector3 destination, velocity;
    public ThirdPersonCharacter character;
    
    // Start is called before the first frame update
    void Start()
    {
        // Find a new random destination
        destination = FindNewDestination();
        velocity = destination - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = Vector3.MoveTowards(transform.position, destination, Time.deltaTime * moveSpeed);

        if (jumping)
        {
            character.Move(velocity, false, true);
        } else
        {
            character.Move(velocity, false, false);
        }

        if (Vector3.Distance(transform.position, destination) <= stoppingDistance)
        {
            // Find a new random destination
            character.Move(Vector3.zero, false, false);
            destination = FindNewDestination();
            velocity = destination - transform.position;
        }
    }

    private Vector3 FindNewDestination()
    {
        //return new Vector3(Random.Range(-18.0f, 18.0f), transform.position.y, Random.Range(2.0f, 10.0f));
        Bounds bounds = groundObject.GetComponent<Renderer>().bounds;
        float minX = bounds.center.x - gameObject.transform.localScale.x * bounds.size.x * 0.5f;
        float maxX = bounds.center.x + gameObject.transform.localScale.x * bounds.size.x * 0.5f;
        float minZ = bounds.center.z - gameObject.transform.localScale.z * bounds.size.z * 0.5f;
        float maxZ = bounds.center.z + gameObject.transform.localScale.z * bounds.size.z * 0.5f;

        return new Vector3(Random.Range(minX, maxX),
                               0,
                               Random.Range(minZ, maxZ));
    }
    /*
    private void LateUpdate()
    {
        transform.LookAt(2 * transform.position - Camera.main.transform.position);
        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
    }
    */
}
