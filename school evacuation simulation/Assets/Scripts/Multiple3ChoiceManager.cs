using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using TMPro;

public class Multiple3ChoiceManager : MonoBehaviour
{
    public Multiple3ChoiceQuestios[] questions;
	private static List<Multiple3ChoiceQuestios> unansweredQuestions;
	private Multiple3ChoiceQuestios currentQuestion;
	[SerializeField] private TextMeshProUGUI factText;

	void Start(){
		if(unansweredQuestions == null || unansweredQuestions.Count==0){
			unansweredQuestions = questions.ToList<Multiple3ChoiceQuestios>();
		}

		SetCurrentQuestion();
	}
	void SetCurrentQuestion(){
		int randomQuestionIndex = Random.Range(0, unansweredQuestions.Count);
		currentQuestion = unansweredQuestions[randomQuestionIndex];
		factText.text = currentQuestion.question;
		unansweredQuestions.RemoveAt(randomQuestionIndex);
	}
}
