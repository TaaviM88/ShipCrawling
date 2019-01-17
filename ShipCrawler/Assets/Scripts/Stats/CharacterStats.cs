using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    //public int MaxHealth = 100;
    public int currentHealth { get; private set; }
    public Stat maxHealth;

    public Stat damage;
    public Stat armor;

    //public event System.Action<int, int> OnHealthReachedZero;
    public event System.Action OnHealthReachedZero;

    // Start is called before the first frame update
    public virtual void Awake()
    {
        currentHealth = maxHealth.Getvalue();
    }

    public virtual void Start()
    {

    }

    public void TakeDamage(int damage)
    {
        // Subtract the armor value
        damage -= armor.Getvalue(); //lisää tää heti kun armor tsydeemi on tehty. Comment
        damage = Mathf.Clamp(damage, 0, int.MaxValue);

        // Damage the character
        currentHealth -= damage;

        // If health reaches zero
        if (currentHealth <= 0)
        {
            //Die();

            if (OnHealthReachedZero != null)
            {
                OnHealthReachedZero();
            }
        }

    }

    public virtual void Die()
    {
        // Die in some way
        // This method is meant to be overwritten
        Debug.Log(transform.name + " died.");
    }

    // Heal the character.
    public void Heal(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth.Getvalue());
    }
}
