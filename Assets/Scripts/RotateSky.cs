using UnityEngine;

public class RotateSky : MonoBehaviour
{
    public float RotateSpeed = 1.2f;

#if UNITY_EDITOR
    private void OnDestroy()
    {
        RenderSettings.skybox.SetFloat("_Rotation", 0);
    }

    private void OnApplicationQuit()
    {
        RenderSettings.skybox.SetFloat("_Rotation", 0);
    }
#endif

    private void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * RotateSpeed);
    }
}
