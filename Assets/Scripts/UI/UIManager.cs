using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [BoxGroup("Card Inspector")]
    public Image darkPanel;
    [BoxGroup("Card Inspector")]
    public float scaleMultiplier = 3.5f;
    private DraggableItem draggableItemInspected;
    private Vector2 defaultSize;
    private Vector2 inspectedSize { get => defaultSize * scaleMultiplier; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        //globalEvents.holder.Subscribe("InspectCard", new Action<DraggableItem>( InspectCard));
    }
    public void InspectCard(DraggableItem item)
    {
        //Full Screen
        draggableItemInspected = item;
        defaultSize = item.rectTransform.sizeDelta;
        item.PutOnTop(false);
        Vector2 centerPos = new Vector2(Screen.width / 2, -Screen.height / 2);
        item.rectTransform.DOAnchorPos(centerPos, item.duration).SetEase(item.easeType);
        item.rectTransform.DOSizeDelta(inspectedSize, item.duration);
        darkPanel.DOFade(.7f, item.duration);
        darkPanel.raycastTarget = true;
    }
    public void FinishInspecting()
    {
        if (!draggableItemInspected)
        {
            return;
        }
        darkPanel.DOFade(0, draggableItemInspected.duration);
        draggableItemInspected.PutOnTop(false);
        draggableItemInspected.rectTransform.DOSizeDelta(defaultSize, draggableItemInspected.duration);
        draggableItemInspected.BackToParentBeforeDrag();
        draggableItemInspected = null;
        darkPanel.raycastTarget = false;
    }
}
