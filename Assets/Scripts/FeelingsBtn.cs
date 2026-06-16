using UnityEngine;

public class FeelingsBtn : MonoBehaviour
{
    public string kategoriNavn; // f.eks. "Angst" - bruges KUN til at identificere knappen i koden, ikke til visning
    public Sprite normalSprite;
    public Sprite valgtSprite;

    private SpriteRenderer sr;
    private bool erValgt = false;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = normalSprite;
    }

    void OnMouseDown()
    {
        erValgt = !erValgt;
        sr.sprite = erValgt ? valgtSprite : normalSprite;
        FeelingsManager.Instance.SætKategori(kategoriNavn, erValgt);
    }
}