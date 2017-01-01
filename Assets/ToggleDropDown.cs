using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ToggleDropDown : MonoBehaviour {


    public GameObject grid;


    private bool gridActive;
    private bool gridDown;


	// Use this for initialization
	void Start () {
        gridActive = true;

        gridDown = false;   
	}
	
	// Update is called once per frame
	void Update () {

        
	}

    public void toggleGrid()
    {
        if(gridActive)
        {
            grid.SetActive(false);
        }
        else
        {
            grid.SetActive(true);
        }
        gridActive = !gridActive;
    }

//    public void toggleGrid()
//    {
//        if(gridDown)
//        {
//            pullUp();
//        }
//        else
//        {
//            dropDown();
//        }
//    }

    private void dropDown()
    {
        grid.GetComponent<Animator>().SetTrigger("dropDown");
        gridDown = true;
    }

    private void pullUp()
    {
        grid.GetComponent<Animator>().SetTrigger("pullUp");
        gridDown = false;
    }


}
