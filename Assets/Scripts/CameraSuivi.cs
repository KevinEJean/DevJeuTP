using UnityEngine;

public class CameraSuivi : MonoBehaviour
{
    [SerializeField] private Transform cible;
    [SerializeField, Min(0.1f)] private float vitesseSuivi = 5f;
    [SerializeField] private Vector2 limiteMin = new(-8f, -4f);
    [SerializeField] private Vector2 limiteMax = new(8f, 4f);
    private SecousseCamera secousse;

    private void Awake()
    {
        secousse = GetComponent<SecousseCamera>();
    }

    private void LateUpdate()
    {
        if (cible == null) return;

        Vector3 destination = new(
            Mathf.Clamp(cible.position.x, limiteMin.x, limiteMax.x),
            Mathf.Clamp(cible.position.y, limiteMin.y, limiteMax.y),
            transform.position.z
        );

        if (secousse != null)
        {
            destination.x += secousse.Decalage.x;
            destination.y += secousse.Decalage.y;
        }

        transform.position = Vector3.Lerp(
            transform.position,
            destination,
            vitesseSuivi * Time.deltaTime
        );
    }
}
