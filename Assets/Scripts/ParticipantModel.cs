using System;
using UnityEngine;

public class ParticipantModel
{
    public string Name
    {
        get
        {
            return _name;
        }
        set
        {
            _name = value;
            OnDataChanged?.Invoke();
        }
    }

    public int Score
    {
        get
        {
            return _score;
        }
        set
        {
            _score = value;
            OnDataChanged?.Invoke();
        }
    }

    private string _name;
    private int _score;

    public Action OnDataChanged;

    public ParticipantModel(string name, int score)
    {
        _name = name;
        _score = score;
    }

    public int CompareTo(ParticipantModel compareParticipant)
    {
        if (compareParticipant == null)
        {
            Debug.LogWarning("While sorting compareParticipant was null");
            return 1;
        }
        else
        {
            return Score.CompareTo(compareParticipant.Score);
        }
    }
}
