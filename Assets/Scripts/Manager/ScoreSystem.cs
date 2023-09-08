using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField] ParticleSystem particles;
    [SerializeField] TextMeshProUGUI tmpro;
    [SerializeField] TextMeshProUGUI textScoreParticle;
    public void SetAddScore(int score, int addScore)
    {
        textScoreParticle.text = addScore.ToString();
        particles.Play();
        tmpro.text = (score + addScore).ToString();
    }

    [Button]
    void Test()
    {
        SetAddScore(200, 400);
    }
}
