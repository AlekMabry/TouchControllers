using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickCollisions : MonoBehaviour {

    public float stickVelocity;
    public Vector3 stickDirection;

    // Use this for initialization
    void Start () {
		
	}

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Puck")
        {
            //Destroy(collision.gameObject);
            collision.rigidbody.AddForce((stickVelocity*stickDirection*180), ForceMode.Impulse);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
