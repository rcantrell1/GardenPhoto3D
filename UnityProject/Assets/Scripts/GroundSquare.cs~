using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSquare : GenericCell {

    public GameObject plant;
    public TimeLine timeline;

    // Use this for initialization
    protected override void SpecificStart () {
        Transform parent = this.transform.parent;
        box = parent.GetComponent<BoxCollider>();
        TimeLine[] timelines = FindObjectsOfType<TimeLine>();
        if (timelines.Length > 0)
        {
            timeline = timelines[0];
        } else {
            Debug.Log("Could not find timeline.");
        }

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
        Material mat;
        if (isHighlighted) {
            mat = timeline.getCurrentHighlightedMat();
            if (mat==null) {
                Debug.Log("couldn't get season-specific highlighted.");
                mat=highlighted;
            } else {
                Debug.Log("got season-specific highlighted.");
            }
        } else {
            mat = timeline.getCurrentNormalMat();
            if (mat==null) {
                Debug.Log("couldn't get season-specific normal.");
                mat = normal;
            }
            else
            {
                Debug.Log("got season-specific normal.");
            }
        }
        this.GetComponent<Renderer>().material = mat;
    }

    // Formatting
    public void unhighlight()
    {
        Debug.Log("GC unhighlight");
        isHighlighted = false;
        setMaterial();
    }

    public void highlight()
    {
        Debug.Log("GC highlight");
        isHighlighted = true;
        setMaterial();
        Debug.Log("ugh: " + box.transform.position.x + "," + box.transform.position.y + "," + box.transform.position.z);

        Spawner[] spawners = FindObjectsOfType<Spawner>();
        foreach (Spawner spawner in spawners)
        {
            spawner.selectedCell = this;
            Debug.Log("component: " + spawner.ToString());
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
