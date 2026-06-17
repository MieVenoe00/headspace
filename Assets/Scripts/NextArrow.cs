using UnityEngine;

public class NextArrowButton : MonoBehaviour
{
    public DialogManager dialogManager;

    void OnMouseDown()
    {
        dialogManager.NæsteSide();
    }
}