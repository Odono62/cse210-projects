using System;
using System.Collections.Generic;

abstract class Activity
{
    private DateTime _date;
    private int _lengthMinutes;

    public Activity(DateTime date, int lengthMinutes)
    {
        _date = date;
        _lengthMinutes = lengthMinutes;
    }

    public DateTime GetDate() => _date;
    public int GetLengthMinutes() => _lengthMinutes;

    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    public virtual string GetSummary()
    {
        string dateStr = _date.ToString("dd MMM yyyy");
        string typeName = this.GetType().Name;
        double distance = GetDistance();
        double speed = GetSpeed();
        double pace = GetPace();

        return $"{dateStr} {typeName} ({_lengthMinutes} min) - Distance {distance:0.0} miles, Speed {speed:0.0} mph, Pace: {pace:0.0} min per mile";
    }
}

class Running : Activity
{
    private double _distanceMiles;

    public Running(DateTime date, int lengthMinutes, double distanceMiles)
        : base(date, lengthMinutes)
    {
        _distanceMiles = distanceMiles;
    }

    public override double GetDistance()
    {
        return _distanceMiles;
    }

    public override double GetSpeed()
    {
        double minutes = GetLengthMinutes();
        if (minutes <= 0) return 0;
        return (GetDistance() / minutes) * 60.0;
    }

    public override double GetPace()
    {
        double distance = GetDistance();
        if (distance <= 0) return 0;
        return GetLengthMinutes() / distance;
    }
}

class Cycling : Activity
{
    private double _speedMph;

    public Cycling(DateTime date, int lengthMinutes, double speedMph)
        : base(date, lengthMinutes)
    {
        _speedMph = speedMph;
    }

    public override double GetDistance()
    {
        return (_speedMph * GetLengthMinutes()) / 60.0;
    }

    public override double GetSpeed()
    {
        return _speedMph;
    }

    public override double GetPace()
    {
        if (_speedMph <= 0) return 0;
        return 60.0 / _speedMph;
    }
}

class Swimming : Activity
{
    private int _laps; // 50 meters per lap

    public Swimming(DateTime date, int lengthMinutes, int laps)
        : base(date, lengthMinutes)
    {
        _laps = laps;
    }

    public override double GetDistance()
    {
        // convert laps -> km -> miles using 0.62 factor as per spec hint
        double km = (_laps * 50.0) / 1000.0;
        return km * 0.62;
    }

    public override double GetSpeed()
    {
        double minutes = GetLengthMinutes();
        if (minutes <= 0) return 0;
        return (GetDistance() / minutes) * 60.0;
    }

    public override double GetPace()
    {
        double distance = GetDistance();
        if (distance <= 0) return 0;
        return GetLengthMinutes() / distance;
    }
}

class Program
{
    static void Main(string[] args)
    {
        var activities = new List<Activity>();

        activities.Add(new Running(new DateTime(2022, 11, 3), 30, 3.0));
        activities.Add(new Cycling(new DateTime(2022, 11, 3), 45, 15.0));
        activities.Add(new Swimming(new DateTime(2022, 11, 3), 30, 40));

        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}