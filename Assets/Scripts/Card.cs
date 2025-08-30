using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public Image iconImage;

    public Sprite hiddenIconSprite;
    public Sprite iconSprite;

    public bool isOpen;
    public CardController cardController;

    public void SetIconSprite(Sprite IconSprite)
    {
        iconSprite = IconSprite;
    }

    public void Show()
    {
        iconImage.sprite = iconSprite;
        isOpen = true;
    }

    public void Hide()
    {
        iconImage.sprite = hiddenIconSprite;
        isOpen = false;
    }

    public void OnCardClick()
    {
        cardController.SetCardOpen(this);
    }
}
