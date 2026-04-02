using UnityEngine;

public static class JoystickUtils
{
    public static Vector3 GetTouchPosition(int touchID)
    {
        Vector3 touchPosition = Vector3.zero;

#if UNITY_IOS || UNITY_ANDROID && !UNITY_EDITOR
        touchPosition = Input.GetTouch(touchID).position;
#else
        touchPosition = Input.mousePosition;
#endif

        return touchPosition;
    }
}