using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "Bonus", menuName = "Scriptable Objects/Bonus")]
public class Bonus : AbstractBonus
{
    [SerializeField] private float speedBonus = 1f;
    [SerializeField] private float scaleBonus = 1f;
    [SerializeField] private Color bonusColor = Color.white;
    [SerializeField][Tooltip("If duration is negative, bonus lasts indefinitely.")] private float duration = -1f;

    public override void ApplyColor(ZoneBehavior zone)
    {
        zone.GetComponent<Renderer>().material.color = bonusColor;
    }

    public override void ApplyBonus(PlayerController player)
    {
        // a cleaner code would make the player responsible for applying these changes.
        // This would call a function in Player and give it the necessary info.
        // Player would also store its initial speed and scale values.
        if (duration >= 0) player.StartCoroutine(RemoveBonus(player, player.transform.localScale, player.MoveSpeed));
        player.MoveSpeed *= speedBonus;
        player.transform.localScale *= scaleBonus;
    }

    private IEnumerator RemoveBonus(PlayerController player, Vector3 scale, float speed)
    {
        yield return new WaitForSeconds(duration);
        player.MoveSpeed = speed;
        player.transform.localScale = scale;
    }
}