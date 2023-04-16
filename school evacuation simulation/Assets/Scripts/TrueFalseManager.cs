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
	
    StartQuestionProcedureScript startQuestionProcedureScript;
    GameObject startQuestionProcedureScriptObject;
    ToggleQuestionCanvas toggleQuestionCanvasScript;
    [SerializeField] GameObject toggleQuestionCanvasObject;

	[SerializeField] Button trueButton;
	[SerializeField] Button falseButton;
	static bool changeBtnColour = false;
	static int randomQuestionIndex;

	void Awake(){
		toggleQuestionCanvasScript = toggleQuestionCanvasObject.GetComponent<ToggleQuestionCanvas>();
	}
	void Start(){
		if(unansweredQuestions == null || unansweredQuestions.Count==0){
			unansweredQuestions = questions.ToList<TrueFalseQuestions>();
		}

		SetCurrentQuestion();
	}
	void SetCurrentQuestion(){
		randomQuestionIndex = Random.Range(0, unansweredQuestions.Count);
		currentQuestion = unansweredQuestions[randomQuestionIndex];
		factText.text = currentQuestion.fact;
	}
	public void UserSelectExit(){
        startQuestionProcedureScript = toggleQuestionCanvasScript.GetCurrHitbox().GetComponent<StartQuestionProcedureScript>();
		startQuestionProcedureScript.StopAnimationAndCloseCanvas();
	}
	
    private IEnumerator ChangeButtonColour(Button btn){
		if(changeBtnColour){
			yield return new WaitForSeconds (0.17f);
			btn.GetComponent<Image>().color = Color.white;
			changeBtnColour = false;
		}
	}
	public void UserSelectTrue(){
		startQuestionProcedureScript = toggleQuestionCanvasScript.GetCurrHitbox().GetComponent<StartQuestionProcedureScript>();
		if(currentQuestion.isTrue){
			Debug.Log("Cor");
			trueButton.GetComponent<Image>().color = Color.green;
			startQuestionProcedureScript.DeleteHexagon();
			unansweredQuestions.RemoveAt(randomQuestionIndex);
		}else{
			trueButton.GetComponent<Image>().color = Color.red;
			startQuestionProcedureScript.StopAnimationAndCloseCanvas();
			Debug.Log("WRONG");
		}
		changeBtnColour = true;
		StartCoroutine(ChangeButtonColour(trueButton));
	}
	public void UserSelectFalse(){
		startQuestionProcedureScript = toggleQuestionCanvasScript.GetCurrHitbox().GetComponent<StartQuestionProcedureScript>();
		if(currentQuestion.isTrue){
			falseButton.GetComponent<Image>().color = Color.red;
			startQuestionProcedureScript.StopAnimationAndCloseCanvas();
			Debug.Log("WRONG");
		}else{
			Debug.Log("Cor");
			falseButton.GetComponent<Image>().color = Color.green;
			startQuestionProcedureScript.DeleteHexagon();
			unansweredQuestions.RemoveAt(randomQuestionIndex);
		}
		changeBtnColour = true;
		StartCoroutine(ChangeButtonColour(falseButton));
	}
}