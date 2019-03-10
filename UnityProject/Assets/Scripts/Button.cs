using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Button : MonoBehaviour {
    public TimeLine timeline;

    public enum Dir {forward, neither, backward};
    public Dir dir=Dir.neither;
	
	public BoxCollider box;


    public void Update() {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Button: clicked");
            if (clickWasHere()) {
                Debug.Log("Button: input sensed");
                if (timeline!=null) {
                    if (dir==Dir.forward) {
                        timeline.increment();
                    } else if (dir==Dir.backward) {
                        timeline.decrement();
                    } else {
                        Debug.Log("Button: no direction");
                    }
                } else {
                    Debug.Log("Button: timeline was null");
                }
            } else {
                Debug.Log("Button: click was not here.");
            }
        }
    }

    public bool clickWasHere()
    {
        Vector3 pz = Layout.translateToScreen(Input.mousePosition);
        return box.bounds.Contains(pz);
    }

	void Start () {
        Transform parent = this.transform.parent;
        box = parent.GetComponent<BoxCollider>();
        TimeLine[] timelines=FindObjectsOfType<TimeLine>();
        if (timelines.Length>0) {
            timeline=timelines[0];
        }
	}

}
