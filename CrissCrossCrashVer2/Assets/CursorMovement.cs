using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorMovement : MonoBehaviour {

    [SerializeField]
    public GameObject[] Cursors = new GameObject[2];
    private Rigidbody2D[] cursorrigids = new Rigidbody2D[2];

    private float SpeedScale = 300;

    // Use this for initialization
    void Start()
    {


        cursorrigids[0] = Cursors[0].transform.GetComponent<Rigidbody2D>();
        cursorrigids[1] = Cursors[1].transform.GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        int hor0 = (int)Input.GetAxis("Horizontal");
        int ver0 = (int)Input.GetAxis("Vertical");

        cursorrigids[0].velocity = new Vector2(hor0 * SpeedScale, ver0 * SpeedScale);

        Debug.Log("Input: " + hor0 * SpeedScale + " , " + ver0 * SpeedScale);
    }
}
