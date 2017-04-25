using UnityEngine;
using System.Collections;

public class SteeringBehaviors : MonoBehaviour 
{
	public static GameObject target;
	static GameObject playerObject = GameObject.Find(target.name);
	Vector3 playerPos = playerObject.transform.position;
	Vector3 maxvelo = new Vector3 (10, 10, 10);
	Vector3 velocity = new Vector3 (0, 0, 0);
	Vector3 dis = new Vector3 (0, 0, 0);
	Vector3 norm = new Vector3 (0, 0, 0);
	Vector3 scale = new Vector3 (0, 0, 0);
	Vector3 force = new Vector3 (0, 0, 0);
	Rigidbody rb;
	// Use this for initialization

	Vector3 Seek()
	{
		dis = playerPos - gameObject.transform.position;
		norm = dis.Normalize();
		scale = norm.Scale(maxvelo);
		force = scale - rb.velocity;
		return force;
	}

	void Start() 
	{
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown("s")) 
		{
			rb.AddForce(Seek());
		}
	}

}