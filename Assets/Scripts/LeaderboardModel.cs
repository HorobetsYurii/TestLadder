using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;

public class LeaderboardModel
{
    private ParticipantsObservableCollection _participants = new ParticipantsObservableCollection();

    private ParticipantModel _selectedParticipant;

    public ParticipantModel SelectedParticipant
    {
        get
        {
            return _selectedParticipant;
        }
        set
        {
            _selectedParticipant = value;
            OnParticipantSelected?.Invoke(_selectedParticipant);
        }
    }

    public ParticipantsObservableCollection Participants => _participants;

    public Action<ParticipantModel> OnParticipantSelected;
}