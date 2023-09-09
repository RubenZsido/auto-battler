using TMPro;
using UnityEngine;

public class EntityDamageNumbers : MonoBehaviour
{
    public Entity parentEntity;
    public TMP_Text textPrefab;
    public Canvas parentCanvas;
    public Color damgaedColor = Color.red;
    public Color healedColor = Color.green;
    public float randomness;

    private void Start()
    {
        parentCanvas = EntityManager.Instance.healthBarCanvas;
        parentEntity.events.floatEntityEvents.GetListElement(FloatEntityGameEventType.Damaged).RegisterListener(OnDamaged);
        parentEntity.events.floatEntityEvents.GetListElement(FloatEntityGameEventType.Healed).RegisterListener(OnHealed);
    }

    private void OnDamaged(float value, Entity attacker)
    {
        Vector3 pos = parentEntity.transform.position;
        pos += Vector3.up * Random.Range(-randomness, randomness);
        pos += Vector3.left * Random.Range(-randomness, randomness);
        TMP_Text textClone = Instantiate(textPrefab, pos, Quaternion.identity, parentCanvas.transform);
        textClone.text = value.ToString();
        textClone.color = damgaedColor;

    }
    private void OnHealed(float value, Entity attacker)
    {
        TMP_Text textClone = Instantiate(textPrefab, parentEntity.transform.position, Quaternion.identity, parentCanvas.transform);
        textClone.text = "+" + value.ToString();
        textClone.color = damgaedColor;
    }


}
