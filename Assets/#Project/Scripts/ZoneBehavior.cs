using UnityEngine;

public class ZoneBehavior : MonoBehaviour
{
    [SerializeField] AbstractBonus bonus;

    void Start()
    {
        bonus.ApplyColor(this);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerController player))
        {
            bonus.ApplyBonus(player);
            Destroy(gameObject);
        }
    }
}
