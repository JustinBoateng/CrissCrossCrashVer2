using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1Movement : MonoBehaviour {

    private Rigidbody2D myrigidbody = new Rigidbody2D();

    [SerializeField]
    private float SpeedScale = 300;
    float hor;
    float ver;

    // Use this for initialization
    void Start () {
        myrigidbody = transform.GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        hor = Input.GetAxis("Horizontal");
        ver = Input.GetAxis("Vertical");

        myrigidbody.velocity = new Vector2(hor * SpeedScale, ver * SpeedScale);

        Debug.Log("Input: " + hor * SpeedScale + " , " + ver * SpeedScale);
    }
}
