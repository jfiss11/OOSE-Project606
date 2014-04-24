using UnityEngine;
using System.Collections;

public class GameCamera : MonoBehaviour {

	private Transform target;
	public float trackSpeed = 10;



	public void SetTarget(Transform t){
		target = t;
	}

	void LateUpdate(){
		if(target){
			// start at cameras current x position
			float x = IncrementTowards(transform.position.x, target.position.x, trackSpeed);
			float y = IncrementTowards(transform.position.y, target.position.y, trackSpeed);
			transform.position = new Vector3(x,y,transform.position.z);
		}
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
