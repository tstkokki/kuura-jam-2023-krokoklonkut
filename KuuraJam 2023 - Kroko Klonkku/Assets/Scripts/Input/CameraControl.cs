using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{

    [SerializeField] List<Vector3Variable> cameras;

    [SerializeField]
    IntVariable currentCameraIndex;
    // Start is called before the first frame update
    void Start()
    {
        currentCameraIndex.Value = 0;
        if (CamerasHaveBeenSet())
            transform.position = cameras[currentCameraIndex.Value].Position;
    }

    public void VaihdaKameraa(int suunta)
    {
        if (CamerasHaveBeenSet())
        {

            currentCameraIndex.Value = (currentCameraIndex.Value + suunta + cameras.Count) % cameras.Count;
            transform.position = cameras[currentCameraIndex.Value].Position;
        }
    }

    private bool CamerasHaveBeenSet()
    {
        return cameras != null && cameras.Count > 0;
    }
}
