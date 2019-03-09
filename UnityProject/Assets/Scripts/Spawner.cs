using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
    public enum MouseOrSelection { Mouse, Selection };

    public string input;

	public GameObject toSpawn;
    public GenericCell selectedCell;

    public MouseOrSelection mouseOrSelection = MouseOrSelection.Mouse;

    void Update()
    {
        if (Input.GetKeyDown(input)) {
            if (mouseOrSelection==MouseOrSelection.Mouse) {
                spawnUnderMouse();
            } else {
                spawnInSelectedCell();
            }
        }
    }

    void spawnUnderMouse() {
        if (input != null && toSpawn != null)
        {
            Vector3 newPos = Layout.translateToScreen(Input.mousePosition);
            newPos.y -= 140;
            Debug.Log("newpos: " + newPos.x + "," + newPos.y + "," + newPos.z);
            GameObject newObject = (GameObject)Instantiate(toSpawn,
                                                               newPos,
                                                               Quaternion.identity);
        } else {
            Debug.Log("Could not spawn under mouse.");
        }
    }

    void spawnInSelectedCell() {
        if (input != null && toSpawn != null && selectedCell != null)
        {
            Vector3 newPos = selectedCell.transform.position;
            GameObject newObject = (GameObject)Instantiate(toSpawn,
                                                               newPos,
                                                               Quaternion.identity);
        }
        else
        {
            Debug.Log("Could not spawn in selected cell.");
        }
    }

}
