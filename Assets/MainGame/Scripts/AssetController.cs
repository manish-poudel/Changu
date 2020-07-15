using UnityEngine;
using GoogleARCore;
using System.Collections;
using System.Collections.Generic;

public class AssetController : MonoBehaviour
{

    private GameObject assetInstance;
    private DetectedPlane detectedPlane;
    public GameObject donutPrefab;
    public bool spawn = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        StartTracking();
    }


    /// Set selected plane. This method is called from Scene controller when user taps in the plane
    public void SetSelectedPlane(DetectedPlane detectedPlane)
    {
        this.detectedPlane = detectedPlane;
        if (spawn)
        {
            SpawnAsset();
        }
    }


    /// Create anchor to place the asset fixed in the position despite camera movement
    void SpawnAsset()
    {
        if (assetInstance != null)
        {
            DestroyImmediate(assetInstance);
        }


        Anchor anchor = detectedPlane.CreateAnchor(new Pose(detectedPlane.CenterPose.position, Quaternion.identity));
        assetInstance = Instantiate(donutPrefab, detectedPlane.CenterPose.position, Quaternion.identity, anchor.transform);
        assetInstance.transform.localScale = new Vector3(10f, 10f, 10f);
        assetInstance.transform.SetParent(anchor.transform);
    }

    void StartTracking()
    {
        // If there is no plane, then return
        if (detectedPlane == null)
        {
            return;
        }

        // Check for the plane being subsumed.
        // If the plane has been subsumed switch attachment to the subsuming plane.
        while (detectedPlane.SubsumedBy != null)
        {
            detectedPlane = detectedPlane.SubsumedBy;
        }

    }

}
