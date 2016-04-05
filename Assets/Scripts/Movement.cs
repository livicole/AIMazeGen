using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	//public Vector3[] turnDirection = new Vector3[2];
	public float catSpeed = 10f;
	public float mouseSpeed = 8f;

	void FixedUpdate(){
		if (this.gameObject.tag == "Cat") {
			GetComponent<Rigidbody> ().velocity = (transform.forward * catSpeed) + Physics.gravity;
		} else if (this.gameObject.tag == "Mouse") {
			GetComponent<Rigidbody> ().velocity = (transform.forward * mouseSpeed) + Physics.gravity;
		}
	
		Ray moveRay = new Ray (transform.position, transform.forward);

		if (Physics.SphereCast (moveRay, 0.15f, 0.5f)) {

			//transform.Rotate (0f, 10f, 0f);
//			int randomArrayChoose = Random.Range (0, 2);
//			transform.Rotate (turnDirection [randomArrayChoose]);
			
			int direction = Random.Range (0, 2);
			switch (direction) {
			case 0:
				transform.Rotate (0f, 90f, 0f);
				break;

			case 1:
				transform.Rotate (0f, -90f, 0f);
				break;
			}
		}
	}
}
