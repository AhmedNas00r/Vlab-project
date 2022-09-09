using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Questions : MonoBehaviour
{
    private bool m_AllSolved;

    private void Start()
    {
        m_AllSolved = false;
        // disable all the questions
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
        transform.GetChild(0).gameObject.SetActive(true);
    }
    
    public void NextQuestion(GameObject question)
    {
        Debug.Log("Next Question");
        CheckIfAllSolved();
        if (m_AllSolved)
        {
            CloseQuestions();
            return;
        }
        int childCount = transform.childCount;
        int index = question.transform.GetSiblingIndex();
        Debug.Log("index: " + index);
        for (int i = (index+1)%childCount; i < childCount; i = (i+1)%childCount)
        {
            Debug.Log(i);
            Transform sibling = transform.GetChild(i);
            if (!sibling.GetComponent<Question>().IsSolved())
            {
                sibling.gameObject.SetActive(true);
                question.SetActive(false);
                return;
            }
        }
    }
    
    public void CloseQuestions()
    {
        transform.parent.gameObject.SetActive(false);
    }

    private void CheckIfAllSolved()
    {
        //check that all questions are solved in children
        int childCount = transform.childCount;
        for (int i = 0; i < childCount; i++)
        {
            if (!transform.GetChild(i).GetComponent<Question>().IsSolved())
            {
                return;
            }
        }
        m_AllSolved = true;
        return;
    }
}
