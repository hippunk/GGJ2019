using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindController : MonoBehaviour
{
    public float movementMod = 0.5f;
    public float speedThreshold = 4;
    public float maxDownSpeed = 10;
    public Vector3 velocity;
    public WindForce windForce;
    Rigidbody rigidbody;
    public float angle;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalAxis = Input.GetAxis("Horizontal");
        float verticalAxis = Input.GetAxis("Vertical");
        
        Vector3 modVelocity = new Vector3(horizontalAxis, 0, verticalAxis) * movementMod;
        rigidbody.AddForce(modVelocity, ForceMode.Impulse);
        angle = Mathf.Atan2(rigidbody.velocity.z, rigidbody.velocity.x);

        float abscos = Mathf.Abs(Mathf.Cos(angle));
        float abssin = Mathf.Abs(Mathf.Sin(angle));

        //Clamp speed with circular axis to avoid diagonal movement advantage
        rigidbody.velocity = new Vector3(
            Mathf.Max(Mathf.Min(rigidbody.velocity.x, speedThreshold*abscos), -speedThreshold * abscos),
            Mathf.Max(Mathf.Min(rigidbody.velocity.y, maxDownSpeed), -maxDownSpeed), 
            Mathf.Max(Mathf.Min(rigidbody.velocity.z, speedThreshold * abssin), -speedThreshold * abssin));

        /*rigidbody.velocity = new Vector3(Mathf.Max(Mathf.Min(rigidbody.velocity.x, speedThreshold), -speedThreshold ), 
         * Mathf.Max(Mathf.Min(rigidbody.velocity.y, maxDownSpeed), -maxDownSpeed), 
         * Mathf.Max(Mathf.Min(rigidbody.velocity.z, speedThreshold), -speedThreshold ));
        
         
         */
        windForce.force = rigidbody.velocity;
        windForce.normalized = new Vector3(windForce.force.x,0,windForce.force.z).normalized;
        transform.position = new Vector3(0,0,0); //dirty hack to keep position (will avoid world limit computation issues)
    }
}
