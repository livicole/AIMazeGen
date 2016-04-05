using UnityEngine;
using System.Collections;

public class MazeMaker : MonoBehaviour
{

	int counter = 0;
	float moveAmount = 1.5f;
	public Transform[] wallPrefabs;
	public Transform pathMakerPrefab;

	// Update is called once per frame
	void Update ()
	{
		int randomArrayChoose = Random.Range (0, 2);
		int randomPosition = Random.Range (0, 3);


		if (counter < 15) {
			float randomNumber = Random.Range (0.0f, 1f);

			if (randomNumber < 0.25f) {
				Debug.Log ("turning +");
				transform.Rotate (0f, 90f, 0f);
				AvoidWall ();
				Instantiate (wallPrefabs [randomArrayChoose], transform.position, wallPrefabs [randomArrayChoose].rotation);
				counter++;
			} else if (randomNumber >= 0.25f && randomNumber <= 0.5f) {
				Debug.Log ("turning -");
				transform.Rotate (0f, -90f, 0f);
				AvoidWall ();
				Instantiate (wallPrefabs [randomArrayChoose], transform.position, wallPrefabs [randomArrayChoose].rotation);
				counter++;
			} else if (randomNumber >= 0.5f && randomNumber <= 1f) {
				Debug.Log ("skipping wall");
				AvoidWall ();
			}

			//AvoidWall ();
			//Instantiate (wallPrefabs [randomArrayChoose], transform.position, wallPrefabs [randomArrayChoose].rotation);
			transform.localPosition += transform.forward * moveAmount;
			Debug.DrawRay (transform.position, transform.forward, Color.yellow);
		} else {
			Destroy (this.gameObject);
		}
	}

	void AvoidWall ()
	{
		
		Ray wallRay = new Ray (transform.position, transform.forward);
		if (Physics.SphereCast (wallRay, 0.25f, 2f)) {
			Debug.Log ("I see a wall");
			int direction = Random.Range (0, 2);
			switch (direction) {
			case 0:
				transform.Rotate (0f, 90f, 0f);
				Debug.Log ("turning from wall +");
				wallRay = new Ray (transform.position, transform.forward);
				break;

			case 1:
				transform.Rotate (0f, -90f, 0f);
				Debug.Log ("turning from wall -");
				wallRay = new Ray (transform.position, transform.forward);
				break;
			} 
		}
	}
}

