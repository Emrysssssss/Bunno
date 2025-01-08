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

    // Événement déclenché lorsque l'ennemi meurt
    public delegate void EnemyDeathHandler();

    private void Start()
    {
        // Initialisation des points de vie au maximum

        currentHealth = maxHealth;
    }

    private void Update()
    {

    }

    // Méthode pour infliger des dégâts à l'ennemi
    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        // Vérifie si les PV sont à 0 ou moins
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

    // Méthode pour soigner l'ennemi
    public void Heal(int healAmount)
    {
        currentHealth += healAmount;

        // Limite les PV à leur maximum
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

    }

    // Méthode appelée lorsque l'ennemi meurt
    private void Die()
    {
        // Désactive ou détruit l'objet
        Destroy(gameObject);
    }

    // Getter pour obtenir les PV actuels
    public int GetCurrentHealth()
    {
        return currentHealth;
    }
}
