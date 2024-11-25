using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RecipeUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _recipeNameText;

    [SerializeField]
    private GameObject _iconContainer;

    [SerializeField]
    private GameObject _ingredientUIPrefab;

    public void SetRecipeSO(RecipeSO recipeSO)
    {
        _recipeNameText.text = recipeSO.RecipeName;
        foreach (KitchenObjectSO kitchenObjectSO in recipeSO.KitchenObjectSOList)
        {
            GameObject ingredientUI = Instantiate(_ingredientUIPrefab, _iconContainer.transform);
            ingredientUI.GetComponent<IngredientUI>().GetIconImage().sprite = kitchenObjectSO.Sprite;
        }
    }
}
