using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

    public string input;

	public GameObject toSpawn;

    void Update()
    {
        if (Input.GetKeyDown(input)) {
            if (input!=null && toSpawn!=null) {
                Vector3 newPos= Layout.translateToScreen(Input.mousePosition);
                newPos.y-=140;
                Debug.Log("newpos: "+newPos.x+","+newPos.y+","+newPos.z);
                GameObject newObject = (GameObject)Instantiate(toSpawn, 
                                                               newPos,
                                                               Quaternion.identity);
            }
        }
    }

}
