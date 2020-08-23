using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeBoardColor : MonoBehaviour
{
    // public Color startColor;
    // public Color mouseOverColor;
//bool mouseOver = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseEnter(){
        //print("mouse enter");
        //mouseOver = true;
        GetComponent<SpriteRenderer>().color=new Color(100,0,0);
    }

    private void OnMouseExit(){
        //print("mouse exit");
         //mouseOver = false;
        GetComponent<SpriteRenderer>().color=new Color(1,1,1);
    }
}
