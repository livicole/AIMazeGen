using UnityEngine;
using System.Collections;

public class MouseMove : MonoBehaviour
{

	public Transform cat;
	AudioSource soundManager;
	public AudioClip losScream;

	float timeSeen;

	void Start(){
		soundManager = GameObject.Find ("SoundManager").GetComponent<AudioSource>();
	}

	void FixedUpdate ()	{

		foreach (Transform catClone in GameManager.listOfCats) {
			
			Vector3 directionToCat = (catClone.position - transform.position);
			Vector3 forward = transform.forward;
			float angle = Vector3.Angle (directionToCat, forward);

			if (angle < 180f) {
				Ray mouseRay = new Ray (transform.position, directionToCat);
				RaycastHit mouseRayHitInfo = new RaycastHit ();

				if (Physics.Raycast (mouseRay, out mouseRayHitInfo, 8f) && mouseRayHitInfo.collider.tag == "Cat" && mouseRayHitInfo.distance <= 7f) {
					GetComponent<Rigidbody> ().AddForce (-directionToCat.normalized * 900f);
					if (Time.time > timeSeen + .8f) {
						soundManager.PlayOneShot (losScream, 1f);
						timeSeen = Time.time;
					}
				}
			}
		}
	}
}
