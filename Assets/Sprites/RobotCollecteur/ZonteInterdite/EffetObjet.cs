// using UnityEngine;

// public class EffetObjet : MonoBehaviour
// {
//     // Variables de configuration ajustables dans l'Inspecteur
//     public float vitesseRotation = 50f;
//     public float amplitudeLevitation = 0.5f;
//     public float vitesseLevitation = 2f;

//     [Header("Changement de couleur")]
//     public Renderer renduObjet;
//     public Color couleurA = Color.cyan;
//     public Color couleurB = Color.magenta;
//     public float vitesseCouleur = 1f;

//     private Vector3 positionInitiale;
//     private Material materiauObjet;

//     void Start()
//     {
//         // 1. Récupérer la position de départ via le Transform
//         positionInitiale = transform.position;

//         // Trouver automatiquement le Renderer s'il n'est pas assigné.
//         if (renduObjet == null)
//         {
//             renduObjet = GetComponentInChildren<Renderer>();
//         }

//         // renderer.material crée une instance propre à cet objet.
//         if (renduObjet != null)
//         {
//             materiauObjet = renduObjet.material;
//         }
//     }

//     void Update()
//     {
//         // 2. Effet de rotation continue sur l'axe Y
//         transform.Rotate(Vector3.up * vitesseRotation * Time.deltaTime);

//         // 3. Effet de lévitation en calculant un décalage sinusoïdal
//         float nouvelY = positionInitiale.y + Mathf.Sin(Time.time * vitesseLevitation) * amplitudeLevitation;
        
//         // 4. Appliquer la nouvelle position au Transform
//         transform.position = new Vector3(transform.position.x, nouvelY, transform.position.z);

//         // 5. Faire varier progressivement la couleur entre A et B.
//         if (materiauObjet != null)
//         {
//             float interpolation = (Mathf.Sin(Time.time * vitesseCouleur) + 1f) / 2f;
//             materiauObjet.color = Color.Lerp(couleurA, couleurB, interpolation);
//         }
//     }
// }


// using UnityEngine;

// public class EffetObjet : MonoBehaviour
// {
//     // Variables de configuration ajustables dans l'Inspecteur
//     public float vitesseRotation = 50f;
//     public float amplitudeLevitation = 0.5f;
//     public float vitesseLevitation = 2f;

//     [Header("Changement de couleur")]
//     public Renderer renduObjet;
//     public Color couleurA = Color.cyan;
//     public Color couleurB = Color.magenta;
//     public float vitesseCouleur = 1f;

//     private Vector3 positionInitiale;
//     private Material materiauObjet;

//     void Start()
//     {
//         // 1. Récupérer la position de départ via le Transform
//         positionInitiale = transform.position;

//         // Trouver automatiquement le Renderer s'il n'est pas assigné.
//         if (renduObjet == null)
//         {
//             renduObjet = GetComponentInChildren<Renderer>();
//         }

//         // renderer.material crée une instance propre à cet objet.
//         if (renduObjet != null)
//         {
//             materiauObjet = renduObjet.material;
//         }
//     }

//     void Update()
//     {
//         // 2. Effet de rotation continue sur l'axe Y
//         transform.Rotate(Vector3.up * vitesseRotation * Time.deltaTime);

//         // 3. Effet de lévitation en calculant un décalage sinusoïdal
//         float nouvelY = positionInitiale.y + Mathf.Sin(Time.time * vitesseLevitation) * amplitudeLevitation;
        
//         // 4. Appliquer la nouvelle position au Transform
//         transform.position = new Vector3(transform.position.x, nouvelY, transform.position.z);

//         // 5. Faire varier progressivement la couleur entre A et B.
//         if (materiauObjet != null)
//         {
//             float interpolation = (Mathf.Sin(Time.time * vitesseCouleur) + 1f) / 2f;
//             materiauObjet.color = Color.Lerp(couleurA, couleurB, interpolation);
//         }
//     }
// }


using UnityEngine;

public class EffetObjet : MonoBehaviour
{
    // Variables de configuration ajustables dans l'Inspecteur
    [Header("Mouvement de danse")]
    public float angleDanse = 15f;
    public float vitesseRotation = 3f;
    public float amplitudeLevitation = 0.5f;
    public float vitesseLevitation = 2f;

    [Header("Changement de couleur")]
    public Renderer renduObjet;
    public Color couleurA = Color.cyan;
    public Color couleurB = Color.magenta;
    public float vitesseCouleur = 1f;

    private Vector3 positionInitiale;
    private Quaternion rotationInitiale;
    private Material materiauObjet;

    void Start()
    {
        // 1. Récupérer la position de départ via le Transform
        positionInitiale = transform.position;
        rotationInitiale = transform.rotation;

        // Trouver automatiquement le Renderer s'il n'est pas assigné.
        if (renduObjet == null)
        {
            renduObjet = GetComponentInChildren<Renderer>();
        }

        // renderer.material crée une instance propre à cet objet.
        if (renduObjet != null)
        {
            materiauObjet = renduObjet.material;
        }
    }

    void Update()
    {
        // 2. Mouvement de va-et-vient autour de l'axe Z, comme une danse.
        float angleActuel = Mathf.Sin(Time.time * vitesseRotation) * angleDanse;
        transform.rotation = rotationInitiale * Quaternion.Euler(0f, 0f, angleActuel);

        // 3. Effet de lévitation en calculant un décalage sinusoïdal
        float nouvelY = positionInitiale.y + Mathf.Sin(Time.time * vitesseLevitation) * amplitudeLevitation;
        
        // 4. Appliquer la nouvelle position au Transform
        transform.position = new Vector3(transform.position.x, nouvelY, transform.position.z);

        // 5. Faire varier progressivement la couleur entre A et B.
        if (materiauObjet != null)
        {
            float interpolation = (Mathf.Sin(Time.time * vitesseCouleur) + 1f) / 2f;
            materiauObjet.color = Color.Lerp(couleurA, couleurB, interpolation);
        }
    }
}
