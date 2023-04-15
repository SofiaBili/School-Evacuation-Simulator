using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using TMPro;

public class Multiple4ChoiceManager : MonoBehaviour
{
    public Multiple4ChoiceQuestions[] questions;
	private static List<Multiple4ChoiceQuestions> unansweredQuestions;
	private Multiple4ChoiceQuestions currentQuestion;
	[SerializeField] private TextMeshProUGUI factText;
	[SerializeField] private TextMeshProUGUI ans0Text;
	[SerializeField] private TextMeshProUGUI ans1Text;
	[SerializeField] private TextMeshProUGUI ans2Text;
	[SerializeField] private TextMeshProUGUI ans3Text;

	void Start(){
		if(unansweredQuestions == null || unansweredQuestions.Count==0){
			unansweredQuestions = questions.ToList<Multiple4ChoiceQuestions>();
		}

		SetCurrentQuestion();
	}
	void SetCurrentQuestion(){
		int randomQuestionIndex = Random.Range(0, unansweredQuestions.Count);
		currentQuestion = unansweredQuestions[randomQuestionIndex];
		factText.text = currentQuestion.question;
		ans0Text.text = currentQuestion.ans1;
		ans1Text.text = currentQuestion.ans2;
		ans2Text.text = currentQuestion.ans3;
		ans3Text.text = currentQuestion.ans4;
		unansweredQuestions.RemoveAt(randomQuestionIndex);
	}
	/*public void UserSelectTrue(){
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
	}*/
}