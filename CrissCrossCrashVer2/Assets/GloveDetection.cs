using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class GloveDetection : MonoBehaviour {

    private GraphicRaycaster gr1;
    private PointerEventData ped1 = new PointerEventData(null);
 
    void Start () {
 
        gr1 = GetComponentInParent<GraphicRaycaster>();
        //make sure that the gloves have GloveMovement, GloveDetection, AND a Canvas script attached
        //I suppose that the gloves need a Canvas and not their very own GR themselves to use their parent's GR.
        //This works because the Cursor's IMMEDIATE parent is the Canvas. I dont know if any grandparent shenanigans can affect it, but dont tempt fate.
    }

    // Update is called once per frame
    void Update () {

        ped1.position = Camera.main.WorldToScreenPoint(transform.position);
        List<RaycastResult> results = new List<RaycastResult>();
        gr1.Raycast(ped1, results);

        if (results.Count > 0)
        {
            Debug.Log("Detection");
            Debug.Log("Name: " + results[0].gameObject.name + " Tag:  " + results[0].gameObject.tag);
        }

        //so now we can detect the name of the cards we hover

        //if (Input.GetButton("Submit") && results[0].gameObject.tag == "CardButton" ) //if the "Submit" button is clicked while the cursor is over a card button
        //{
        //    CardDisplay.CardArrayFill(results[0].gameObject.name); // run CardArrayFill using the Button's name (which is actually a reference to the code in the Card Encyclopedia to look for)
        //}

    }
}
