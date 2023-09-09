using System.Collections.Generic;
using UnityEngine;

public class CardChoiceManager : MonoBehaviour
{
    public static CardChoiceManager instance;
    public GameObject cardChoicePanel;
    public List<AbilityCard> cards;
    public List<Ability> currentAbilityChoices;
    public AbilityPool abilityPool;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update

    public void StartChoosing()
    {
        cardChoicePanel.SetActive(true);
        StartDrawing();
        ApplyToUI();
    }
    private void StartDrawing()
    {
        currentAbilityChoices = new List<Ability>();
        DrawRandomAbilityCard();
    }

    private void ApplyToUI()
    {
        for (int i = 0; i < cards.Count; i++)
        {
            cards[i].ability = currentAbilityChoices[i];
            cards[i].Init();
        }
    }

    private void DrawRandomAbilityCard()
    {
        Ability abilityToAdd = GetRandomAbility();
        if (!currentAbilityChoices.Contains(abilityToAdd))
        {
            currentAbilityChoices.Add(abilityToAdd);
        }
        if (currentAbilityChoices.Count < 3)
        {
            DrawRandomAbilityCard();
        }
    }

    private Ability GetRandomAbility()
    {
        return abilityPool.Items[Random.Range(0, abilityPool.Items.Count)];
    }

    public void SelectAbility(Ability ability)
    {
        GameManager.instance.player.abilities.Add(ability);
        cardChoicePanel.SetActive(false);
        GameManager.instance.FinishCardChoosing();
    }
}
