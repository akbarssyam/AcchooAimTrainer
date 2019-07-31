using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackAndForth : MonoBehaviour
{
    public float delta = 2.0f;
    [Range(1.0f, 10f)]
    public float speed = 2.0f;

    private Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        Vector3 v = startPos;
        v.x += delta * Mathf.Sin(Time.time * speed);
        transform.position = v;
        */
        transform.Translate(Vector3.left * delta * Mathf.Sin(Time.time * speed) * Time.deltaTime);

    }

    private void LateUpdate()
    {
        transform.LookAt(2 * transform.position - Camera.main.transform.position);
        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
    }
}
