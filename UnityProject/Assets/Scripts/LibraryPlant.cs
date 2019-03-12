using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class LibraryPlant {
	string type;
	string plantName;
    string imageLocation;
	Texture2D texture;

    public LibraryPlant(string type, string name, string imageFileLocation) {
        initialize(type,name,imageFileLocation);
    }


    void initialize(string type,string name,string imageFileLocation) {
		this.type=type;
		this.plantName=name;
        this.imageLocation=imageFileLocation;
		if (File.Exists(imageFileLocation)) {
			byte[] fileData=File.ReadAllBytes(imageFileLocation);
			texture=new Texture2D(2,2);
			texture.LoadImage(fileData);
		}
	}

    public string Name() { // e.g. Crocus_white
        return type+"_"+plantName;
    }

    public override string ToString() {
        return Name()+" "+imageLocation;
    }
}

