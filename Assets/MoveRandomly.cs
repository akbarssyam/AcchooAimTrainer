using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRandomly : MonoBehaviour
{
    [SerializeField]
    [Range(1.0f, 10f)]
    private float moveSpeed = 5.0f;

    [SerializeField]
    [Range(5.0f, 10f)]
    private float fieldArea = 8.0f;

    private bool isMoving = false;
    private Vector3 destination;

    // Start is called before the first frame update
    void Start()
    {
        // Find a new random destination
        destination = new Vector3(Random.Range(-fieldArea, fieldArea), 0, Random.Range(-fieldArea, fieldArea));
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, destination, Time.deltaTime * moveSpeed);

        if (transform.position == destination)
        {
            // Find a new random destination
            destination = new Vector3(Random.Range(-fieldArea, fieldArea), 0, Random.Range(-fieldArea, fieldArea));
        }
    }

    private void LateUpdate()
    {
        transform.LookAt(2 * transform.position - Camera.main.transform.position);
        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
    }
}
