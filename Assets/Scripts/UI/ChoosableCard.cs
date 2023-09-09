using UnityEngine;

public class ChoosableCard : MonoBehaviour
{
    public AbilityCard card;

    public void SelectCard()
    {
        CardChoiceManager.instance.SelectAbility(card.ability);
    }
}
