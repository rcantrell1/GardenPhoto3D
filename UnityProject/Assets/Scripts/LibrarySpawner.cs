using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LibrarySpawner : Spawner {

    public Library library;
    public Material mat;
    string input_destroy = "x";

    protected override bool timeToSpawn()
    {
        if (library!=null) {
            for (int number=0; number<library.countPlants(); number++) {
                if (Input.GetKeyDown(number.ToString())) {
                    //mat=library.GetLibraryPlant().material;
                    mat=new Material(mat);
                    mat.SetTexture("_MainTex",library.GetLibraryPlant(number).texture);

                    return true;
                }
            }
        }
        return false;
    }

    protected override bool timeToDestroy()
    {
        return Input.GetKeyDown(input_destroy);
    }

    protected override bool okayToSpawnUnderMouse()
    {
        return (toSpawn != null);
    }

    protected override bool okayToSpawnInSelectedCell()
    {
        return (toSpawn != null && selectedCell != null);
    }

    protected override GameObject spawnAtLocation(Vector3 location)
    {
        GameObject plant = Instantiate(toSpawn,
                                       location,
                                       Quaternion.identity);
        int childCount=toSpawn.transform.childCount;
        if (childCount>0) {

            //this.GetComponent<Renderer>().material = mat;
            Transform child = toSpawn.transform.GetChild(0);
            child.GetComponent<Renderer>().material = mat;
        }
        return plant;
    }
}
