using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointAt : MonoBehaviour {

	public Transform handleHand;
    public Transform topHand;
    public Transform centerCameraTarget;
    public float playerHeight;
    private Vector3 previousPosition;
    public float stickForce;
    public Vector3 stickDirection;

	// Use this for initialization
	void Start () {
		
	}
	
    public void setHeight()
    {
        playerHeight = centerCameraTarget.transform.position.y;
        transform.localScale = new Vector3(playerHeight, playerHeight, playerHeight);
    }

    public void getSpeed()
    {
        Vector3 currentPosition = transform.TransformPoint(0.0f, 0.054f, 0.954f);
        stickForce = Vector3.Distance(currentPosition, previousPosition);
        stickDirection = previousPosition - currentPosition;
        Vector3.Normalize(stickDirection);
        previousPosition = transform.TransformPoint(0.0f, 0.054f, 0.954f);

    }

    // Update is called once per frame
    void Update () {

        if (OVRInput.Get(OVRInput.RawButton.B))
        {
            setHeight();
        }

        float doubleHands = OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger);
        if (doubleHands > 0.5)
        {
            Vector3 touchControllerUp = topHand.transform.up;

            transform.LookAt(handleHand, touchControllerUp);
        }
        else
        {
            transform.localEulerAngles = new Vector3(0f, 0f, 0f);
        }
        getSpeed();
    }
}
