using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Openable))]
public class OpenableRandomizer : MonoBehaviour
{
    [SerializeField] private List<ItemType> possibleGiven;
    [SerializeField] private List<uint> possibleCosts;
    [SerializeField] private TextMeshProUGUI cost;

    private void Awake()
    {
        var randomGivenIndex = Random.Range(0, possibleGiven.Count);
        var givenItem = possibleGiven[randomGivenIndex];

        var randomCostIndex = Random.Range(0, possibleCosts.Count);
        var randomCost = possibleCosts[randomCostIndex];
        
        var openable = GetComponent<Openable>();
        openable._givenItem = givenItem;
        openable._requiredAmount = randomCost;
        cost.text = randomCost.ToString();
    }
}