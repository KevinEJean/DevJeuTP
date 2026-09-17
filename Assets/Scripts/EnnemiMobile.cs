using UnityEngine;
using static EnnemiMobile;

public class Ennemy : MonoBehaviour
{
    public enum TypeDeplacement
    {
        Patrouille,
        Sinusoidal
    }

    [SerializeField] private TypeDeplacement typeDeplacement;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
