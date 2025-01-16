using Unity.VisualScripting.ReorderableList;
using UnityEngine;

public class Damage : MonoBehaviour
{

    enum damagetype{moving, stationary}
    [SerializeField] damagetype type;
    [SerializeField] Rigidbody rb;

    [SerializeField] int damageamount;
    [SerializeField] int speed;
    [SerializeField] int destroytime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(type == damagetype.moving)
        {
            rb.linearVelocity = transform.forward * speed;
            Destroy(gameObject, destroytime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.isTrigger)
            return;

        IDamage dmg = other.GetComponent<IDamage>();
        if(dmg != null)
        {
            dmg.takedamage(damageamount);
        }

        if(type == damagetype.moving)
        {
            Destroy(gameObject);
        }
    }
}
