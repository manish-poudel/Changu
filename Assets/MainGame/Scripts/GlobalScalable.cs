using UnityEngine;

/*
Component class to allow the stretching and pinching to scale objects.
*/
public class GlobalScalable : MonoBehaviour
{
    private Vector3 originalScale;
    static private float scaleFactor = 1.0f;
    public bool handleScaleInput = false;
    public bool adjustScale = true;
    private float speed = 1f;

    void Start()
    {
        /// Get object initial scale
        originalScale = transform.localScale;
    }


    void Update()
    {
        handleInputTouch();
    }

    /// Handle input touch by the user.
    void handleInputTouch()
    {
        /// Scale input is enabled
        if (handleScaleInput)
        {
            /// If user is touching screen with two fingers
            if (Input.touchCount == 2)
            {
                handleTwoInputTouch();
            }
        }
    }


    /// Handle if the input touch number is two.
    void handleTwoInputTouch()
    {
        /// Store both touches
        Touch touchZero = Input.GetTouch(0);
        Touch touchOne = Input.GetTouch(1);

        Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
        Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

        // Find the magnitude of the vector between the touches in current and previous frame
        float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
        float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

        /// Find the difference in the distances
        float deltaMagDiff = prevTouchDeltaMag - touchDeltaMag;

        // range is 1 to 1000.
        // The scale factor is v/100f meaning scale from 0.01 to 10.
        float v = scaleFactor * 100f;

        // negative delta is stretching, positive is pinching
        v -= deltaMagDiff * speed;

        scaleFactor = Mathf.Clamp(v, 1f, 1000f) / 100f;

        /// Adjust scale
        if(adjustScale)
        {
            transform.localScale = originalScale * scaleFactor;
        }
    }
}
