using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    // Points de vie maximum de l'ennemi
    [SerializeField] private int maxHealth = 100;

    // Points de vie actuels de l'ennemi
    [SerializeField] private int currentHealth;

    public SecondDoor SecondDoor;
    public ActualDoor ActualDoor;
    public bool isBoss;

    // �v�nement d�clench� lorsque l'ennemi meurt
    public delegate void EnemyDeathHandler();

    private void Start()
    {
        // Initialisation des points de vie au maximum

        currentHealth = maxHealth;
    }

    private void Update()
    {

    }

    // M�thode pour infliger des d�g�ts � l'ennemi
    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        // V�rifie si les PV sont � 0 ou moins
        if (currentHealth <= 0)
        {
            if (isBoss) 
            {
                ActualDoor.ActualOpen();
                SecondDoor.OpenDoor();
            }
            Die();
        }
    }

    // M�thode pour soigner l'ennemi
    public void Heal(int healAmount)
    {
        currentHealth += healAmount;

        // Limite les PV � leur maximum
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

    }

    // M�thode appel�e lorsque l'ennemi meurt
    private void Die()
    {
        // D�sactive ou d�truit l'objet
        Destroy(gameObject);
    }

    // Getter pour obtenir les PV actuels
    public int GetCurrentHealth()
    {
        return currentHealth;
    }
}
