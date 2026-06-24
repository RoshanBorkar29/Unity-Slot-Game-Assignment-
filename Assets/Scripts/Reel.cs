using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Reel : MonoBehaviour
{
    public Image symbolImage;
    public SlotSymbol[] symbols;

    public int CurrentSymbolIndex { get; private set; }

    // Set final symbol when reel stops
    public void SetSymbol(int index)
    {
        CurrentSymbolIndex = index;
        symbolImage.sprite = symbols[index].sprite;
    }

    // Display random symbols during spinning
    public void SetRandomVisual()
    {
        int randomIndex = Random.Range(0, symbols.Length);
        symbolImage.sprite = symbols[randomIndex].sprite;
    }

    // Small bounce effect when reel lands
    public IEnumerator BounceAnimation()
    {
        Vector3 originalScale = transform.localScale;

        transform.localScale = originalScale * 1.15f;

        yield return new WaitForSeconds(0.1f);

        transform.localScale = originalScale;
    }
}