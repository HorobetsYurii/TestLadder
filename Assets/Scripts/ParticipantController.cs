using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticipantController : MonoBehaviour
{
    public ParticipantModel Model;
    private EditWindow _editWindow;
    private LeaderboardController _leaderboardController;

    private void Start()
    {
        _editWindow = FindObjectOfType<EditWindow>(true);
        _leaderboardController = FindObjectOfType<LeaderboardController>();
    }

    public void OnLeftClick()
    {
        _leaderboardController.SelectParticipant(Model);
    }

    public void OnRightClick()
    {
        _editWindow.gameObject.SetActive(true);
        _editWindow.CurrentParticipant = Model;
    }
}
