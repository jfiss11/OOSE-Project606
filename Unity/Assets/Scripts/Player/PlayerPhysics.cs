using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider))]

// Will handle collisions 
public class PlayerPhysics : MonoBehaviour {

	public LayerMask collisionMask;

	private BoxCollider collider;
	private Vector3 s; // s = size
	private Vector3 c; // c = centre

	// to create a tiny bit of space between player and collider, to avoid the ray going through the ground
	private float skin = .005f;

	[HideInInspector]
	public bool grounded;
	[HideInInspector]
	public bool movementStopped;

	Ray ray;
	RaycastHit hit;

	void Start(){
		collider = GetComponent<BoxCollider>();
		s = collider.size;
		c = collider.center;
	}


	public void Move(Vector2 moveAmount){
		float deltaY = moveAmount.y;
		float deltaX = moveAmount.x;
		Vector2 p = transform.position; //p = player

		//assume player is not on the ground
		grounded = false;

		//Raycasting downwards to see if there is any ground below player, so p stops
		for (int i = 0; i<3; i++){
			float dir = Mathf.Sign(deltaY);
			float x = (p.x + c.x - s.x/2) + s.x/2 * i; // Left, centre and then rightmost point of collider
			float y = p.y + c.y + s.y/2 * dir; //buttom of collider

			ray = new Ray(new Vector2(x,y), new Vector2(0, dir));
			Debug.DrawRay(ray.origin, ray.direction);

			// info about which other collider the ray hit
			if(Physics.Raycast(ray, out hit, Mathf.Abs(deltaY) + skin, collisionMask)){
				// Get distance between player and ground
				float dst = Vector3.Distance(ray.origin, hit.point);

				// stop player's downwards movement after coming within skin width of a collider
				if (dst > skin){
					deltaY = dst * dir - skin * dir;
				}
				else{
					deltaY = 0;
				}
				grounded = true;
				break;
			}
		}


		
		//Raycasting downwards to see if there is any left or right collisions to the player, so p stops

		movementStopped = false;

		for (int i = 0; i<3; i++){
			float dir = Mathf.Sign(deltaX);
			float x = p.x + c.x + s.y/2 * dir; 
			float y = p.y + c.y - s.y/2 + s.y/2 * i; 
			
			ray = new Ray(new Vector2(x,y), new Vector2(dir, 0));
			Debug.DrawRay(ray.origin, ray.direction);
			
			// info about which other collider the ray hit
			if(Physics.Raycast(ray, out hit, Mathf.Abs(deltaX) + skin, collisionMask)){
				// Get distance between player and ground
				float dst = Vector3.Distance(ray.origin, hit.point);
				
				// stop player's downwards movement after coming within skin width of a collider
				if (dst > skin){
					deltaX = dst * dir - skin * dir;
				}
				else{
					deltaX = 0;
				}
				movementStopped = true;
				break;
			}
		}

			Vector2 finalTransform = new Vector2(deltaX, deltaY);
		transform.Translate(finalTransform);
	}

}
