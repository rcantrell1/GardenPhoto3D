using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * going up to down, y changes from 519 to 150 (~40)
 * going left to right, x changes from 420 to 789 (370)
 *
 * going from up to down y change from 1 to 19
 * going from left to right, x changes from 10 to 1
 */

public class Game : MonoBehaviour {

    public float cameraDistance=14f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
    void Update () {
//Vector3 gridCoords = /*SnapToGrid(*/
//CalculateWorldPointOfMouseClick()/*)*/;
  /*      float x=gridCoords.x;
        float y=gridCoords.y;
        float z=gridCoords.z;
        string info =" "+x+" "+y+" "+z;
        Debug.Log(info);
        //GameObject newObject = (GameObject)Instantiate(Button.selectedDefender, gridCoor\
                                                               // ds, Quaternion.identity);
        //newObject.transform.SetParent(parent.transform);
        //newObject.GetComponentInParent=
        */
        CastRayTowardBoard();
    }

    void CastRayTowardBoard() {
        //Input.mousePosition
        check(Vector3.up,"up");
        check(Vector3.down,"down");
        check(Vector3.left,"left");
        check(Vector3.right,"right");
        check(Vector3.forward,"forward");
        check(Vector3.back,"back");

    }

   void check(Vector3 dir,string dirString) {
        /*RaycastHit hit;
        if (Physics.Raycast(Input.mousePosition, dir, out hit))
        {
            Debug.DrawLine(Camera.main.ScreenPointToRay(Input.mousePosition), hit.point, Color.green);
            Debug.Log("hit "+dirString);
        }
        else
        {
            Debug.Log("no hit "+dirString+" "+Input.mousePosition.x+","+Input.mousePosition.y+","+Input.mousePosition.z);
        }*/
    }

    Vector3 CalculateWorldPointOfMouseClick()
    {
        float mouseX = Input.mousePosition.x;
        float mouseY = Input.mousePosition.y;
        float mouseZ = Input.mousePosition.z;

        Vector3 weirdTriplet = new Vector3(mouseX, mouseY, cameraDistance); //mouseZ); //
        //Vector3 weirdTriplet = new Vector3(mouseX, cameraDistance, mouseZ); //mouseZ); //
        return weirdTriplet;
        /*Camera camera = FindObjectOfType<Camera>();
        Vector3 vector3 = camera.ScreenToWorldPoint(weirdTriplet);
        Vector2 vector2 = new Vector2(vector3.x, vector3.y);

        return vector2;*/
    }

    Vector2 SnapToGrid(Vector2 rawWorldPosition)
    {
        int x = Mathf.RoundToInt(rawWorldPosition.x);
        int y = Mathf.RoundToInt(rawWorldPosition.y);
        if (x < 1) { x = 1; }
        if (x > 9) { x = 9; }
        if (y < 1) { y = 1; }
        if (y > 5) { y = 5; }
        Vector2 gridCoords = new Vector2(x, y);
        return gridCoords;
    }
}
