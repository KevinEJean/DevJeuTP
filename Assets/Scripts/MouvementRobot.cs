using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MouvementRobot : MonoBehaviour
{
    [SerializeField] private float vitesse = 5f;
    [SerializeField] private Animator anim;

    private Rigidbody2D corps;
    private Vector2 direction;

    private void Awake()
    {
        corps = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // TODO 1 : lire les axes Horizontal et Vertical.
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        // TODO 2 : créer et normaliser le vecteur direction.
        direction = new Vector2(horizontal, vertical).normalized;

        if (direction != Vector2.zero) anim.SetBool("isMoving", true);
        else anim.SetBool("isMoving", false);
    }

    private void FixedUpdate()
    {
        // TODO 3 : déplacer le Rigidbody2D selon la direction et la vitesse.
        corps.MovePosition(corps.position + direction * vitesse * Time.fixedDeltaTime);
    }

    /*
     * BANQUE DE LIGNES — À REPLACER DANS LE BON ORDRE
     *
     * float vertical = Input.GetAxisRaw("Vertical");
     * corps.MovePosition(corps.position + direction * vitesse * Time.fixedDeltaTime);
     * direction = new Vector2(horizontal, vertical).normalized;
     * float horizontal = Input.GetAxisRaw("Horizontal");
     */
}

