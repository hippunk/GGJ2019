using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindInfluence : MonoBehaviour
{
    public WindForce windForce;
    Rigidbody rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody.velocity = new Vector3(windForce.force.x*-1, windForce.force.y, windForce.force.z * -1);
    }

    public void OnCollisionEnter(Collision collision)
    {
        this.enabled = false;
    }
}
