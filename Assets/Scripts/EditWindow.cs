using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EditWindow : MonoBehaviour
{
    [SerializeField] private TMP_InputField _name;
    [SerializeField] private TMP_InputField _score;

    private LeaderboardController _leaderboardController;
    private ParticipantModel _currentParticipant;

    public ParticipantModel CurrentParticipant
    {
        get
        {
            return _currentParticipant;
        }
        set
        {
            _currentParticipant = value;
            _name.text = CurrentParticipant.Name;
            _score.text = CurrentParticipant.Score.ToString();
        }
    }

    private void Start()
    {
        _leaderboardController = FindObjectOfType<LeaderboardController>();
    }

    public void Edit()
    {
        string name = _name.text;
        string scoreString = _score.text;

        if (int.TryParse(scoreString, out int score))
        {
            _leaderboardController.EditParticipant(CurrentParticipant, name, score);
            gameObject.SetActive(false);
        }
        else
        {
            Debug.LogWarning("Can't parse a participant score.", this);
        }
    }
}
