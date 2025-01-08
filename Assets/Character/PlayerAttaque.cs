using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerAttaque : MonoBehaviour
{
    public float AttackDamageValue = 25;
    public Collider HitZone;
    [SerializeField] private List <EnemyHealth> enemyAIList;
    public MeshRenderer RendererAttack;
    private bool canAttack = true;
    public float cooldown = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Attack());
        VerifEnemyList();
    }

    public IEnumerator Attack()
    {
        if (canAttack)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                canAttack = false;
                RendererAttack.enabled = true;

                if (enemyAIList.Count > 0)
                {
                    foreach (EnemyHealth ai in enemyAIList)
                    {
                        ai.TakeDamage(Mathf.RoundToInt(AttackDamageValue));
                    }
                }
                
                yield return new WaitForSeconds(cooldown);
                canAttack = true;
                RendererAttack.enabled = false;
            }
        }
    }

    void VerifEnemyList()
    {
        foreach (EnemyHealth ai in enemyAIList)
        {
            if (ai.IsDestroyed())
            {
                enemyAIList.Remove(ai);
            }

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent<EnemyHealth>(out EnemyHealth enemy))
        {
            enemyAIList.Add(enemy);
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent<EnemyHealth>(out EnemyHealth enemy))
        {
            enemyAIList.Remove(enemy);
        }
    }

    private void OnTriggerStay(Collider other)
    {

    }
}
