using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DayType { SUN, MON, TUES, WED, THURS, FRI, SAT}

//the days
public class Day
{
    public DayType dayType;

    //????
    public DayType NextDay(DayType day)
    {
        int d = (int)day;
        return (DayType)(d + 1);
    }


}

//creates a clock used to indicate time
//when created for use, clock uses a 24-hour clock
public class Clock
{
    int hour;
    int minutes;

    //updates the hours and minutes according to the minutes provided
    private void SetMinute(int m)
    {
        minutes += m % 60;
        hour += m / 6;
    }

    //updates the hours and minutes according to the hours provided
    //also checks if the next day is upon us
    public void SetHour(int h)
    {
        //becomes the next day. 
        if (h > 24)
        {
            h = h == 24 ? 0 : h - 24;
            GameTime.Instance.NextDay();
            SetHour(h);
        }
        SetMinute(h * 60);
    }

    //increaes the time by 1 minute
    public void IncreaseTime()
    {
        minutes++;
        SetHour(minutes / 60);
    }

    public override string ToString()
    {
        return hour + ":" + minutes;
    }

    public override bool Equals(object obj)
    {
        if (obj.GetType() != typeof(Clock)) return false;
        Clock other = (Clock)obj;
        if (other.minutes != minutes) return false;
        if (other.hour != hour) return false;
        return true;
    }
}