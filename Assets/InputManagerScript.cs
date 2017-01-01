using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InputManagerScript : MonoBehaviour {


    private Vector3 offset;
    private bool mouseDown;
    private bool objectHit;
    private GameObject emojiObj;
    private float pos_offset;
	private	Vector3 originalSecond;

    // Use this for initialization
    void Start () {
        mouseDown = false;
        pos_offset = -0.1f;
	}
	
	// Update is called once per frame
	void Update () {


		/*Mouse input*/
//        if (Input.GetMouseButton(0))
//        {
//            RaycastHit2D hit;
//            Vector3 mousePoint;
//            mousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
//            hit = Physics2D.Raycast(new Vector2(mousePoint.x, mousePoint.y), Vector2.zero);
//
//
//            if(!objectHit && hit)
//            {
//                emojiObj = hit.collider.gameObject;
//                offset = hit.collider.transform.position - new Vector3(mousePoint.x, mousePoint.y, 0.0f);
//                objectHit = true;
//                pos_offset -= 0.1f;
//                Debug.Log(pos_offset);
//            }
//
//            if(objectHit)
//            { 
//                //Debug.Log(offset);
//                emojiObj.transform.position = new Vector3(mousePoint.x, mousePoint.y, pos_offset) + new Vector3(offset.x,offset.y,500f);
//                //Debug.Log("Mouse point: " + new Vector3(mousePoint.x, mousePoint.y, pos_offset));
//                //Debug.Log("Offset " + offset);
//                Debug.Log("Result" + emojiObj.transform.position);
//            }
//        }
//        if(Input.GetMouseButtonUp(0))
//        {
//            objectHit = false;
//        }
		/*Mouse input end*/
			
		/*Touch input*/
		if (Input.touchCount > 0) 
		{
			Touch first = Input.GetTouch (0);
			RaycastHit2D hit;
			Vector3 touchPoint;
			touchPoint = Camera.main.ScreenToWorldPoint(first.position);
			hit = Physics2D.Raycast(new Vector2(touchPoint.x, touchPoint.y), Vector2.zero);

			if (first.phase == TouchPhase.Began) { // touch down
				
				if(!objectHit && hit)
				{
					emojiObj = hit.collider.gameObject;
					offset = hit.collider.transform.position - new Vector3(touchPoint.x, touchPoint.y, 0.0f);
					objectHit = true;
					pos_offset -= 0.1f;
					Debug.Log(pos_offset);
				}

			} else if (first.phase == TouchPhase.Moved) {// touch drag
				
				if(objectHit)
				{ 
					//Debug.Log(offset);
					emojiObj.transform.position = new Vector3(touchPoint.x, touchPoint.y, pos_offset) + new Vector3(offset.x,offset.y,500f);
					//Debug.Log("Mouse point: " + new Vector3(mousePoint.x, mousePoint.y, pos_offset));
					//Debug.Log("Offset " + offset);
					Debug.Log("Result" + emojiObj.transform.position);
				}

			} else if (first.phase == TouchPhase.Ended) {// touch ended
				objectHit = false;
			}


			if (Input.touchCount > 1 && objectHit) { // second touch
				Touch second = Input.GetTouch (1);
				Vector3 second_touchPoint;
				second_touchPoint = Camera.main.ScreenToWorldPoint(second.position);
				new Vector2 (second_touchPoint.x, second_touchPoint.y);


				if (second.phase == TouchPhase.Began) {
					originalSecond = new Vector3 (second_touchPoint.x, second_touchPoint.y, 0.0f) -
					new Vector3 (emojiObj.transform.position.x, emojiObj.transform.position.y, 0.0f);
				} else if (second.phase == TouchPhase.Moved) {
					Vector3 newPos = new Vector3(second_touchPoint.x, second_touchPoint.y,0.0f)-
						new Vector3 (emojiObj.transform.position.x, emojiObj.transform.position.y, 0.0f);

					float angle = Vector3.Angle(originalSecond , newPos);
					if (Vector3.Cross (originalSecond, newPos).z < 0) {
						angle *= -1;
					}
					emojiObj.transform.Rotate (0, 0, angle);


					float scale = newPos.magnitude / originalSecond.magnitude; 
					Vector3 tempScale = emojiObj.transform.localScale;
					tempScale.x *= scale;
					tempScale.y *= scale;
					emojiObj.transform.localScale = tempScale;

					originalSecond = newPos;



				}
				//Vector3.Angle(

			}
		}
		/*Touch input end*/
    }
}
