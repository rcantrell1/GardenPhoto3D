using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Library : MonoBehaviour {
    public string libraryPath="/Users/rcantrel/git/GardenPhoto3D/Library";
    List<LibraryPlant> plants;

	// Use this for initialization
	void Start () {
        plants=new List<LibraryPlant>();

		Debug.Log("start library...");
		DirectoryInfo dirInfo = new DirectoryInfo(libraryPath);
        foreach (DirectoryInfo dir_type in dirInfo.GetDirectories("*")) { //Crocus
            foreach (DirectoryInfo dir_name in dir_type.GetDirectories("*")) { //white, tomm
                foreach (FileInfo file in dir_name.GetFiles("*.png")) {
                    LibraryPlant newPlant= new LibraryPlant(dir_type.Name, dir_name.Name, file.ToString());
                    plants.Add(newPlant);
                }
            }
		}
        Debug.Log("library started");
        List();
	}

    void List() {
        if (plants!=null) {
            foreach (LibraryPlant plant in plants) {
                Debug.Log(plant.ToString());
            }
        }
    }

    public LibraryPlant GetLibraryPlant(int i) {
        if (plants!=null) {
            return plants[i];
        }
        return null;
    }
	
    public LibraryPlant GetLibraryPlant(string name) { // e.g. Crocus_white
        if (plants!=null) {
            foreach (LibraryPlant plant in plants) {
                if (name.Equals(plant.Name())) {
                    return plant;
                }
            }
        }
        return null;
    }

    public int countPlants() {
        return plants.Count;
    }
}
