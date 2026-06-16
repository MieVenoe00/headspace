using UnityEngine;
using System.Collections.Generic;

public class FeelingManager : MonoBehaviour
{
    public static FeelingManager Instance;
    public List<string> valgteKategorier = new List<string>();
    public int maxValg = 5;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SætKategori(string kategori, bool valgt)
    {
        if (valgt)
        {
            if (valgteKategorier.Count < maxValg)
            {
                valgteKategorier.Add(kategori);
            }
        }
        else
        {
            valgteKategorier.Remove(kategori);
        }

        Debug.Log("Valgte kategorier: " + string.Join(", ", valgteKategorier));
    }
}