using UnityEngine;
using System.Collections;

public class PlayerPhysics2 : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Debug.Log (rigidbody.velocity);
	}


	public void Move(Vector2 moveAmount)
	{
		rigidbody.AddForce(new Vector3(moveAmount.x, moveAmount.y, 0));
	}

	public void Jump()
	{
		
		rigidbody.AddForce (Vector3.up, ForceMode.Impulse);
	}
}
