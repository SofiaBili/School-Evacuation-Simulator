using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using TMPro;

public class TrueFalseManager : MonoBehaviour
{
	public TrueFalseQuestions[] questions;
	private static List<TrueFalseQuestions> unansweredQuestions;
	private TrueFalseQuestions currentQuestion;
	[SerializeField] private TextMeshProUGUI factText;

	void Start(){
		if(unansweredQuestions == null || unansweredQuestions.Count==0){
			unansweredQuestions = questions.ToList<TrueFalseQuestions>();
		}

		SetCurrentQuestion();
	}
	void SetCurrentQuestion(){
		int randomQuestionIndex = Random.Range(0, unansweredQuestions.Count);
		currentQuestion = unansweredQuestions[randomQuestionIndex];
		factText.text = currentQuestion.fact;
		unansweredQuestions.RemoveAt(randomQuestionIndex);
	}
	public void UserSelectTrue(){
		if(currentQuestion.isTrue){
			Debug.Log("Cor");
		}else{
			Debug.Log("WRONG");
		}
	}
	public void UserSelectFalse(){
		if(currentQuestion.isTrue){
			Debug.Log("WRONG");
		}else{
			Debug.Log("Cor");
		}
	}
}