using UnityEngine;
using UnityEngine.UI;

public class IngredientUI : MonoBehaviour
{
    [SerializeField]
    private Image _icon;

    public Image GetIconImage()
    {
        return _icon;
    }
}
