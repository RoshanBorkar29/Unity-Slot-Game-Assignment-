using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reel : MonoBehaviour
{
    // Start is called before the first frame update
    public Image symbolImage;
    public SlotSymbol[] symbols;
    public int CurrentSymbolIndex{
        get;
        private set;
    }
    public void SetRandomSymbol(){
        CurrentSymbolIndex=Random.Range(0,symbols.Length);
        symbolImage.sprite=symbols[CurrentSymbolIndex].sprite;
    }



}
