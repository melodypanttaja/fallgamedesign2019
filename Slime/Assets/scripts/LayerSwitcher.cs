using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerSwitcher : MonoBehaviour
{
	//setting up variables
    public GameObject slime;
    public GameObject frontLayer;
    public GameObject backLayer;
    public GameObject midLayer;
    public int startingLayer;
    private int startLayRecord;
	float timeMarker1 = 0;
	float timeMarker2 = 0;
    // Start is called before the first frame update
    void Start()
    {
		//making sure everythings on the right layer to start
		if (startingLayer == 1)
		{
			setLayer(8, "back", 1.0f, 0.5f, 0.5f);
		}
		if (startingLayer == 2)
		{
			setLayer(9, "middle", 0.5f, 1.0f, 0.5f);
		}
		if (startingLayer == 3)
		{
			setLayer(10, "front", 0.5f, 0.5f, 1.0f);
		}
	}

    // Update is called once per frame
    void Update()
    {
		//changes the record of what layer we're on
		startLayRecord = startingLayer;
        if (Input.GetAxis("Vertical") < 0 && startingLayer > 1 && Time.time - timeMarker2 > .25)
        {
            startingLayer = startingLayer - 1;
			timeMarker2 = Time.time;
		}
        if (Input.GetAxis("Vertical") > 0 && startingLayer < 3 && Time.time - timeMarker1 > 1)
        {
            startingLayer = startingLayer + 1;
			timeMarker1 = Time.time;
        }
		//using starting layer to set the sorting layers and translusency's
        if (startingLayer != startLayRecord)
        {
            if (startingLayer == 1)
            {
				setLayer(8, "back", 1.0f, 0.5f, 0.5f);
			}
            if (startingLayer == 2)
            {
				setLayer(9, "middle", 0.5f, 1.0f, 0.5f);
			}
            if (startingLayer == 3)
            {
				setLayer(10, "front", 0.5f, 0.5f, 1.0f);
			}
        }
    }
    void translucentChildren(GameObject layerContainer,  float setTo)
    {
		//sets translucency's
        SpriteRenderer temp;
        for (int i = 0; i < layerContainer.transform.childCount; i++)
        {
            temp = layerContainer.transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>();
            if (temp != null)
            {
				Color color = temp.color;
                color.a = setTo;
				temp.color = color;
            }
        }

    }
	void setLayer( int layNum, string layName,  float backTransparancy, float midTransparancy, float frontTransparancy)
	{
		slime.layer = layNum;
		slime.GetComponent<SpriteRenderer>().sortingLayerName = layName;
		translucentChildren(midLayer, midTransparancy);
		translucentChildren(frontLayer, frontTransparancy);
		translucentChildren(backLayer, backTransparancy);
	}
}
