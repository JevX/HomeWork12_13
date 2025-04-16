using UnityEngine;

public class GameStatus : MonoBehaviour
{
    public bool GameEnd { get; set; } = false;

    [SerializeField] private Movement _movement;
    [SerializeField] private ItemCollector _itemCollector;
    [SerializeField] private ScoreViewer _scoreViewer;
    [SerializeField] private Timer _timer;
    [SerializeField] private ListCoins _listCoins;
    [SerializeField] private Lift _lift;

    [SerializeField] private GameObject _panelWin;
    [SerializeField] private GameObject _panelDefeat;

    private void Start()
    {
        InitAllComponent();
    }

    private void Update()
    {
        if (_timer.IsTimeEnd)         
            ShowResultByCoinsCount();       

        if (_listCoins.CoinsCount <= 0 && _timer.IsTimeEnd == false)        
            Win();       

        if (Input.GetKeyDown(KeyCode.R))        
            InitAllComponent();        
    }

    private void ShowResultByCoinsCount()
    { 
        if (_listCoins.CoinsCount > 0)
            Defeat();
        else
            Win();
    }

    public void InitAllComponent()
    {
        Init();

        _movement.Init();
        _itemCollector.Init();
        _scoreViewer.Init();
        _timer.Init();
        _listCoins.Init();
        _lift.Init();
    }

    public void Win()
    {
        SetGameEndStatus();

        ChangeMoveStatus(false);

        _panelWin.SetActive(true);
    }

    public void Defeat()
    {
        SetGameEndStatus();

        ChangeMoveStatus(false);

        _panelDefeat.SetActive(true);
    }

    private void SetGameEndStatus()
    {
        GameEnd = true;

        _timer.IsGameEnd = GameEnd;

        _lift.IsGameEnd = GameEnd;
    }

    private void ChangeMoveStatus(bool status)
    {
        _movement.CanMove = status;
    }

    public void Init()
    {
        GameEnd = false;

        _panelWin.SetActive(false);
        _panelDefeat.SetActive(false);
    }
}
