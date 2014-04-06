using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerPhysics))]

public class PlayerController : MonoBehaviour {

	//Player handeling
	public float gravity = 20;
	public float speed = 8;
	public float acceleration = 30; 
	public float jumpHeight = 12;

	private float currentSpeed;
	private float targetSpeed;
	private Vector2 amountToMove;

	private PlayerPhysics playerPhysics;

	// Use this for initialization
	void Start () {
	
		playerPhysics = GetComponent<PlayerPhysics>();
	}
	
	// Update is called once per frame
	void Update () {
	
		targetSpeed = Input.GetAxisRaw("Horizontal") * speed;
		currentSpeed = IncrementTowards(currentSpeed, targetSpeed, acceleration);

		if(playerPhysics.grounded){
			//if player is on the ground, then jump. Jump is automatically set to the space bar.
			amountToMove.y = 0;
			if(Input.GetButtonDown("Jump")){
				amountToMove.y = jumpHeight;

			}
		}

		amountToMove.x = currentSpeed;
		amountToMove.y -= gravity * Time.deltaTime;
		playerPhysics.Move(amountToMove * Time.deltaTime);

	}

	//Increase n towards target by speed
	private float IncrementTowards(float n, float target, float a){
		if (n == target){
			return n;
		}
		else{
			float dir = Mathf.Sign(target - n); // Must n be increased or decreased to get closer to target
			n += a * Time.deltaTime * dir;

			// if n has now passed target then return target, orherwise return n
			if(dir == Mathf.Sign(target-n)){
				return n;
			}
			else{
				return target;
			}
		}
	}
}
