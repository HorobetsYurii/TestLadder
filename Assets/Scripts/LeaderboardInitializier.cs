using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderboardInitializier : MonoBehaviour
{
    private LeaderboardView _view;
    private LeaderboardController _controller;

    private void Awake()
    {
        _controller = GetComponent<LeaderboardController>();
        _view = GetComponent<LeaderboardView>();

        LeaderboardModel model = new LeaderboardModel();
        _controller.Model = model;
        _view.Model = model;
    }
}
