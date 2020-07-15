using UnityEngine;
using GoogleARCore;
/*
Class to co-ordinate between ARCore and Unity.
*/
public class SceneController : MonoBehaviour
{

    public AssetController assetController;
    void Start()
    {

    }

    void Update()
    {
        StartTracking();
        ProcessTouch();
    }

    /// Tracking user movement's in real world. Once tracked, Frame Object will interact with ARCore. 
    /// Making sure screen timeout is adjusted to stay on while tracking.
    void StartTracking()
    {
        if (Session.Status != SessionStatus.Tracking)
        {
            int lostTrackingSleepTimeout = 15;
            Screen.sleepTimeout = lostTrackingSleepTimeout;
            return;
        }

        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }


    /// Process touch from the user
    void ProcessTouch()
    {
        Touch touch;
        if (Input.touchCount != 1 ||
            (touch = Input.GetTouch(0)).phase != TouchPhase.Began)
        {
            return;
        }

        TrackableHit hit;
        TrackableHitFlags raycastFilter =
            TrackableHitFlags.PlaneWithinBounds |
            TrackableHitFlags.PlaneWithinPolygon;

        if (Frame.Raycast(touch.position.x, touch.position.y, raycastFilter, out hit))
        {
            SetSelectedPlane(hit.Trackable as DetectedPlane);
        }
    }


    /// Setting the selected plane
    void SetSelectedPlane(DetectedPlane selectedPlane)
    {
       assetController.SetSelectedPlane(selectedPlane);
    }
}
