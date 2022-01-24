using System;
using UnityEditor.Experimental.SceneManagement;
using UnityEngine;

public class LeaderboardController : MonoBehaviour
{
    public LeaderboardModel Model { get; set; }

    public void AddParticipant(ParticipantModel participant)
    {
        Model.Participants.Add(participant);
    }

    public void AddParticipant(string name, int score)
    {
        if (String.IsNullOrEmpty(name))
        {
            Debug.LogWarning("Trying to create participant with null or empty name.");
            return;
        }
        
        if (score < 0)
        {
            Debug.LogWarning("Trying to create participant with score lower than zero.");
            return;
        }

        AddParticipant(new ParticipantModel(name, score));
    }

    public void RemoveParticipant(ParticipantModel participant)
    {
        if (!Model.Participants.Contains(participant))
        {
            Debug.LogWarning("Participant you are trying to delete doesn't exist in leaderboard participants list.");
            return;
        }

        Model.Participants.Remove(participant);
    }

    public void SelectParticipant(ParticipantModel participant)
    {
        Model.SelectedParticipant = participant;
    }

    public void RemoveSelected()
    {
        RemoveParticipant(Model.SelectedParticipant);
    }

    public void EditParticipant(ParticipantModel participant, string newName = null, int newScore = -1)
    {
        newName = String.IsNullOrEmpty(newName)? participant.Name : newName;
        newScore = newScore < 0? participant.Score : newScore;

        participant.Name = newName;
        participant.Score = newScore;
    }
}
