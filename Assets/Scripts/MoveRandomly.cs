using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRandomly : MonoBehaviour
{
    [SerializeField]
    [Range(1.0f, 10f)]
    private float moveSpeed = 5.0f;
    
    private Vector3 destination;

    // Start is called before the first frame update
    void Start()
    {
        // Find a new random destination
        destination = FindNewDestination();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, destination, Time.deltaTime * moveSpeed);

        if (transform.position == destination)
        {
            // Find a new random destination
            destination = FindNewDestination();
        }
    }

    private Vector3 FindNewDestination()
    {
        return new Vector3(Random.Range(-10.0f, 10.0f), 0, Random.Range(1.0f, 10.0f));
    }

    private void LateUpdate()
    {
        transform.LookAt(2 * transform.position - Camera.main.transform.position);
        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
    }
}
