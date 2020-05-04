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
    private float SpeedScale = 300;
    float hor;
    float ver;

    [SerializeField]
    //private GraphicRaycaster gr;
    //private PointerEventData ped = new PointerEventData(null);
    //private RaycastHit2D rh = new RaycastHit2D();

    // Use this for initialization
    void Start () {
        myrigidbody = transform.GetComponent<Rigidbody2D>();
        //gr = GetComponent<GraphicRaycaster>();
        
    }
	
	// Update is called once per frame
	void Update () {
        if (GloveNumber == 1) {hor = Input.GetAxis("Horizontal"); ver = Input.GetAxis("Vertical");}
        else if (GloveNumber == 2){hor = Input.GetAxis("Horizontal2"); ver = Input.GetAxis("Vertical2");}
        myrigidbody.velocity = new Vector2(hor * SpeedScale, ver * SpeedScale);


        //ped = new PointerEventData(null);
        //ped.position = Camera.main.WorldToScreenPoint(transform.position);
        //List<RaycastResult> results = new List<RaycastResult>();
        //gr.Raycast(ped, results);

        //Debug.Log(ped);
        //Debug.Log(results);
        //Debug.Log(gr);

        //if (results.Count > 0)
       // {
        //    Debug.Log(results[0].gameObject.name);
        //}



    }
}
