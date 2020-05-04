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
            Debug.Log(results[0].gameObject.name);
        }


    }
}

/*
//Attach this script to your Canvas GameObject.
//Also attach a GraphicsRaycaster component to your canvas by clicking the Add Component button in the Inspector window.
//Also make sure you have an EventSystem in your hierarchy.

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class GraphicRaycasterRaycasterExample : MonoBehaviour
{
    GraphicRaycaster m_Raycaster;
    PointerEventData m_PointerEventData;
    EventSystem m_EventSystem;

    void Start()
    {
        //Fetch the Raycaster from the GameObject (the Canvas)
        m_Raycaster = GetComponent<GraphicRaycaster>();
        //Fetch the Event System from the Scene
        m_EventSystem = GetComponent<EventSystem>();
    }

    void Update()
    {
        //Check if the left Mouse button is clicked
        if (Input.GetKey(KeyCode.Mouse0))
        {
            //Set up the new Pointer Event
            m_PointerEventData = new PointerEventData(m_EventSystem);
            //Set the Pointer Event Position to that of the mouse position
            m_PointerEventData.position = Input.mousePosition;

            //Create a list of Raycast Results
            List<RaycastResult> results = new List<RaycastResult>();

            //Raycast using the Graphics Raycaster and mouse click position
            m_Raycaster.Raycast(m_PointerEventData, results);

            //For every result returned, output the name of the GameObject on the Canvas hit by the Ray
            foreach (RaycastResult result in results)
            {
                Debug.Log("Hit " + result.gameObject.name);
            }
        }
    }
}*/