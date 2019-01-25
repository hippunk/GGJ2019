using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindController : MonoBehaviour
{
    public float movementMod = 0.5f;
    public float speedThreshold = 4;
    public Vector3 velocity;
    public WindForce windForce;

    Rigidbody rigidbody;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalAxis = Input.GetAxis("Horizontal");
        float verticalAxis = Input.GetAxis("Vertical");

        rigidbody.AddForce(new Vector3(horizontalAxis, 0, verticalAxis) * movementMod, ForceMode.Impulse);
        rigidbody.velocity = new Vector3(Mathf.Max(Mathf.Min(rigidbody.velocity.x, speedThreshold), -speedThreshold), rigidbody.velocity.y, Mathf.Max(Mathf.Min(rigidbody.velocity.z, speedThreshold), -speedThreshold));
        windForce.force = rigidbody.velocity;
        transform.position = new Vector3(0,0,0); //dirty hack to keep position (will avoid world limit computation issues)
    }
}
