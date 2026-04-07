using UnityEngine;

public class Health : MonoBehaviour
{
    [HideInInspector] public float currentHealth;
    public float maxHealth;
    public AudioClip takeDamageSound;
    public AudioClip healSound;
    private AudioSource audioSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Get the audioSource
        audioSource = GetComponent<AudioSource>();

        // Tanks ALWAYS start at maxHealth
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage (float amount)
    {
        currentHealth = currentHealth - amount;

        // Play sound
        if (healSound != null)
        {
            audioSource.PlayOneShot(takeDamageSound);
        }

        // Keep health between 0 and max
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        // Check for Death
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal ( float amount )
    {
        // Add to our current health
        currentHealth += amount;

        // Play sound
        if (healSound != null)
        {
            audioSource.PlayOneShot(healSound);
        }

        // Keep health between 0 and max
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        // Check for Death
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die ()
    {
        Debug.Log(gameObject.name + " has moved on to a better place.");
        Destroy(gameObject);
    }



}
