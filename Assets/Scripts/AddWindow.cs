using TMPro;
using UnityEngine;

public class AddWindow : MonoBehaviour
{
    [SerializeField] private TMP_InputField _name;
    [SerializeField] private TMP_InputField _score;

    private LeaderboardController _leaderboardController;

    public void Clear()
    {
        _name.text = "";
        _score.text = "";
    }

    private void Start()
    {
        _leaderboardController = FindObjectOfType<LeaderboardController>();
    }

    public void Add()
    {
        string name = _name.text;
        string scoreString = _score.text;

        if (int.TryParse(scoreString, out int score))
        {
            _leaderboardController.AddParticipant(name, score);
            gameObject.SetActive(false);
        }
        else
        {
            Debug.LogWarning("Can't parse a participant score.", this);
        }
    }
}
