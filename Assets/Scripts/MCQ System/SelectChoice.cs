using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SelectChoice : MonoBehaviour
{
    private Button m_Button;
    
    private Question m_Question;
    private string m_Choice;
    private void Start()
    {
        m_Button = GetComponent<Button>();
        m_Button.onClick.AddListener(Select);
        m_Question = GetComponentInParent(typeof(Question)) as Question; ;
    }
    

    private void Select()
    {
        if (m_Question.CheckAnswer(GetComponentInChildren<TextMeshProUGUI>().text))
        {
            m_Button.image.color = Color.green;
        }
        else
        {
            m_Button.image.color = Color.red;   
        }  
        Invoke(nameof(NextQuestion), 0.3f);
    }
    
    private void NextQuestion()
    {
        m_Button.image.color = Color.white;
        m_Question.transform.parent.GetComponent<Questions>().NextQuestion(m_Question.gameObject);
    }
}
