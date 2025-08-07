using UnityEngine;
using UnityEngine.UI;

public class FollowWheelText : MonoBehaviour
{
    private Transform rollerClamp; // No longer public, as it's not assigned in Inspector
    private Camera mainCamera;
    private RectTransform rectTransform;

    void Start()
    {
        mainCamera = Camera.main;
        rectTransform = GetComponent<RectTransform>();

        // Dynamically find the RollerClamp GameObject by name
        GameObject rollerClampObj = GameObject.Find("RollerClamp");
        if (rollerClampObj != null)
        {
            rollerClamp = rollerClampObj.transform;
        }
        else
        {
            Debug.LogWarning("RollerClamp GameObject not found in the scene!");
        }

        if (mainCamera == null)
        {
            Debug.LogError("Camera not found!");
        }
    }

    void LateUpdate()
    {
        if (rollerClamp != null && mainCamera != null)
        {
            Vector3 screenPos = mainCamera.WorldToScreenPoint(rollerClamp.position);
            screenPos.x += 100f;
            rectTransform.position = screenPos;
        }
    }
}