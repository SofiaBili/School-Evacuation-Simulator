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
	[SerializeField] private TextMeshProUGUI ans0Text;
	[SerializeField] private TextMeshProUGUI ans1Text;
	[SerializeField] private TextMeshProUGUI ans2Text;

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
		ans0Text.text = currentQuestion.ans1;
		ans1Text.text = currentQuestion.ans2;
		ans2Text.text = currentQuestion.ans3;
		unansweredQuestions.RemoveAt(randomQuestionIndex);
	}
	
	public void UserSelect0(){
		if(currentQuestion.corrAns == 0){
			Debug.Log("Cor");
		}else{
			Debug.Log("WRONG");
		}
	}
	
	public void UserSelect1(){
		if(currentQuestion.corrAns == 1){
			Debug.Log("Cor");
		}else{
			Debug.Log("WRONG");
		}
	}
	
	public void UserSelect2(){
		if(currentQuestion.corrAns == 2){
			Debug.Log("Cor");
		}else{
			Debug.Log("WRONG");
		}
	}
}
