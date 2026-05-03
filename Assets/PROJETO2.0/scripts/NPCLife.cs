using UnityEngine;
using UnityEngine.UI;

public class NPCLife : MonoBehaviour
{

    public float vida = 100f;
    public Slider vidaSlider;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        vidaSlider.value = vida/100;
    }

    public void TakeDamage(float damage)
    {
        vida -= damage;
        if (vida <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject); // Destroi o objeto NPC
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            TakeDamage(20f);
            Destroy(collision.gameObject); // Destroi a bala após causar dano
        }
    }
}
