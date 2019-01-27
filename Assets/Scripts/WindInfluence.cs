using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindInfluence : MonoBehaviour
{
    public WindForce windForce;
    Rigidbody rigidbody;
    public bool fastDrop = false;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && fastDrop == false)
        {
            fastDrop = true;
            rigidbody.AddForce(1f*Vector3.down, ForceMode.Impulse);
            HouseFactory.GetInstance().InitGenerateWithDelay(0.5f);
        }

        if(fastDrop == false)
            rigidbody.velocity = new Vector3(windForce.force.x*-1, windForce.force.y, windForce.force.z * -1);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (this.enabled == true && fastDrop == false)
        {
            this.enabled = false;
            rigidbody.velocity = Vector3.zero;
            HouseFactory.GetInstance().InitGenerateWithDelay(2f);
        }
    }
}
