using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SlotMachine : MonoBehaviour
{
    public AudioManager audioManager;

    public Reel reel1;
    public Reel reel2;
    public Reel reel3;

    public TextMeshProUGUI resultText;
    public TextMeshProUGUI balanceText;

    public Button spinButton;

    public int balance = 1000;
    public int spinCost = 10;

    private void Start()
    {
        UpdateBalance();
        resultText.text = "";
    }

    public void Spin()
    {
        if (balance < spinCost)
        {
            resultText.text = "Not Enough Balance!";
            return;
        }

        resultText.text = "";

        balance -= spinCost;
        UpdateBalance();

        spinButton.interactable = false;

        audioManager.PlaySpinSound();

        StartCoroutine(SpinRoutine());
    }

    private void UpdateBalance()
    {
        balanceText.text = "Balance : " + balance;
    }

    private IEnumerator SpinRoutine()
    {
        int finalIndex1 = Random.Range(0, reel1.symbols.Length);
        int finalIndex2 = Random.Range(0, reel2.symbols.Length);
        int finalIndex3 = Random.Range(0, reel3.symbols.Length);

        float timer = 0f;

        while (timer < 1.5f)
        {
            reel1.SetRandomVisual();
            reel2.SetRandomVisual();
            reel3.SetRandomVisual();

            timer += 0.05f;

            yield return new WaitForSeconds(0.05f);
        }

        reel1.SetSymbol(finalIndex1);

        yield return new WaitForSeconds(0.3f);

        reel2.SetSymbol(finalIndex2);

        yield return new WaitForSeconds(0.3f);

        reel3.SetSymbol(finalIndex3);

        yield return new WaitForSeconds(0.1f);

        CheckWin();

        spinButton.interactable = true;
    }

    private void CheckWin()
    {
        Debug.Log(
            reel1.symbols[reel1.CurrentSymbolIndex].symbolName +
            " | " +
            reel2.symbols[reel2.CurrentSymbolIndex].symbolName +
            " | " +
            reel3.symbols[reel3.CurrentSymbolIndex].symbolName
        );

        if (reel1.CurrentSymbolIndex ==
            reel2.CurrentSymbolIndex &&
            reel2.CurrentSymbolIndex ==
            reel3.CurrentSymbolIndex)
        {
            int payout =
                reel1.symbols[
                    reel1.CurrentSymbolIndex
                ].payout;

            balance += payout;

            UpdateBalance();

            resultText.text = "YOU WIN! +" + payout;

            audioManager.PlayWinSound();
        }
        else
        {
            resultText.text = "TRY AGAIN!";

            audioManager.PlayLoseSound();
        }
    }
}