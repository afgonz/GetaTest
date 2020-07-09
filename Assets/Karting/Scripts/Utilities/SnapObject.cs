using UnityEngine;

[ExecuteInEditMode]
public class SnapObject : MonoBehaviour
{
    //Script designed to snap the track models to the game grid, allowing a faster and easier design, it only runs inside the editor
#if UNITY_EDITOR
    public float grid_scale = 10f;
    private void OnGUI()
    {
        var currentPos = transform.position;
        transform.position = new Vector3(Mathf.Round(currentPos.x / grid_scale) * grid_scale,
            Mathf.Round(currentPos.y / grid_scale) * grid_scale,
            Mathf.Round(currentPos.z / grid_scale) * grid_scale);
    }
    #endif
}
