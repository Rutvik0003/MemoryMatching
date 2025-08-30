using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;

public class CardController : MonoBehaviour
{
    public Sprite[] sprites;
    public Card cardPrefab;
    public Transform GridLayout;
    private int GridSize;
    private int MatchCount;
    private int AttemptCount;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI AttemptText;


    private List<Sprite> spritePairs;

    Card FirstSelected;
    Card SecondSelected;

    private void Start()
    {
        GridSize = LevelManager.selectedValue;
        PrepareCards();
        CreateCards();
        MatchCount = 0;
        
    }

    private void Update()
    {
        scoreText.text = "Score : " + MatchCount;
        AttemptText.text = "Attempt : " + AttemptCount;
    }

    public void PrepareCards()
    {

        spritePairs = new List<Sprite>();
        for (int i = 0; i < GridSize; i++)
        {
            spritePairs.Add(sprites[i]);
            spritePairs.Add(sprites[i]);
            
        }     

        ShuffleSprites(spritePairs);
    }

    public void CreateCards()
    {
        for (int i = 0;i < spritePairs.Count; i++)
        {
            Card card = Instantiate(cardPrefab, GridLayout);
            card.SetIconSprite(spritePairs[i]);
            card.cardController = this;
            StartCoroutine(ShowCardinStart(card));
        }
    }

    public void SetCardOpen(Card card)
    {
        if(card.isOpen == false)
        {
            card.Show();

            if(FirstSelected == null)
            {
                FirstSelected = card;
                return;
            }
            else
            {
                SecondSelected = card;
                StartCoroutine(CheckMatch(FirstSelected, SecondSelected)); 
                
            }
        }
    }

    IEnumerator ShowCardinStart(Card card)
    {
        card.Show();
        yield return new WaitForSeconds (5f);
        card.Hide();
    }

    IEnumerator CheckMatch(Card a, Card b)
    {
        yield return new WaitForSeconds(0.3f);

        if(a.iconSprite == b.iconSprite)
        {
            //Matched
            MatchCount++;

            if(MatchCount == GridSize)
            {
                SceneManager.LoadScene(3);
            }
        }
        else
        {
            a.Hide();
            b.Hide();
        }
        AttemptCount++;
        FirstSelected = null;
        SecondSelected = null;

    }

    void ShuffleSprites(List<Sprite> spriteList)
    {
        for (int i = spriteList.Count - 1; i > 0; i--)
        {
            int randomIndex = Random.Range(0, i + 1);

            // Swap the elements at i and randomIndex
            Sprite temp = spriteList[i];
            spriteList[i] = spriteList[randomIndex];
            spriteList[randomIndex] = temp;
        }

        
    }
}
