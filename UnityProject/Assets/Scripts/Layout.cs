using UnityEngine;
using System.Collections;

public class Layout : MonoBehaviour {
	public int topLeftX=0; //-50Y
	public int topLeftY=700; //500;
	
	public int borderwidth=5;
	public int numColumns=3;
	public int numRows=3;
	public int interval=70;

	public int width=10;
	public int height=10;

    public static Vector3 translateToScreen(Vector3 input) {
        Vector3 position = new Vector3(input.x, input.y, 1f);
        Vector3 pz = Camera.main.ScreenToWorldPoint(position);
        pz.x *= 130;
        pz.z *= 130;
        //Debug.Log("view: " + pz.x + "," + pz.y + "," + pz.z);
        //Debug.Log("position: "+box.transform.position.x+","+box.transform.position.y + "," + box.transform.position.z);
        return pz;
    }
}
