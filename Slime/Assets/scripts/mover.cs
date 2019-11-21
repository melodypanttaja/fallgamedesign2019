using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mover : MonoBehaviour
{
    public string layer;
    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer temp;
        for(int i = 0; i < transform.childCount; i++)
        {
            temp = transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>();
            if ( temp != null)
            {
                temp.sortingLayerName = layer;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
