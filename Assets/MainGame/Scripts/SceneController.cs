using UnityEngine;
using GoogleARCore;


/*
Class to co-ordinate between ARCore and Unity.
*/

public class SceneController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        startTracking();
    }

    /// Tracking user movement's in real world. Once tracked, Frame Object will interact with ARCORE. 
    /// Making sure screen timeout is adjusted to stay on while tracking
    void startTracking()
    {
        if(Session.Status != SessionStatus.Tracking)
        {
            int lostTrackingSleepTimeout = 15;
            Screen.sleepTimeout = lostTrackingSleepTimeout;
            return; 
        }

        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }
}
