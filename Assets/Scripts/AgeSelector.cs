using UnityEngine;

public class AgeSelector : MonoBehaviour
{
    public static AgeSelector Instance;
    public AgeButton[] alleKnapper;
    private AgeButton valgtKnap;

    void Awake()
    {
        Instance = this;
    }

    public void VælgAldersgruppe(AgeButton knap)
    {
        valgtKnap = knap;

        foreach (AgeButton b in alleKnapper)
        {
            b.SætValgt(b == knap);
        }

        GameManager.Instance.SætAldersgruppe(knap.aldersgruppe);
    }

    public bool HarValgt()
    {
        return valgtKnap != null;
    }
}