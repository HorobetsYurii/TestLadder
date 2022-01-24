using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

using System.Linq;

public class ParticipantsObservableCollection : ObservableCollection<ParticipantModel>
{
    public Action<List<ParticipantModel>> OnCollectionUpdated;

    private void UpdateCollection()
    {
        SortByScore();
        OnCollectionUpdated?.Invoke(this.ToList());
    }
    

    public void SortByScore()
    {
        var sortableList = new List<ParticipantModel>(this);
        sortableList = sortableList.OrderByDescending(participant => participant.Score).ToList();

        for (int i = 0; i < sortableList.Count; i++)
        {
            Move(IndexOf(sortableList[i]), i);
        }
    }

    public ParticipantsObservableCollection()
    {
        CollectionChanged += (object sender, NotifyCollectionChangedEventArgs args) =>
        {
            if (args.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (ParticipantModel participant in args.NewItems)
                {
                    participant.OnDataChanged += UpdateCollection;
                }
            }
            else if(args.Action == NotifyCollectionChangedAction.Remove)
            {
                foreach (ParticipantModel participant in args.OldItems)
                {
                    participant.OnDataChanged -= UpdateCollection;
                }
            }

            if (args.Action != NotifyCollectionChangedAction.Move)
            {
                UpdateCollection();
            }
        };
    }
}
