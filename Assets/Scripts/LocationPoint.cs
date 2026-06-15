using UnityEngine;

public class LocationPoint : MonoBehaviour
{
    [Header("Destination Kiko går hen til")]
    public Transform destination;

    [Header("Navn på scene der åbner")]
    public string sceneName;

    [Header("Reference til Kiko")]
    public CharacterMovement kiko;

    void OnMouseDown()
    {
        kiko.GoToLocation(destination.position, sceneName);
    }
}