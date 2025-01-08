using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{

    public float Maxhealth = 100;
    public float Currenthealth = 100;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(float damage)
    {
        Currenthealth -= damage;
        if (Currenthealth < 0 )
        {
            SceneManager.LoadScene(1);
        }
    }

    public void GetHeal(float heal)
    {
        if (heal + Currenthealth > Maxhealth)
        {
            Currenthealth = Maxhealth;
        }
        else
        {
            Currenthealth += heal;
        }
    }

}
