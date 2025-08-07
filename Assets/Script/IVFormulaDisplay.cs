using UnityEngine;
using TMPro;

public class IVFormulaDisplay : MonoBehaviour
{
    public WheelController wheelController; // Reference to wheel controller
    public TextMeshProUGUI formulaText; // Assign IVFormulaText (TextMeshProUGUI)
    public float maxFlowRate = 1500f; // Max flow rate in mL/hour at 100%
    private Camera mainCamera;
    private RectTransform rectTransform;

    void Start()
    {
        mainCamera = Camera.main;
        rectTransform = GetComponent<RectTransform>();
        if (wheelController == null)
        {
            Debug.LogWarning("WheelController is not assigned in IVFormulaDisplay!");
            wheelController = FindObjectOfType<WheelController>();
        }
        if (formulaText == null)
        {
            Debug.LogError("IVFormulaText is not assigned in IVFormulaDisplay!");
        }

        if (mainCamera == null)
        {
            Debug.LogError("Main Camera not found!");
        }
        UpdateFormulaText();
    }

    void LateUpdate()
    {
        UpdateFormulaText();
    }

    void UpdateFormulaText()
    {
        if (wheelController == null || formulaText == null)
        {
            return;
        }
        // Get percentage (0% at zMax, 100% at zMin)
        float t = (wheelController.transform.localPosition.z - wheelController.zMin) / (wheelController.zMax - wheelController.zMin);
        float percentage = Mathf.Lerp(100f, 0f, t);
        // Calculate flow rate (mL/hour)
        float flowRate = (percentage / 100f) * maxFlowRate;
        formulaText.text = $"Flow Rate: {flowRate:F0} mL/h";
        Debug.Log($"IVFormulaText updated: {formulaText.text}, Percentage: {percentage:F1}%");
    }
}