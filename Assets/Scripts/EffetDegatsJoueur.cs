using System.Collections;
using UnityEngine;

public class EffetDegatsJoueur : MonoBehaviour
{
    public static EffetDegatsJoueur Instance { get; private set; }


    [Header("Robot")]
    [SerializeField] private SpriteRenderer renduRobot;

    [Header("Interface")]
    [SerializeField] private CanvasGroup flashEcran;

    [Header("Animation")]
    [SerializeField] private Color couleurDegat =
        new Color(1f, 0.25f, 0.25f);

    [SerializeField] private float dureeEffet = 0.45f;
    [SerializeField] private int nombreClignotements = 3;
    [SerializeField] private float agrandissement = 1.12f;

    private Coroutine animationEnCours;
    private Color couleurInitiale;
    private Vector3 tailleInitiale;

    private void Awake()
    {
        // TODO 1 : récupérer le SpriteRenderer s'il n'est pas assigné.
        if (renduRobot == null) renduRobot = GetComponent<SpriteRenderer>();

        // TODO 2 : mémoriser la couleur et la taille initiales.
        couleurInitiale = renduRobot.color;
        tailleInitiale = transform.localScale;

        // TODO 3 : cacher le flash au lancement.
        if (flashEcran != null) flashEcran.alpha = 0f;
    }

    public void JouerEffetDegat()
    {
        // TODO 4 : arrêter l'animation précédente, si elle existe.
        if (animationEnCours != null) 
        {
            StopCoroutine(animationEnCours);
            animationEnCours = null;
        }

        // TODO 5 : démarrer la coroutine de dégâts.
        animationEnCours = StartCoroutine(AnimerDegat());
    }

    private IEnumerator AnimerDegat()
    {
        // TODO 6 : calculer la durée d'un clignotement.
        float dureeClignotement = dureeEffet / (nombreClignotements * 2f);
        float progression = 0f;

        while (progression < 1f) 
        {
            for (int i = 0; i < nombreClignotements; i++) 
            {
                progression += Time.deltaTime / 0.2f;

                // TODO 7 : afficher le flash.
                flashEcran.alpha = 0.35f;

                // TODO 8 : faire clignoter et agrandir le robot.
                transform.localScale = tailleInitiale * agrandissement;

                yield return new WaitForSeconds(dureeClignotement);
            }
            yield return null;
        }

        // TODO 9 : faire disparaître progressivement le flash.
        flashEcran.alpha = Mathf.Lerp(0.35f, 0f, progression);

        // TODO 10 : restaurer l'apparence et terminer proprement.
        renduRobot.color = couleurInitiale;
        transform.localScale = tailleInitiale;
        
        yield break;
    }

    /*
     * BANQUE DE LIGNES — À REPLACER ET À INDENTER
     *
     * Toutes les lignes de la solution sont présentes.
     * Supprimez « yield break; » lorsque la coroutine est complétée.
     * Ajoutez les accolades des if, de la boucle for et de la boucle while.
     *
     * renduRobot.color = couleurInitiale;
     * if (flashEcran != null)
     * progression += Time.deltaTime / 0.2f;
     * animationEnCours = StartCoroutine(AnimerDegat());
     * yield return new WaitForSeconds(dureeClignotement);
     * tailleInitiale = transform.localScale;
     * for (int i = 0; i < nombreClignotements; i++)
     * flashEcran.alpha = Mathf.Lerp(0.35f, 0f, progression);
     * renduRobot = GetComponent<SpriteRenderer>();
     * animationEnCours = null;
     * float progression = 0f;
     * transform.localScale = tailleInitiale * agrandissement;
     * if (animationEnCours != null)
     * flashEcran.alpha = 0f;
     * couleurInitiale = renduRobot.color;
     * if (renduRobot == null)
     * renduRobot.color = couleurDegat;
     * StopCoroutine(animationEnCours);
     * float dureeClignotement = dureeEffet / (nombreClignotements * 2f);
     * yield return null;
     * if (flashEcran != null)
     * transform.localScale = tailleInitiale;
     * while (progression < 1f)
     * flashEcran.alpha = 0.35f;
     * yield return new WaitForSeconds(dureeClignotement);
     * if (flashEcran != null)
     * renduRobot.color = couleurInitiale;
     * transform.localScale = tailleInitiale;
     * if (flashEcran != null)
     * flashEcran.alpha = 0f;
     */
}
