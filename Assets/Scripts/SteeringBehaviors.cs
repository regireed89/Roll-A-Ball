using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SteeringBehaviors : MonoBehaviour 
{
	public GameObject target;
	Vector3 playerPos;
	public int maxvelo = 10;
	Vector3 dis = new Vector3 (0, 0, 0);
	Vector3 norm = new Vector3 (0, 0, 0);
	Vector3 scale = new Vector3 (0, 0, 0);
	Vector3 force = new Vector3 (0, 0, 0);
	Vector3 velocity = new Vector3 (0, 0, 0);
	Vector3 acceleration = new Vector3 (0, 0, 0);
	Vector3 heading = new Vector3 (0, 0, 0);
	Rigidbody rb;
	// Use this for initialization

	void Start() 
	{
		
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		playerPos = target.transform.position;
		if (Input.GetKey ("space")) {
			dis = playerPos - gameObject.transform.position;
			norm = dis.normalized;
			scale = norm * maxvelo;
			force = scale - velocity;
			rb.AddForce (force, ForceMode.Force);
		} 

		else {
			dis = gameObject.transform.position - playerPos;
			norm = dis.normalized;
			scale = norm * maxvelo;
			force = scale - velocity;
			rb.AddForce (force, ForceMode.Force);
		}

		acceleration = force;
		heading = velocity.normalized;
		velocity = heading * velocity.magnitude + acceleration * Time.deltaTime;
		if (velocity.magnitude > maxvelo) 
		{
			velocity = velocity.normalized * maxvelo;
		}
		gameObject.transform.position = gameObject.transform.position + velocity * Time.deltaTime;
	}

}