using UnityEngine;

public class ClickableObject : MonoBehaviour
{
    private Renderer objRenderer;

    void Start()
    {
        objRenderer = GetComponent<Renderer>();
    }

    void OnMouseDown()
    {
        // Change la couleur aléatoirement
        objRenderer.material.color = new Color(Random.value, Random.value, Random.value);
        Debug.Log("Cliqué sur : " + gameObject.name);
        
        // Appelle le DataLogger (qui sera créé à la partie 4)
        DataLogger.Instance?.RegisterClick(gameObject.name);
    }
}