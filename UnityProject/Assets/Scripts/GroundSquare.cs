using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSquare : GenericCell {

    public GameObject plant;

    // Use this for initialization
    void SpecificStart () {
        setMaterial();
        printInfo();
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log("GS update");
        if (Input.GetMouseButtonDown(0)) {
            //Debug.Log("GS: "+Input.mousePosition.x+","+Input.mousePosition.y+","+Input.mousePosition.z);
            //Debug.Log("GS mouse pressed");
            if (clickWasHere()) {
                //Debug.Log("GS clicked");
                highlight();
            } else {
                //Debug.Log("GS not clicked");
                unhighlight();
            }
        } else {
        }
        //Debug.Log("GS done update");
    }

    new public bool clickWasHere()
    {
        Vector3 pz=Layout.translateToScreen(Input.mousePosition);
        //Debug.Log("view: "+pz.x+","+pz.y+","+pz.z);
        //Debug.Log("position: "+box.transform.position.x+","+box.transform.position.y + "," + box.transform.position.z);
        return box.bounds.Contains(pz);
    }

    void setMaterial() {
        if (isHighlighted) {
            this.GetComponent<Renderer>().material=highlighted;
        } else {
            this.GetComponent<Renderer>().material = normal;
        }
}

void printInfo() {
        if (isHighlighted)
        {
            //Debug.Log("GS is highlighted");
        }
        else
        {
            //Debug.Log("GS is not highlighted");
        }
    }


}
