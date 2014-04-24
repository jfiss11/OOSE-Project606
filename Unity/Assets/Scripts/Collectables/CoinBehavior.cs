using UnityEngine;
using System.Collections;

public class CoinBehavior : MonoBehaviour {


	void Start(){

		print("wuhu");
	}

	void OnTriggerEnter(Collider collider){


		switch(collider.gameObject.name){

			//to destroy coin
		case "Player(Clone)":

			CoinController.coinCount++;
			Destroy(this.gameObject);
			print("wuhu");

			break;
		}
	}
}
