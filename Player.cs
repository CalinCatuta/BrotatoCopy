using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI healthText;

    Animator animator;
    Rigidbody2D rb;

    [SerializeField] float moveSpeed;
    int maxHealth = 100;
    int currentHealth;

    bool dead = false;

    float moveHorizontal, moveVertical;
    Vector2 movement;

    int facingDirection = 1; // right = 1, -1 = left

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        currentHealth = maxHealth;
        healthText.text = maxHealth.ToString();
        
    }

    void Update()
    {

        if (dead) { 
             movement = Vector2.zero;
             animator.SetFloat("velocity", 0);
             return;
        }

        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxisRaw("Vertical");

        movement = new Vector2(moveHorizontal, moveVertical).normalized;

        animator.SetFloat("velocity", movement.magnitude);

        if(movement.x != 0)
          facingDirection = movement.x > 0 ? 1 : -1;

          transform.localScale = new Vector2(facingDirection, 1);
        
    }
    private void FixedUpdate() {
        rb.velocity = movement * moveSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        if (enemy != null)
            Hit(20);
    }
    void Hit(int dmg) {
        animator.SetTrigger("hit");
        currentHealth -= dmg;
        healthText.text = Mathf.Clamp(currentHealth, 0, maxHealth).ToString();

        if (currentHealth <= 0) { Die(); }
    }

    void Die() {
        dead = true;
        // Call GameOver
        GameManager.instance.GameOver();
    }
}
