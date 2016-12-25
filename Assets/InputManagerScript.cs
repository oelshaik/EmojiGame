using UnityEngine;
using System.Collections;

public class InputManagerScript : MonoBehaviour {


    private Vector3 offset;
    private bool mouseDown;
    private bool objectHit;
    private GameObject emojiObj;
    private float pos_offset;

    // Use this for initialization
    void Start () {
        mouseDown = false;
        pos_offset = -0.1f;
	}
	
	// Update is called once per frame
	void Update () {


        if (Input.GetMouseButton(0))
        {
            RaycastHit2D hit;
            Vector3 mousePoint;
            mousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            hit = Physics2D.Raycast(new Vector2(mousePoint.x, mousePoint.y), Vector2.zero);


            if(!objectHit && hit)
            {
                emojiObj = hit.collider.gameObject;
                offset = hit.collider.transform.position - new Vector3(mousePoint.x, mousePoint.y, 0.0f);
                objectHit = true;
                pos_offset -= 0.1f;
                Debug.Log(pos_offset);
            }

            if(objectHit)
            { 
                //Debug.Log(offset);
                emojiObj.transform.position = new Vector3(mousePoint.x, mousePoint.y, pos_offset) + offset;
                Debug.Log(emojiObj.transform.position);
            }
        }
        if(Input.GetMouseButtonUp(0))
        {
            objectHit = false;
        }

    }
}
