using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine.UI;

public class GenericBoard : MonoBehaviour {
	
	public GameObject cellType;
	
	public Canvas canvas;
	public Layout layout;
	
	[SerializeField] public int highlighted=0;
	
	GameObject[,] cells;


	// Use this for initialization
	void Start () {
		Debug.Log ("GB start board");
		create();
		Debug.Log ("GB started board");
	}
		
	void create() {
		Debug.Log ("GB create");
		highlighted=0;
		setUpGrid();		
		Debug.Log ("GB created");
	}
	
	void setUpGrid() {
		cells=new GameObject[9,9];
		
        if (layout!=null) {
		int x=layout.topLeftX;
		for (int i=0; i<layout.width-1; i++) {
			x+=layout.interval;
			int y=layout.topLeftY;
			for (int j=0; j<layout.height-1; j++) {
				y-=layout.interval;
				GameObject thisCell = Instantiate(cellType, new Vector3(x, 0, y/*y, 0*/), Quaternion.identity) as GameObject;
				//thisCell.setLocation(i,j); /* to generify */
				//Debug.Log (thisCell.transform.position);
				thisCell.transform.SetParent(canvas.transform); //,false);
				//thisCell.board=this; /* to generify */
				/*SpriteRenderer sr = thisCell.GetComponent<SpriteRenderer>();
				if (sr!=null) {
					transform.localScale=new Vector3(1,1,1);
					float width = sr.sprite.bounds.size.x;
					float height = sr.sprite.bounds.size.y;
					double worldScreenHeight = Camera.main.orthographicSize * 2.0;
					double worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;
					float xScale = (float) worldScreenWidth / width;
					float yScale = (float) worldScreenHeight / height;
					transform.localScale.Set(xScale, yScale, 1F);
				} else {
					Debug.Log ("it is null");
				}*/
				cells[i,j]=thisCell;
				if ((j+1)%layout.numColumns==0) {
					y-=layout.borderwidth;
				}
			}
			if ((i+1)%layout.numRows==0) {
				x+=layout.borderwidth;
			}
            } 
		} else
        {
            Debug.Log("GB Layout was null");
        }
    }
	
	void Update() {
	   //input goes here
	}
	
	/*public string toErrorString() {
		return highlighted.ToString ();
	}*/

	public void reset() {
		Debug.Log ("GB resetting");
		destroyCells ();
		create();
		Debug.Log ("GB end resetting");
	}
	
	public void destroyCells() {
		for (int i=0; i<layout.width; i++) {
			for (int j=0; j<layout.height; j++) {
				Destroy(cells[i,j]);
			}
		}
	}
	
	/*public bool isHighlighted(int value) {
		return highlighted==value;
	}*/
	
	/* function ResizeSpriteToScreen() {
		var sr = GetComponent(SpriteRenderer);
		if (sr == null) return;
		
		transform.localScale = Vector3(1,1,1);
		
		var width = sr.sprite.bounds.size.x;
		var height = sr.sprite.bounds.size.y;
		
		var worldScreenHeight = Camera.main.orthographicSize * 2.0;
		var worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;
		
		transform.localScale.x = worldScreenWidth / width;
		transform.localScale.y = worldScreenHeight / height;
	}*/
	
	/*public void unhighlight() {
		highlight (0);
	}
	
	public void highlight() {
		if (highlighted!=0) {
			highlight (highlighted);
		}
	}
	
	public void highlight(int value) {
		highlighted=value;
		for (int i=0; i<9; i++) {
			for (int j=0; j<9; j++) { 
				GameObject cell = cells[i,j];
				if (cell!=null) {
					if (cell.matches (value)) {
						cell.highlight ();
					} else {
						cell.unhighlight();
					}
				}
			}
		}
	}*/
	
	
	
	//for saving
	/*public void readFromFile(string filename) {
		//Debug.Log ("reading from file");
		reset ();
		string[] lines = System.IO.File.ReadAllLines(@filename);
		if (lines.Length==81) {
			int thisLine=0;
			for (int i=0; i<9; i++) {
				for (int j=0; j<9; j++) {
					//Debug.Log ("line #:"+thisLine.ToString()+" x:"+i.ToString()+" y"+j.ToString()+" current cell state:"+cell.toErrorString()+ "line:"+lines[thisLine]);
					//Debug.Log ("calling setFromString");
					cells[i,j].setFromString(lines[thisLine]);
					thisLine++;
				}
			}
		}
		//Debug.Log ("end read from file");
	}
	
	public void writeFile(string filename) {
		string [] lines=new string[81];
		int thisLine=0;
		for (int i=0; i<9; i++) {
			for (int j=0; j<9; j++) {
				lines[thisLine]=cells[i,j].writeToSetString();
				thisLine++;
			}
		}
		System.IO.File.WriteAllLines(@filename, lines);
	}*/
}
