using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerSwitcher : MonoBehaviour
{
    public GameObject slime;
    public GameObject frontLayer;
    public GameObject backLayer;
    public GameObject midLayer;
    public int startingLayer;
    private int startLayRecord;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        startLayRecord = startingLayer;
        if (Input.GetAxis("Vertical") < 0 && startingLayer > 1)
        {
            startingLayer = startingLayer - 1; 
        }
        if (Input.GetAxis("Vertical") > 0 && startingLayer < 3)
        {
            startingLayer = startingLayer + 1;
        }
        if (startingLayer != startLayRecord)
        {
            if (startingLayer == 1)
            {
                slime.layer = 8;
                slime.GetComponent<SpriteRenderer>().sortingLayerName = "back";
                
            }
            if (startingLayer == 2)
            {
                slime.layer = 9;
                slime.GetComponent<SpriteRenderer>().sortingLayerName = "middle";

            }
            if (startingLayer == 3)
            {
                slime.layer = 10;
                slime.GetComponent<SpriteRenderer>().sortingLayerName = "front";

            }
        }
    }
}
