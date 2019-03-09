using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
    public enum MouseOrSelection { Mouse, Selection };

    public string input;
    public string input_destroy="x";

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
        if (Input.GetKeyDown(input_destroy)) {
            if (selectedCell!=null) {
                GroundSquare square = selectedCell as GroundSquare;
                if (square != null) {
                    GameObject plant=square.plant;
                    if (plant!=null) {
                        Debug.Log("destroy plant");
                        deSpawn(square.plant);
                    } else {
                        Debug.Log("plant was null");
                    }
                } else {
                    Debug.Log("square was null");
                }
            } else {
                Debug.Log("Selected cell could not have plant assigned to it. Plant lost forever.");
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

    void deSpawn(GameObject toDestroy) {
        GameObject.Destroy(toDestroy);
    }

    void spawnInSelectedCell() {
        if (input != null && toSpawn != null && selectedCell != null)
        {
            Vector3 newPos = selectedCell.transform.position;
            GameObject newObject = (GameObject)Instantiate(toSpawn,
                                                               newPos,
                                                               Quaternion.identity);
            GroundSquare square = selectedCell as GroundSquare;
            if (square != null)
            {
                Debug.Log("set plant");
                square.plant = newObject;
            }
            else
            {
                Debug.Log("Selected cell could not have plant assigned to it. Plant lost forever.");
            }
        }
        else
        {
            Debug.Log("Could not spawn in selected cell.");
        }
    }

}
