using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class BestScoreData
{
    public int score=0;
}

public class Scores : MonoBehaviour
{
    public SquareTextureData squareTextureData;
    public Text scoreText;

    private bool newBestScore_=false;
    private BestScoreData bestScores_ =new BestScoreData();
    private int currentScores_;

    private string bestScoreKey = "bsdat";
    private void Awake()
    {
        if (BinaryDataStrem.Exist(bestScoreKey))
        {
            StartCoroutine(ReadDataFile());
        }
    }

    private IEnumerator ReadDataFile()
    {
        bestScores_= BinaryDataStrem.Read<BestScoreData>(bestScoreKey);
        yield return new WaitForEndOfFrame();
        GameEvents.UpdateBestScoreBar(currentScores_, bestScores_.score);

    }

    void Start()
    {
        currentScores_ = 0;
        newBestScore_ = false;
        squareTextureData.SetStartColor();
        UpdateScoreText();
    }


    private void OnEnable()
    {
        GameEvents.AddScores += AddScores;
        GameEvents.GameOver += SaveBestScores;
    }

    private void OnDisable()
    {
        GameEvents.AddScores -= AddScores;
        GameEvents.GameOver -= SaveBestScores;
    }

    public void SaveBestScores(bool newBestScores)
    {
        BinaryDataStrem.Save<BestScoreData>(bestScores_,bestScoreKey);
    }
    private void AddScores(int scores)
    {

        currentScores_ += scores;
        if (currentScores_ > bestScores_.score)
        {
            newBestScore_ = true;
            bestScores_.score = currentScores_;
            SaveBestScores(true);
        }
        UpdateSquareColor();
        GameEvents.UpdateBestScoreBar(currentScores_, bestScores_.score);
        UpdateScoreText();
    }

    private void UpdateSquareColor()
    {
        if (GameEvents.UpdateSquareColor !=null && currentScores_ >= squareTextureData.tresholdVal)
        {
            squareTextureData.UpdateColor(currentScores_);
            GameEvents.UpdateSquareColor(squareTextureData.currentColor);
        }
    }
    private void UpdateScoreText()
    {
        scoreText.text = currentScores_.ToString();
    }
}
