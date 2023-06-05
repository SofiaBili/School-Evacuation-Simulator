using UnityEngine;

public class IsPlayerInPos : MonoBehaviour{
	private void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag("Player")){
			FireDrillHuman.startEvacFlag=true;
			EarthquakeClassScript.LeaveRoomInfo();
			Destroy(gameObject);
		}
    }
}