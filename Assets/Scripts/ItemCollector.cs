using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    public int Score { get; private set; } = 0;

    [SerializeField] private ScoreViewer _scoreViewer;
    [SerializeField] private ListCoins _listCoins;

    private void Awake()
    {
        Init();      
    }

    public void Init()
    {
        Score = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        PickableItem pickableItem = other.GetComponentInParent<PickableItem>();

        if (pickableItem != null)
        {
            Score += pickableItem.PickUp();
            
            _listCoins.ReduceCoinsCount(pickableItem.ID);

            _scoreViewer.RefreshView(Score);

            Debug.Log("Score=" + Score);
        }
    }
}
