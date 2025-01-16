using System.Collections;
using UnityEngine;

public class EnemyAI : MonoBehaviour, IDamage
{
    [SerializeField] Renderer model;

    [SerializeField] int hp;

    Color colororig;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        colororig = model.material.color;
        GameManager.instance.updategamegoal(1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void takedamage(int amount)
    {
        hp -= amount;

        StartCoroutine(flashRed());

        if (hp <= 0)
        {
            GameManager.instance.updategamegoal(-1);
            Destroy(gameObject);
        }
    }

    IEnumerator flashRed()
    {
        model.material.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        model.material.color = colororig;
    }
}
