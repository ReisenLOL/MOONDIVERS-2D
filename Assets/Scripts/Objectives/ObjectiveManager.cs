using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ObjectiveManager : MonoBehaviour
{
    public Transform objectiveListUI;
    public GameObject objectiveListUITemplate;
    public List<Objective> objectiveList = new();
    public List<Objective> subObjectiveList = new();
    void Start()
    {
        foreach (Objective objective in objectiveList)
        {
            GameObject newTemplate = Instantiate(objectiveListUITemplate, objectiveListUI);
            newTemplate.SetActive(true);
            newTemplate.transform.Find("ObjectiveText").GetComponent<TextMeshProUGUI>().text = objective.objectiveName;
        }
    }
    void Update()
    {
        
    }
    public void CompleteObjective(Objective objective)
    {
        //not sure how to do the spawning of objective stuffs, i guess for now i'll have preset maps until i can figure out random spawning (never)
        objective.completed = true;
    }
}
