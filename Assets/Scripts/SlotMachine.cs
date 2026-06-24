using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SlotMachine : MonoBehaviour
{
    [Header("Managers")]
    public AudioManager audioManager;

    [Header("Reels")]
    public Reel reel1;
    public Reel reel2;
    public Reel reel3;

    [Header("UI")]
    public TextMeshProUGUI resultText;
    public TextMeshProUGUI balanceText;
    public Button spinButton;

    [Header("Gameplay")]
    public int balance = 1000;
    public int spinCost = 10;

    private void Start()
    {
        UpdateBalance();
        resultText.text = "";
    }

    public void Spin()
    {
        // Prevent spinning if balance is insufficient
        if (balance < spinCost)
        {
            resultText.text = "Not Enough Balance!";
            return;
        }

        resultText.text = "";

        // Deduct spin cost
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
        // Generate final symbols before spinning
        int finalIndex1 = Random.Range(0, reel1.symbols.Length);
        int finalIndex2 = Random.Range(0, reel2.symbols.Length);
        int finalIndex3 = Random.Range(0, reel3.symbols.Length);

        float timer = 0f;

        // Show random symbols while reels are spinning
        while (timer < 1.5f)
        {
            reel1.SetRandomVisual();
            reel2.SetRandomVisual();
            reel3.SetRandomVisual();

            timer += 0.05f;

            yield return new WaitForSeconds(0.05f);
        }

        // Stop reels one by one
        reel1.SetSymbol(finalIndex1);
        StartCoroutine(reel1.BounceAnimation());

        yield return new WaitForSeconds(0.3f);

        reel2.SetSymbol(finalIndex2);
        StartCoroutine(reel2.BounceAnimation());

        yield return new WaitForSeconds(0.3f);

        reel3.SetSymbol(finalIndex3);
        StartCoroutine(reel3.BounceAnimation());

        yield return new WaitForSeconds(0.2f);

        CheckWin();

        spinButton.interactable = true;
    }

    private void CheckWin()
    {
        // Win only if all reels show the same symbol
        if (reel1.CurrentSymbolIndex ==
            reel2.CurrentSymbolIndex &&
            reel2.CurrentSymbolIndex ==
            reel3.CurrentSymbolIndex)
        {
            int payout =
                reel1.symbols[reel1.CurrentSymbolIndex].payout;

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

        StartCoroutine(ResultTextPop());
    }

    private IEnumerator ResultTextPop()
    {
        Vector3 originalScale = resultText.transform.localScale;

        resultText.transform.localScale = Vector3.zero;

        float timer = 0f;

        // Pop-up animation for result text
        while (timer < 0.2f)
        {
            timer += Time.deltaTime;

            resultText.transform.localScale =
                Vector3.Lerp(
                    Vector3.zero,
                    originalScale,
                    timer / 0.2f
                );

            yield return null;
        }

        resultText.transform.localScale = originalScale;
    }
}