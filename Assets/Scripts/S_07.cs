using TMPro;
using UnityEngine;

public class MinuterieJeu : MonoBehaviour
{
    [Header("Configuration")]
    [SerializeField] private float dureeDepart = 120f;

    [Header("Interface")]
    [SerializeField] private TMP_Text texteTimer;

    private float tempsRestant;
    private bool minuterieActive = true;

    private void Start()
    {
        tempsRestant = dureeDepart;
        ActualiserAffichage();
    }

    private void Update()
    {
        if (!minuterieActive)
            return;

        tempsRestant -= Time.deltaTime;

        if (tempsRestant <= 0f)
        {
            tempsRestant = 0f;
            minuterieActive = false;
            TempsEcoule();
        }

        ActualiserAffichage();
    }

    private void ActualiserAffichage()
    {
        int minutes = Mathf.FloorToInt(tempsRestant / 60f);
        int secondes = Mathf.FloorToInt(tempsRestant % 60f);

        texteTimer.text = $"{minutes:00}:{secondes:00}";

        if (tempsRestant <= 10f)
            texteTimer.color = new Color(1f, 0.25f, 0.25f);
        else if (tempsRestant <= 30f)
            texteTimer.color = new Color(1f, 0.75f, 0.2f);
        // else
        //     texteTimer.color = Color.white;
    }

    private void TempsEcoule()
    {
        Debug.Log("Temps écoulé!");
        GestionJeu.Instance?.TempsEcoule();
    }
}
