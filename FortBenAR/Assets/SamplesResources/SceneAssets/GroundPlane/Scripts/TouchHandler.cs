/*============================================================================== 
Copyright (c) 2018 PTC Inc. All Rights Reserved.

Vuforia is a trademark of PTC Inc., registered in the United States and other 
countries.   
==============================================================================*/

using System;
using TouchScript.InputSources;
using TouchScript.Pointers;
using UnityEngine;

public class TouchHandler : MonoBehaviour
{
    #region PUBLIC_MEMBERS

    public Transform augmentationObject;

    [HideInInspector]
    public bool enableRotation;
    public bool enablePinchScaling;

    public static bool DoubleTap
    {
        get { return (Input.touchSupported) && Input.touches[0].tapCount == 2; }
    }

    public static bool IsSingleFingerStationary
    {
        get { return IsSingleFingerDown() && (Input.touches[0].phase == TouchPhase.Stationary); }
    }

    public static bool IsSingleFingerDragging
    {
        get { return IsSingleFingerDown() && (Input.touches[0].phase == TouchPhase.Moved); }
    }

    public ICoordinatesRemapper CoordinatesRemapper { get; internal set; }

    #endregion // PUBLIC MEMBERS


    #region PRIVATE_MEMBERS
    const float ScaleRangeMin = 0.1f;
    const float ScaleRangeMax = 2.0f;

    Touch[] touches;
    static int lastTouchCount;
    bool isFirstFrameWithTwoTouches;
    float cachedTouchAngle;
    float cachedTouchDistance;
    float cachedAugmentationScale;
    Vector3 cachedAugmentationRotation;
    private Action<Pointer> addPointer;
    private Action<Pointer> updatePointer;
    private Action<Pointer> pressPointer;
    private Action<Pointer> releasePointer;
    private Action<Pointer> removePointer;
    private Action<Pointer> cancelPointer;

    public TouchHandler(Action<Pointer> addPointer, Action<Pointer> updatePointer, Action<Pointer> pressPointer, Action<Pointer> releasePointer, Action<Pointer> removePointer, Action<Pointer> cancelPointer)
    {
        this.addPointer = addPointer;
        this.updatePointer = updatePointer;
        this.pressPointer = pressPointer;
        this.releasePointer = releasePointer;
        this.removePointer = removePointer;
        this.cancelPointer = cancelPointer;
    }
    #endregion // PRIVATE_MEMBERS


    #region MONOBEHAVIOUR_METHODS

    void Start()
    {
        this.cachedAugmentationScale = this.augmentationObject.localScale.x;
        this.cachedAugmentationRotation = this.augmentationObject.localEulerAngles;
    }

    void Update()
    {
        this.touches = Input.touches;

        if (Input.touchCount == 2)
        {
            float currentTouchDistance = Vector2.Distance(this.touches[0].position, this.touches[1].position);
            float diff_y = this.touches[0].position.y - this.touches[1].position.y;
            float diff_x = this.touches[0].position.x - this.touches[1].position.x;
            float currentTouchAngle = Mathf.Atan2(diff_y, diff_x) * Mathf.Rad2Deg;

            if (this.isFirstFrameWithTwoTouches)
            {
                this.cachedTouchDistance = currentTouchDistance;
                this.cachedTouchAngle = currentTouchAngle;
                this.isFirstFrameWithTwoTouches = false;
            }

            float angleDelta = currentTouchAngle - this.cachedTouchAngle;
            float scaleMultiplier = (currentTouchDistance / this.cachedTouchDistance);
            float scaleAmount = this.cachedAugmentationScale * scaleMultiplier;
            float scaleAmountClamped = Mathf.Clamp(scaleAmount, ScaleRangeMin, ScaleRangeMax);

            if (this.enableRotation)
            {
                this.augmentationObject.localEulerAngles = this.cachedAugmentationRotation - new Vector3(0, angleDelta * 3f, 0);
            }
            if (this.enableRotation && this.enablePinchScaling)
            {
                // Optional Pinch Scaling can be enabled via Inspector for this Script Component
                this.augmentationObject.localScale = new Vector3(scaleAmountClamped, scaleAmountClamped, scaleAmountClamped);
            }

        }
        else if (Input.touchCount < 2)
        {
            this.cachedAugmentationScale = this.augmentationObject.localScale.x;
            this.cachedAugmentationRotation = this.augmentationObject.localEulerAngles;
            this.isFirstFrameWithTwoTouches = true;
        }
        else if (Input.touchCount == 6)
        {
            // enable runtime testing of pinch scaling
            this.enablePinchScaling = true;
        }
        else if (Input.touchCount == 5)
        {
            // disable runtime testing of pinch scaling
            this.enablePinchScaling = false;
        }
    }

    #endregion // MONOBEHAVIOUR_METHODS


    #region PRIVATE_METHODS

    static bool IsSingleFingerDown()
    {
        if (Input.touchCount == 0 || Input.touchCount >= 2)
            lastTouchCount = Input.touchCount;

        return (
            Input.touchCount == 1 &&
            Input.touches[0].fingerId == 0 &&
            lastTouchCount == 0);
    }

    internal bool UpdateInput()
    {
        throw new NotImplementedException();
    }

    internal void UpdateResolution()
    {
        throw new NotImplementedException();
    }

    internal bool CancelPointer(Pointer pointer, bool shouldReturn)
    {
        throw new NotImplementedException();
    }

    internal void Dispose()
    {
        throw new NotImplementedException();
    }

    #endregion // PRIVATE_METHODS

}