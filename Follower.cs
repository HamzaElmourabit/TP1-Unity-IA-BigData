using UnityEngine;

public class Follower : MonoBehaviour
{
    public Transform target; // à assigner = le joueur
    public float speed = 3f;

    void Update()
    {
        if (target == null) return;
        Vector3 direction = (target.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;
        transform.LookAt(target);
    }
}