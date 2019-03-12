using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeLine : MonoBehaviour {

    public enum Month {Jan, Feb, Mar, Apr, May, Jun, Jul, Aug, Sep, Oct, Nov, Dec};

    public Material winter_normal;
    public Material winter_highlighted;
    public Material spring_normal;
    public Material spring_highlighted;
    public Material summer_normal;
    public Material summer_highlighted;
    public Material fall_normal;
    public Material fall_highlighted;

    public Month month;
    public int year;

    public Text monthDisplay;
    public Text yearDisplay;

    public void setMonth(Month new_month) {
        month=new_month;
        monthDisplay.text=month.ToString();
    }

    public void setYear(int new_year) {
        year=new_year;
        yearDisplay.text=year.ToString();
    }

    // Use this for initialization
    void Start () {
        setMonth(Month.Apr);
        setYear(1);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public Material getCurrentNormalMat() {
        if (month == Month.Dec || month == Month.Jan || month == Month.Feb)
        {
            return winter_normal;
        } 
        if (month == Month.Mar || month == Month.Apr || month == Month.May)
        {
            return spring_normal;
        }
        if (month == Month.Jun || month == Month.Jul || month == Month.Aug)
        {
            return summer_normal;
        }
        if (month == Month.Sep || month == Month.Oct || month == Month.Nov)
        {
            return fall_normal;
        }
        return summer_normal;
    }

    public Material getCurrentHighlightedMat()
    {
        if (month==Month.Dec || month == Month.Jan || month == Month.Feb) {
            return winter_highlighted;
        }
        if (month == Month.Mar || month == Month.Apr || month == Month.May)
        {
            return spring_highlighted;
        }
        if (month == Month.Jun || month == Month.Jul || month == Month.Aug)
        {
            return summer_highlighted;
        }
        if (month == Month.Sep || month == Month.Oct || month == Month.Nov)
        {
            return fall_highlighted;
        }
        return summer_highlighted;
    }

    public void increment() {
        switch (month) {
            case Month.Jan:
                setMonth(Month.Feb);
                break;
            case Month.Feb:
                setMonth(Month.Mar);
                break;
            case Month.Mar:
                setMonth(Month.Apr);
                break;
            case Month.Apr:
                setMonth(Month.May);
                break;
            case Month.May:
                setMonth(Month.Jun);
                break;
            case Month.Jun:
                setMonth(Month.Jul);
                break;
            case Month.Jul:
                setMonth(Month.Aug);
                break;
            case Month.Aug:
                setMonth(Month.Sep);
                break;
            case Month.Sep:
                setMonth(Month.Oct);
                break;
            case Month.Oct:
                setMonth(Month.Nov);
                break;
            case Month.Nov:
                setMonth(Month.Dec);
                break;
            case Month.Dec:
                setMonth(Month.Jan);
                setYear(year+1);
                break;
        }
    }

    public void decrement()
    {
        switch (month)
        {
            case Month.Jan:
                setMonth(Month.Dec);
                setYear(year-1);
                break;
            case Month.Feb:
                setMonth(Month.Jan);
                break;
            case Month.Mar:
                setMonth(Month.Feb);
                break;
            case Month.Apr:
                setMonth(Month.Mar);
                break;
            case Month.May:
                setMonth(Month.Apr);
                break;
            case Month.Jun:
                setMonth(Month.May);
                break;
            case Month.Jul:
                setMonth(Month.Jun);
                break;
            case Month.Aug:
                setMonth(Month.Jul);
                break;
            case Month.Sep:
                setMonth(Month.Aug);
                break;
            case Month.Oct:
                setMonth(Month.Sep);
                break;
            case Month.Nov:
                setMonth(Month.Oct);
                break;
            case Month.Dec:
                setMonth(Month.Nov);
                break;
        }
    }

}
