using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class GrapplingGun : MonoBehaviour
{

	private LineRenderer lr;
	private Vector3 grapplePoint;
	private float maxDistance = 100f;
	private SpringJoint joint;

	public LayerMask whatIsGrappleable;
	public SteamVR_Action_Boolean grabPinch;
	public SteamVR_Input_Sources thisHand;
	public GameObject player, tip;

	void Awake()
	{
		lr = GetComponent<LineRenderer>();
	}

	void Update()
	{
		lr.SetColors(Color.black, Color.black);
		lr.SetPosition(0, transform.position);
		lr.SetPosition(1, transform.position + transform.forward * 50f);
	
		if (grabPinch.GetStateDown(thisHand))
		{
			StartGrapple();
		}
		else if (grabPinch.GetStateUp(thisHand))
		{
			StopGrapple();
		}
	}

	void LateUpdate()
	{
		DrawRope();
	}

	void StartGrapple()
	{
		RaycastHit hit;
		Debug.DrawRay(transform.position, transform.forward, Color.green);
		if (Physics.Raycast(transform.position, transform.forward, out hit, maxDistance, whatIsGrappleable))
		{
			grapplePoint = hit.point;
			joint = player.gameObject.AddComponent<SpringJoint>();
			joint.autoConfigureConnectedAnchor = false;
			joint.connectedAnchor = grapplePoint;

			float distanceFromPoint = Vector3.Distance(player.transform.position, grapplePoint);

			//The distance grapple will try to keep from grapple point. 
			joint.maxDistance = distanceFromPoint * 0.2f;
			joint.minDistance = distanceFromPoint * 0.05f;

			//Adjust these values to fit your game.
			joint.spring = 2f;
			joint.damper = 5f;
			joint.massScale = 5f;

			lr.positionCount = 2;
			currentGrapplePosition = transform.position;
		}
	}

	void StopGrapple()
	{
		//lr.positionCount = 0;
		Destroy(joint);
	}

	private Vector3 currentGrapplePosition;

	void DrawRope()
	{
		//If not grappling, don't draw rope
		if (!joint) return;
		lr.SetColors(Color.green, Color.green);

		currentGrapplePosition = Vector3.Lerp(currentGrapplePosition, grapplePoint, Time.deltaTime * 8f);

		lr.SetPosition(0, transform.position);
		lr.SetPosition(1, currentGrapplePosition);
	}

	public bool IsGrappling()
	{
		return joint != null;
	}

	public Vector3 GetGrapplePoint()
	{
		return grapplePoint;
	}

}
