using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KartModifier : MonoBehaviour
{
    [Tooltip("Stores the wheels mesh filters to modify the kart visuals.")]
    public MeshFilter[] wheel;
    private int currentWheels = 0;

    [Tooltip("Stores the kart renderer to modify its color.")]
    public SkinnedMeshRenderer bodyMaterial;
    private int currentColor;

    // Allow the player to change the actual kart wheels configuration
    public void WheelConfiguration(bool increase)
    {
        currentWheels += increase ? 1 : -1;
        currentWheels = currentWheels < 0 ? 2 : currentWheels > 2 ? 0 : currentWheels;
        switch (currentWheels)
        {
            case 0:
                KartSetup.WheelType = WheelDistribution.defaultDistribution;
                break;
            case 1:
                KartSetup.WheelType = WheelDistribution.controlDistribution;
                break;
            case 2:
                KartSetup.WheelType = WheelDistribution.terrainDistribution;
                break;
        }
        UpdateKartProperties();
    }

    // Allow the player to change the actual kart body color
    public void BodyColor(bool increase)
    {
        KartSetup.BodyColor += increase ? 1 : -1;
        KartSetup.BodyColor = KartSetup.BodyColor < 0 ? 5 : KartSetup.BodyColor > 5 ? 0 : KartSetup.BodyColor;
        UpdateKartProperties();
    }

    // Select the wheels and kart body color from the distributions available
    private void UpdateKartProperties()
    {
        for (int i = 0; i < wheel.Length; i++)
        {
            wheel[i].sharedMesh = Resources.Load<MeshFilter>("Kart/Wheel/Wheel_" + KartSetup.WheelType.wheelType[i]).sharedMesh;
        }
        bodyMaterial.material = Resources.Load<Material>("Kart/Body/KartBody_" + KartSetup.BodyColor);
    }
}
