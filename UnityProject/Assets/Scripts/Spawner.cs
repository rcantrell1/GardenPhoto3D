using UnityEngine;
using System.Collections;

abstract public class Spawner : MonoBehaviour {
    public enum MouseOrSelection { Mouse, Selection };

	public GameObject toSpawn;
    public GenericCell selectedCell;

    public MouseOrSelection mouseOrSelection = MouseOrSelection.Mouse;

    protected abstract bool timeToSpawn();

    protected abstract bool timeToDestroy();

    void Update()
    {
        if (timeToSpawn()) {
            if (mouseOrSelection==MouseOrSelection.Mouse) {
                spawnUnderMouse();
            } else {
                spawnInSelectedCell();
            }
        }
        if (timeToDestroy()) {
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

    protected abstract bool okayToSpawnUnderMouse();

    void spawnUnderMouse() {
        if (okayToSpawnUnderMouse())
        {
            Vector3 newPos = Layout.translateToScreen(Input.mousePosition);
            newPos.y -= 140;
            Debug.Log("newpos: " + newPos.x + "," + newPos.y + "," + newPos.z);
            GameObject newObject = spawnAtLocation(newPos);
        } else {
            Debug.Log("Could not spawn under mouse.");
        }
    }

    void deSpawn(GameObject toDestroy) {
        GameObject.Destroy(toDestroy);
    }

    protected abstract bool okayToSpawnInSelectedCell();

    void spawnInSelectedCell() {
        if (okayToSpawnInSelectedCell())
        {
            GroundSquare square = selectedCell as GroundSquare;

            Vector3 newPos = selectedCell.transform.position;
            if (square!=null) {
                if (square.plant==null) {
                    Debug.Log("set plant");
                    GameObject newObject = spawnAtLocation(newPos);
                    square.plant = newObject;
                } else {
                    Debug.Log("Square already full.");
                }
            } else {
                Debug.Log("Selected cell could not have plant assigned to it. Plant lost forever.");
            }
        } else {
            Debug.Log("Could not spawn in selected cell.");
        }
    }

    protected abstract GameObject spawnAtLocation(Vector3 location);

}
