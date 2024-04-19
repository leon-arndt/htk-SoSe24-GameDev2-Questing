using System;
using Events;
using TMPro;
using UniRx;
using UnityEngine;

public class AreaView : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI areaNameText;
        
    private void Awake()
    {
        areaNameText.text = "";
        MessageBroker.Default.Receive<AreaEntered>()
            .Subscribe(x => ChangeName(x.Area))
            .AddTo(this);
        
        MessageBroker.Default.Receive<AreaLeft>()
            .Subscribe(_ => ChangeName(string.Empty))
            .AddTo(this);
    }

    private void ChangeName(string areaName)
    {
        areaNameText.text = areaName;
    }
}