using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DetectionMeter : MonoBehaviour
{
    #region Slider settings
    [Header("Slider")]
        public Slider detectionSlider;
        public float increaseRate = 1.0f;
        public float decreaseRate = 1.0f;
    #endregion

    public FieldOfView fieldOfView;

    private void Start()
    {
        fieldOfView= GetComponent<FieldOfView>();  
        detectionSlider.value = 1;        // Set the initial value of the detection meter
    }

    private void Update()
    {
        DetectionBehaviour();
        Detected();
    }

    private void DetectionBehaviour()
    {
        if (fieldOfView.Spotted)
        {
            detectionSlider.value += increaseRate * Time.deltaTime;            // Increase the detection meter over time
            detectionSlider.value = Mathf.Clamp(detectionSlider.value, 1, 100);         // Ensure the value does not exceed 100
        }

        else
        {
            detectionSlider.value -= decreaseRate * Time.deltaTime;            // Increase the detection meter over time
        }
    }

    private void Detected()
    {
        if (detectionSlider.value >= 100) 
        {
            AudioManager.instance.PlayOneShot(FMODEvents.instance.Boss_LaughSound, this.transform.position);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            SceneManager.LoadScene("GameOver");

        }
    }

}
