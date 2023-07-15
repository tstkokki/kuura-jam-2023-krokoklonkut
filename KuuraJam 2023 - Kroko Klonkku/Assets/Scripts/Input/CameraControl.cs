using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{

    [SerializeField] List<Vector3Variable> cameras;
    int currentCameraIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        if (CamerasHaveBeenSet())
            transform.position = cameras[0].Position;
    }

    public void VaihdaKameraa(int suunta)
    {
        if (CamerasHaveBeenSet())
        {

            currentCameraIndex = (currentCameraIndex + suunta + cameras.Count) % cameras.Count;
            transform.position = cameras[currentCameraIndex].Position;
        }
    }

    private bool CamerasHaveBeenSet()
    {
        return cameras != null && cameras.Count > 0;
    }
}
