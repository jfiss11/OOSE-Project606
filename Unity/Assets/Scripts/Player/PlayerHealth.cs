using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	//variables
	public int maxHealth = 100;
	public int curHealth = 100;

	public bool dead = false;

	public float healthBarLength;

	// Use this for initialization
	void Start () {
	
		healthBarLength = Screen.width / 2;
	}
	
	// Update is called once per frame
	void Update () {


	}

	void OnGUI(){
		
		GUI.Box(new Rect(0,0,healthBarLength , 20),"");
		if (dead == true) {
			Dead();
		}
	}
	
	public void AdjustCurrentHealth(int h){
		curHealth = h;
		if (curHealth < 0) {
			curHealth = 0;
			dead = true;
		}
		if (curHealth > maxHealth) {
			curHealth = maxHealth;
		}

		healthBarLength = (Screen.width / 2) * (curHealth / (float) maxHealth); 
	}

	void Dead(){
		if (GUI.Button(new Rect(0,0, 100, 50), "Dead")) {
				}
	}
}
