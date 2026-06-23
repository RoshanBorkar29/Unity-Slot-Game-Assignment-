using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   
using TMPro;

public class SlotMachine : MonoBehaviour
{
   public Reel reel1;
   public Reel reel2;
   public Reel reel3;
   public TextMeshProUGUI resultText;
   public Button spinButton;

   public void Spin()
    {
        Debug.Log("Spin button working");
        spinButton.interactable=false;
        StartCoroutine(SpinRoutine());
    }

    private IEnumerator SpinRoutine()
    {
       yield return StartCoroutine(SpinReel(reel1,1f));
        yield return StartCoroutine(SpinReel(reel2,1f));
         yield return StartCoroutine(SpinReel(reel3,1f));

         CheckWin();
         spinButton.interactable=true;
    }
    IEnumerator SpinReel(Reel reel,float duration)
    {
        float timer=0;
        while(timer<duration){
            reel.SetRandomSymbol();
            timer+=0.1f;
            yield return new WaitForSeconds(0.1f);
        }
    }
    void CheckWin()
    {
        if(reel1.CurrentSymbolIndex==reel2.CurrentSymbolIndex && reel3.CurrentSymbolIndex==reel1.CurrentSymbolIndex){
            int payout=reel1.symbols[reel1.CurrentSymbolIndex].payout;
            resultText.text="You Win! Payout: "+payout;
        }
        else
        {
           // Debug.Log("You Lose!");
            resultText.text=" You Lose!";
        }
}
}
