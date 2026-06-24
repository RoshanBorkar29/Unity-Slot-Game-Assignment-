using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Reel : MonoBehaviour
{
    public Image symbolImage;
    public SlotSymbol[] symbols;

    public int CurrentSymbolIndex { get; private set; }

    public void SetSymbol(int index)
    {
        CurrentSymbolIndex = index;
        symbolImage.sprite = symbols[index].sprite;
    }

    public void SetRandomVisual()
    {
        int randomIndex = Random.Range(0, symbols.Length);
        symbolImage.sprite = symbols[randomIndex].sprite;
    }

    public IEnumerator BounceAnimation()
    {
        Vector3 originalScale = transform.localScale;

        transform.localScale = originalScale * 1.15f;

        yield return new WaitForSeconds(0.1f);

        transform.localScale = originalScale;
    }
}