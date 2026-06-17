using UnityEngine;

public class NextArrowDialog : MonoBehaviour
{
    public GameObject text1;
    public GameObject text2;
    public GameObject text3;
    public GameObject nextArrow;
    public GameObject videreBtn;

    private int currentStep = 0; // 0 = text1 vises, 1 = text2 vises

    void OnMouseDown()
    {
        if (currentStep == 0)
        {
            // Skift fra Text1 til Text2
            text1.SetActive(false);
            text2.SetActive(true);
            currentStep = 1;
        }
        else if (currentStep == 1)
        {
            // Skift fra Text2 til Text3 + videreBtn, fjern nextArrow
            text2.SetActive(false);
            nextArrow.SetActive(false);
            text3.SetActive(true);
            videreBtn.SetActive(true);
            currentStep = 2;
        }
    }
}