using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecificSpawner : Spawner {

    public string input;
    public string input_destroy = "x";

    protected override bool timeToSpawn()
    {
        return Input.GetKeyDown(input);
    }

    protected override bool timeToDestroy()
    {
        return Input.GetKeyDown(input_destroy);
    }

    protected override bool okayToSpawnUnderMouse()
    {
        return (input != null && toSpawn != null);
    }

    protected override bool okayToSpawnInSelectedCell()
    {
        return (input != null && toSpawn != null && selectedCell != null);
    }

    protected override GameObject spawnAtLocation(Vector3 location)
    {
        return (GameObject)Instantiate(toSpawn,
                                       location,
                                       Quaternion.identity);

    }
}
