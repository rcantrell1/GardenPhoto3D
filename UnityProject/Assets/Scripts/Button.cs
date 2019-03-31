using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Button : MonoBehaviour {
    //public TimeLine timeline;

    public enum Dir {forward, neither, backward};
    public enum Type {button,image};

    public Dir dir=Dir.neither;
    public Type type=Type.button;

	/*public*/ BoxCollider box;

    public void Update() {
        if (type==Type.image) {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Button: clicked");
            if (clickWasHere()) {
                Debug.Log("Button: input sensed");
                moveTime();
            }
            else {
                Debug.Log("Button: click was not here.");
            }
        }
        }
    }

    public void moveTime() {
        Debug.Log("Got a click");
        TimeLine timeline=getTimeLine();
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
    }

    public bool clickWasHere()
    {
        Vector3 pz = Layout.translateToScreen(Input.mousePosition);
        return box.bounds.Contains(pz);
    }

    TimeLine getTimeLine() {
        TimeLine[] timelines = FindObjectsOfType<TimeLine>();
        if (timelines.Length > 0)
        {
            return timelines[0];
        }
        return null;
    }

    BoxCollider getBoxCollider() {
        Transform parent = this.transform.parent;
        return parent.GetComponent<BoxCollider>();
    }

    void Start () {
        if (type==Type.image) {
        box=getBoxCollider();
        //timeline=getTimeLine();
        }
	}

}
