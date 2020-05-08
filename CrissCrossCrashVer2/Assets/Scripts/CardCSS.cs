using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.Events;
using UnityEngine.EventSystems;
public class CardCSS : MonoBehaviour {

    public List<Card> ArchetypeList = new List<Card>();

    public Button cardcellprefab;

    private int u = 0;


    // Use this for initialization
    void Start() {

        foreach (Card card in ArchetypeList)
        {
            SpawnCardCell(card);
        }

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SpawnCardCell(Card c)
    {
        Button cardcell = Instantiate(cardcellprefab, transform);

        cardcell.name = c.code;
        Image artwork = cardcell.transform.Find("Art").GetComponent<Image>();

        artwork.sprite = c.artwork;

        Vector2 pixelSize = new Vector2(artwork.sprite.texture.width, artwork.sprite.texture.height);
        Vector2 pixelPivot = artwork.sprite.pivot;
        Vector2 uiPivot = new Vector2 (pixelPivot.x / pixelSize.x, pixelPivot.y / pixelSize.y);

        artwork.GetComponent<RectTransform>().pivot = uiPivot;
        artwork.GetComponent<RectTransform>().sizeDelta *= c.zoom;

        cardcell.transform.Find("Art").gameObject.tag = "CardButton";//we made a CardButton tag to refer to so that the cursor can differenciate CardButtons from other objects
        cardcell.transform.Find("Art").gameObject.name = c.code; //for some reason, the gloves detect the art and not the pictures holding the art...
                                                                 //fuck it, just rename the pictures. We just need to differenciate the icons from each other.
    }
}
