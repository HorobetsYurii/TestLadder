using System.Collections.Generic;
using UnityEditor.Experimental.SceneManagement;
using UnityEngine;

public class LeaderboardView : MonoBehaviour
{
    [SerializeField] private GameObject _participantPreview;
    [SerializeField] private Transform _contentParent;

    private List<ParticipantView> _participantsViews = new List<ParticipantView>();

    public LeaderboardModel Model { get; set; }

    private void Start()
    {
        Model.Participants.OnCollectionUpdated += UpdateView;
        Model.OnParticipantSelected += UpdateSelection;
    }

    private void UpdateView(List<ParticipantModel> sortedParticipants)
    {
        Debug.Log("viewUpdated");

        for (int i = 0; i < sortedParticipants.Count; i++)
        {
            ParticipantView view = _participantsViews.Find(participantView => participantView.Model == sortedParticipants[i]);

            if (view != null)
            {
                view.transform.SetSiblingIndex(i);
                view.Number = i+1;

                continue;
            }

            ParticipantView newParticipantView =
                Instantiate(_participantPreview, _contentParent).GetComponent<ParticipantView>();

            _participantsViews.Add(newParticipantView);

            newParticipantView.Model = sortedParticipants[i];
            newParticipantView.GetComponent<ParticipantController>().Model = sortedParticipants[i];

            newParticipantView.transform.SetSiblingIndex(i);
            newParticipantView.Number = i+1;
        }

        for (int i = _participantsViews.Count-1; i >=0; i--)
        {
            if (!sortedParticipants.Contains(_participantsViews[i].Model))
            {
                Destroy(_participantsViews[i].gameObject);
                _participantsViews.RemoveAt(i);
            }
        }
    }

    private void UpdateSelection(ParticipantModel selected)
    {
        Debug.Log(selected.Name);

        foreach (ParticipantView view in _participantsViews) 
            view.SelectImage.enabled = view.Model == selected;
    }
}
