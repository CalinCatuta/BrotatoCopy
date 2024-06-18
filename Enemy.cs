
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int maxHealth = 100;
    [SerializeField] float speed = 2f;

    private int currentHealth;

    Animator animator;
    Transform target;

    private void Start() {
        currentHealth = maxHealth;
        target = GameObject.Find("Player").transform;
        animator = GetComponent<Animator>();
    }

    private void Update() {
        if (target != null) {
        Vector3 direction = target.position - transform.position;
            direction.Normalize();

            transform.position += direction * speed * Time.deltaTime;

            var playerToTheRight = target.position.x > transform.position.x;
            transform.localScale = new Vector2(playerToTheRight ? -1 : 1, 1);
        }
    }
    public void Hit(int dmg) {
        currentHealth -= dmg;
        animator.SetTrigger("hit");

        if (currentHealth <= 0)
            Destroy(gameObject);
    }
}
