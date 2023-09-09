using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AbilityCard : MonoBehaviour
{
    [InlineEditor]
    [OnValueChanged("Init")]
    public Ability ability;

    public TMP_Text costText;
    public TMP_Text titleText;
    public Image cardImage;
    public TMP_Text descriptionText;
    public TMP_Text rarityText;
    //public Transform factionGroup;
    //public GameObject factionTextHolderPrefab;
    //public TMP_Text typeText;
    [Button("Init")]
    private void Start()
    {
        Init();
    }

    public void Init()
    {
        costText.text = ability.Cost.ToString();
        titleText.text = ability.Name;
        cardImage.sprite = ability.Image;
        descriptionText.text = ability.Description;
        rarityText.text = ability.Rarity.ToString();
        //typeText.text = ability.GetAbilityType();
        /*while (factionGroup.childCount > 0)
        {
            DestroyImmediate(factionGroup.GetChild(0).gameObject);
        }
        for (int i = 0; i < ability.Faction.Count; i++)
        {
            GameObject GO = Instantiate(factionTextHolderPrefab, factionGroup);
            GO.transform.GetChild(0).GetComponent<TMP_Text>().text = ability.Faction[i].ToString();
        }*/
    }
}
