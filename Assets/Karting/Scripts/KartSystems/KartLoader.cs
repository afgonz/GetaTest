using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KartLoader : MonoBehaviour
{
    // Kart parts that should be modified/loaded when starting the game
    public MeshFilter[] wheel;
    public SkinnedMeshRenderer bodyMaterial;

    // Load the kart configutarion from the initial screen
    void Start()
    {
        for (int i = 0; i < wheel.Length; i++)
        {
            wheel[i].sharedMesh = Resources.Load<MeshFilter>("Kart/Wheel/Wheel_" + KartSetup.WheelType.wheelType[i]).sharedMesh;
        }
        bodyMaterial.material = Resources.Load<Material>("Kart/Body/KartBody_" + KartSetup.BodyColor);
    }

}
