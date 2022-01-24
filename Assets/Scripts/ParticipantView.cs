using System;
using TMPro;
using UnityEditor.Experimental.SceneManagement;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ParticipantView : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private TextMeshProUGUI _score;
    [SerializeField] private TextMeshProUGUI _number;
    [SerializeField] private Image _selectImage;

    public Image SelectImage => _selectImage;
    public ParticipantModel Model { get; set; }
    private ParticipantController _controller;

    public int Number
    {
        get
        {
            return Int32.Parse(_number.text);
        }
        set
        {
            _number.text = value.ToString();
        }
    }
    

    private void Start()
    {
        _controller = GetComponent<ParticipantController>();
        Model.OnDataChanged += Refresh;

        Refresh();
    }

    private void Refresh()
    {
        _name.text = Model.Name;
        _score.text = Model.Score.ToString();
    }

    private void OnDestroy()
    {
        Model.OnDataChanged -= Refresh;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
            _controller.OnLeftClick();
        else if (eventData.button == PointerEventData.InputButton.Right)
            _controller.OnRightClick();
    }
}
