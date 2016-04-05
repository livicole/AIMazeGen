using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	public static List<Transform> listOfMice = new List<Transform>();
	public static List<Transform> listOfCats = new List<Transform>();

	public Transform catPrefab;
	public Transform mousePrefab;

	void Start(){
		listOfCats.Clear();
		listOfMice.Clear();
	}

	void Update(){
		Ray mouseRay = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit mouseRayInfo = new RaycastHit ();

		if (Input.GetMouseButtonDown (0) && Physics.Raycast (mouseRay, out mouseRayInfo, 1000f)) {
			Transform newCat = (Transform)Instantiate (catPrefab, mouseRayInfo.point + (new Vector3(0f, .5f, 0f)), Quaternion.identity);
			listOfCats.Add (newCat);
		}

		if (Input.GetMouseButtonDown (1) && Physics.Raycast (mouseRay, out mouseRayInfo, 1000f)) {
			Transform newMouse = (Transform)Instantiate (mousePrefab, mouseRayInfo.point + (new Vector3(0f, .5f, 0f)), Quaternion.identity);
			listOfMice.Add (newMouse);
		}
	}

}
