using UnityEngine;
using System.Collections;

public class CatMove : MonoBehaviour
{

	public Transform mouse;
	AudioSource soundManager;
	public AudioClip dinoLOS;
	public AudioClip dinoEat;
	public AudioClip manScream;

	public Transform bloodPrefab;


	//public static bool soundPlayed;
	float timeSeen;

	void Start ()
	{
		soundManager = GameObject.Find ("SoundManager").GetComponent<AudioSource> ();
	}

	void FixedUpdate ()
	{

		foreach (Transform mouseClone in GameManager.listOfMice) {

			if (mouseClone) {
			
				Vector3 directionToMouse = (mouseClone.position - transform.position);
				Vector3 forward = transform.forward;
				float angle = Vector3.Angle (directionToMouse, forward);
				//Debug.DrawRay (transform.position, directionToMouse, Color.yellow);

				if (angle < 90f) {
					Ray catRay = new Ray (transform.position, directionToMouse);
					RaycastHit catRayHitInfo = new RaycastHit ();

					if (Physics.Raycast (catRay, out catRayHitInfo, Vector3.Distance (transform.position, mouseClone.position)) && catRayHitInfo.collider.tag == "Mouse") {
						if (catRayHitInfo.distance <= 1.5f) {
							Instantiate (bloodPrefab, mouseClone.position, bloodPrefab.rotation);
							Destroy (mouseClone.gameObject);
							soundManager.PlayOneShot (dinoEat, 1f);
							soundManager.PlayOneShot (manScream, 1f);
						} else if (catRayHitInfo.distance <= 7f) {
							GetComponent<Rigidbody> ().AddForce (directionToMouse.normalized * 900f);
							if (Time.time > timeSeen + .2f) {
								soundManager.PlayOneShot (dinoLOS, 1f);
								timeSeen = Time.time;
							}
						}
					}
				}
			}
		}
	}
}
