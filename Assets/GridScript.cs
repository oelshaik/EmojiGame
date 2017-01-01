using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GridScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//GetComponent<RectTransform> ().sizeDelta;
		//GetComponent<GridLayoutGroup> ().cellSize;

		//float w = GetComponent<RectTransform> ().rect.width;

		//GetComponent<GridLayoutGroup> ().cellSize = new Vector2 (w / 7.0f, w / 7.0f);
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (GetComponent<RectTransform> ().rect.width);
		float w = GetComponent<RectTransform> ().rect.width;
		float cellRoom = w / 7.0f; // change to public variable (7 emojis per row)
		float cellMarg = cellRoom/10f;

		GetComponent<GridLayoutGroup> ().cellSize = new Vector2 (cellRoom - cellMarg,cellRoom - cellMarg);
		GetComponent<GridLayoutGroup> ().spacing = new Vector2 (cellMarg,cellMarg);
		GetComponent<GridLayoutGroup> ().padding.left = (int)cellMarg / 2;
	}
}
