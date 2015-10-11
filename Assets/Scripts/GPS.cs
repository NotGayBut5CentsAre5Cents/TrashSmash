using UnityEngine;
using System.Collections;
using System;

public class GPS : MonoBehaviour
{
    public double sum = 0;
    public bool isEnabled = false;

    public bool isReadyToCalibrateCP = false;
    public bool isReadyToCalibrateLP = true;
    public float R = 6371000; // km
    public LocationInfo lastPoint = new LocationInfo();
    public LocationInfo currentPoint = new LocationInfo();
    void Update()
    {
        Input.location.Start();
        if(isEnabled)
        {
            if (isReadyToCalibrateLP)
            {
                lastPoint = Input.location.lastData;
                isReadyToCalibrateLP = false;
                StartCoroutine("timer");
            }
         }
        
    }
    IEnumerator timer()
    {
        Debug.Log("Opaa");
        yield return new WaitForSeconds(5);
        StartCoroutine("calculate");


    }
    IEnumerator calculate()
    {
        Debug.Log("Opaaaaaaaaaaaa");
        currentPoint = Input.location.lastData;
        double dLat = (currentPoint.latitude - lastPoint.latitude) * Mathf.Deg2Rad;
        var dLon = (currentPoint.longitude - lastPoint.longitude) * Mathf.Deg2Rad;
        var li = Mathf.Deg2Rad * lastPoint.latitude;
        var li2 = currentPoint.latitude * Mathf.Deg2Rad;

        var a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                Math.Sin(dLon / 2) * Math.Sin(dLon / 2) * Math.Cos(li) * Math.Cos(li2);
        var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
        sum += R * c;
        // 	Debug.Log("lastpoint " + lastPoint.X + " " + lastPoint.Y);
        //  	Debug.Log("currentpoint " + currentPoint.X + " " + currentPoint.Y);s
        isReadyToCalibrateLP = true;
        yield break;
    }
    public void enable(bool state)
    {
        isEnabled = state;
    }
    //public void Update()
    //{
    //    StartCoroutine("StartGPS");
    //}
    //
    //IEnumerator StartGPS()
    //{
    //    Debug.Log("StartGps");
    //    // First, check if user has location service enabled
    //    if (!Input.location.isEnabledByUser)
    //    {
    //        Debug.Log("InputNotEnabledByUser");
    //        yield break;
    //    }
    //    Debug.Log("After");
    //    // Start service before querying location
    //    Input.location.Start();
    //    Debug.Log("Started");
    //    // Wait until service initializes
    //    int maxWait = 20;
    //    while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
    //    {
    //        Debug.Log("waiting " + maxWait);
    //        yield return new WaitForSeconds(1);
    //        maxWait--;
    //    }
    //
    //    // Service didn't initialize in 20 seconds
    //    if (maxWait < 1)
    //    {
    //        print("Timed out");
    //        yield break;
    //    }
    //
    //    // Connection has failed
    //    if (Input.location.status == LocationServiceStatus.Failed)
    //    {
    //        print("Unable to determine device location");
    //        yield break;
    //    }
    //    else
    //    {
    //        // Access granted and location value could be retrieved
    //        lastPoint = new Point(Input.location.lastData.latitude, Input.location.lastData.longitude);
    //		yield return new WaitForSeconds(5);
    //		currentPoint = new Point(Input.location.lastData.latitude, Input.location.lastData.longitude);
    //		sum += Math.Sqrt((currentPoint.X-lastPoint.X)*(currentPoint.X-lastPoint.X)+(currentPoint.Y-lastPoint.Y)*(currentPoint.Y-lastPoint.Y));
    //        Debug.Log("lastpoint" + lastPoint);
    //        Debug.Log("currentpoint " + currentPoint);
    //
    //    }
    //
    //    // Stop service if there is no need to query location updates continuously
    //    Input.location.Stop();
    //    Debug.Log("stopped");
    //}
    // public class Point
    // {
    //     public Point(double x, double y)
    //     {
    //         this.X = x;
    //         this.Y = y;
    //     }
    //     public double X { get; set; }
    //     public double Y { get; set; }
    // }
}