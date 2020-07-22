using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameData _gameData;

    // Start is called before the first frame update
    void Start()
    {
        InitGameData();

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void InitGameData()
    {
        _gameData = GameData.Instance;
        _gameData.Init();
    }

}
