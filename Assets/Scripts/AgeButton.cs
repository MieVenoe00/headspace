using UnityEngine;

public class AgeButton : MonoBehaviour
{
    public string aldersgruppe; // sæt til "12-15", "16-19" eller "20-25"
    private SpriteRenderer sr;

    [Header("Sprites til forskellige tilstande")]
    public Sprite normalSprite;
    public Sprite selectedSprite;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = normalSprite;
    }

    void OnMouseDown()
    {
        AgeSelector.Instance.VælgAldersgruppe(this);
    }

    public void SætValgt(bool valgt)
    {
        sr.sprite = valgt ? selectedSprite : normalSprite;
    }
}