using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "New Card", menuName = "Card")]
public class Card : ScriptableObject {

    public string name;
    public string status;
    public Sprite artwork;
    public string element;
    public string Description;
    public string code;

    public float zoom;
}
