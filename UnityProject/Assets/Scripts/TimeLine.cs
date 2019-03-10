using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeLine : MonoBehaviour {

    public enum Month {Jan, Feb, Mar, Apr, May, Jun, Jul, Aug, Sep, Oct, Nov, Dec};

    public Month month=Month.Apr;
    public int year=1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void increment() {
        switch (month) {
            case Month.Jan:
                month = Month.Feb;
                break;
            case Month.Feb:
                month = Month.Mar;
                break;
            case Month.Mar:
                month = Month.Apr;
                break;
            case Month.Apr:
                month = Month.May;
                break;
            case Month.May:
                month = Month.Jun;
                break;
            case Month.Jun:
                month = Month.Jul;
                break;
            case Month.Jul:
                month = Month.Aug;
                break;
            case Month.Aug:
                month = Month.Sep;
                break;
            case Month.Sep:
                month = Month.Oct;
                break;
            case Month.Oct:
                month = Month.Nov;
                break;
            case Month.Nov:
                month = Month.Dec;
                break;
            case Month.Dec:
                month = Month.Jan;
                year++;
                break;
        }
    }

    public void decrement()
    {
        switch (month)
        {
            case Month.Jan:
                month=Month.Dec;
                year--;
                break;
            case Month.Feb:
                month = Month.Jan;
                break;
            case Month.Mar:
                month = Month.Feb;
                break;
            case Month.Apr:
                month = Month.Mar;
                break;
            case Month.May:
                month = Month.Apr;
                break;
            case Month.Jun:
                month = Month.May;
                break;
            case Month.Jul:
                month = Month.Jun;
                break;
            case Month.Aug:
                month = Month.Jul;
                break;
            case Month.Sep:
                month = Month.Aug;
                break;
            case Month.Oct:
                month = Month.Sep;
                break;
            case Month.Nov:
                month = Month.Oct;
                break;
            case Month.Dec:
                month = Month.Nov;
                break;
        }
    }

}
