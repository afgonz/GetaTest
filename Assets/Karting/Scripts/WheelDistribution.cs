using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelDistribution
{
    public WheelType[] wheelType = new WheelType[4];

    // Adds the wheel types definitions to each one of the wheels
    private WheelDistribution(WheelType frontWheel, WheelType rearWheel)
    {
        wheelType[0] = wheelType[1] = frontWheel;
        wheelType[2] = wheelType[3] = rearWheel;
    }
 
    // Creates default definitions for the wheels distributions
    public static WheelDistribution defaultDistribution = new WheelDistribution(WheelType.Small, WheelType.Big);
    public static WheelDistribution controlDistribution = new WheelDistribution(WheelType.Small, WheelType.Small);
    public static WheelDistribution terrainDistribution = new WheelDistribution(WheelType.Big, WheelType.Big);
}

// Defines the wheel types, in this case only have a big and small mesh
public enum WheelType
{
    Small,
    Big,
}