using UnityEngine;
using System.Collections.Generic;

public class FeelingsManager : MonoBehaviour
{
    public static FeelingsManager Instance;
    public List<string> valgteFølelser = new List<string>();
    public int maxValg = 5;

    void Awake()
    {
        Instance = this;
    }

    public void SætKategori(string kategori, bool valgt)
    {
        if (valgt)
        {
            if (valgteFølelser.Count < maxValg)
            {
                valgteFølelser.Add(kategori);
            }
        }
        else
        {
            valgteFølelser.Remove(kategori);
        }

        Debug.Log("Valgte: " + string.Join(", ", valgteFølelser));
    }

    public bool HarValgtMindstEn()
    {
        return valgteFølelser.Count > 0;
    }
}