using UnityEngine;
using UnityEngine.UI;

public class ScoreViewer : MonoBehaviour
{
    [SerializeField] private Text _score;  

    public void Init()
    {
        _score.text = "0";       
    }

    public void RefreshView(int score)
    {
        _score.text = score.ToString();
    }

}
