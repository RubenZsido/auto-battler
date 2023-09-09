using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Entity parentEntity;
    public GameObject healthSliderPrefab;
    public Slider healthSlider;
    private void Start()
    {
        SetupHealthBar(EntityManager.Instance.healthBarCanvas);
    }
    public void SetupHealthBar(Canvas parentCanvas)
    {
        GameObject GO = Instantiate(healthSliderPrefab, parentCanvas.transform);
        healthSlider = GO.GetComponent<Slider>();
        float maxHealth = parentEntity.stats.GetStatValue(StatType.maxHealth);
        healthSlider.maxValue = maxHealth;
        healthSlider.value = maxHealth;
        parentEntity.events.floatEvents.GetListElement(FloatGameEventType.HealthChanged).RegisterListener(UpdateHealthBar);
        parentEntity.events.statEvents.GetListElement(StatGameEventType.StatChanged).RegisterListener(OnStatUpdated);
        GO.GetComponent<FollowTarget>().target = transform;
    }

    private void OnStatUpdated(StatType statType)
    {
        if (statType == StatType.maxHealth)
        {
            healthSlider.maxValue = parentEntity.stats.GetStatValue(StatType.maxHealth);
        }
    }
    private void UpdateHealthBar(float health)
    {
        healthSlider.value = health;
    }

    public void DestroyHealthBar()
    {
        Destroy(healthSlider.gameObject);
    }
}
