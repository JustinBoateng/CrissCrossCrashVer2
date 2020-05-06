using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GloveMovement : MonoBehaviour {

    private Rigidbody2D myrigidbody = new Rigidbody2D();

    [SerializeField]
    public int GloveNumber;

    [SerializeField]
    private float SpeedScale = 30;
    float hor;
    float ver;


    private GraphicRaycaster gr;
    private PointerEventData ped = new PointerEventData(null);

    // Use this for initialization
    void Start () {
        myrigidbody = transform.GetComponent<Rigidbody2D>();
        gr = GetComponentInParent<GraphicRaycaster>();
    }
	
	// Update is called once per frame
	void Update () {
        if (GloveNumber == 1) {hor = Input.GetAxis("Horizontal"); ver = Input.GetAxis("Vertical");}
        else if (GloveNumber == 2){hor = Input.GetAxis("Horizontal2"); ver = Input.GetAxis("Vertical2");}
        myrigidbody.velocity = new Vector2(hor * SpeedScale, ver * SpeedScale);


        ped.position = Camera.main.WorldToScreenPoint(transform.position);
        List<RaycastResult> results = new List<RaycastResult>();
        gr.Raycast(ped, results);

        if (results.Count > 0)
        {
            Debug.Log("Detection");
            Debug.Log("Name: " + results[0].gameObject.name + " Tag:  " + results[0].gameObject.tag);
        }

        //so now we can detect the name of the cards we hover

        //if (Input.GetButton("Submit") && results[0].gameObject.tag == "CardButton" ) //if the "Submit" button is clicked while the cursor is over a card button
        //{
        //    DisplayHUD.CardArrayFill(results[0].gameObject.name, GloveNumber); // run CardArrayFill using the Button's name (which is actually a reference to the code in the Card Encyclopedia to look for)
        //}

        //DisplayHUD will be the thing that contains the two CardDisplays, 
        //and THAT's what you'll refer to when calling DisplayFill, giving a string(Code) and an int (Glove Number)


    }
}
