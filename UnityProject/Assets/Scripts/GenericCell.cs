using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GenericCell : MonoBehaviour {
	//Options options;
	public GenericBoard board;
    //public Camera camera;
	
	public BoxCollider box;

    public Material normal;
    public Material highlighted;
    public bool isHighlighted = false;
	
	[SerializeField] int [] location=new int[2];

    public bool clickWasHere()
    {
        return box.bounds.Contains(Input.mousePosition);
    }

	// Formatting
	public void unhighlight() {
        Debug.Log("GC unhighlight");
        isHighlighted = false;
        setMaterial();
    }
	
	public void highlight() {
        Debug.Log("GC highlight");
        isHighlighted = true;
        setMaterial();
        Debug.Log("ugh: "+box.transform.position.x+","+box.transform.position.y+","+box.transform.position.z);

        Spawner[] spawners = FindObjectsOfType<Spawner>();
        foreach (Spawner spawner in spawners) {
                spawner.selectedCell=this;
                Debug.Log("component: "+spawner.ToString());
        }       
    }

    void setMaterial()
    {
        //Debug.Log("GC Set material");
        //Debug.Log("GC isHighlighted: " + isHighlighted);
        if (isHighlighted)
        {
            this.GetComponent<Renderer>().material = highlighted;
        }
        else
        {
            this.GetComponent<Renderer>().material = normal;
        }
        //Debug.Log("GC Done setting material");
    }

    // Setup
    public void setLocation(int x,int y) {
		this.location[0]=x;
		this.location[1]=y;
	}
	
	void Start () {
		//Debug.Log ("GC start cell");
		//options = GameObject.Find("Canvas").GetComponent<Options>();
        Transform parent=this.transform.parent;
        MonoBehaviour[] components = parent.GetComponents<MonoBehaviour>();
        for (int i=0; i<components.Length; i++) {
            Debug.Log(components.ToString());
        }
        int children = parent.childCount;
        //Debug.Log("GC child count: " + children);
        box=parent.GetComponent<BoxCollider>();
		GameObject boardObject = GameObject.Find("GenericBoard");
		if (boardObject!=null) {
			board = GameObject.Find("GenericBoard").GetComponent<GenericBoard>();
		} else {
			//Debug.Log ("GC there is no board");
		}
		//Debug.Log ("GC end start cell");
        SpecificStart();
	}

    void SpecificStart() {
    }
	
	//for saving
	public void setFromString(string valuesString) {
	}
	
	public string writeToSetString() {
		return "GC DEFAULT";
	}
}
