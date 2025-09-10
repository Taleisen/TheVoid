using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;


public class VoidController : MonoBehaviour
{
    public Canvas canvas;
    public Text canvasText;
    public float delay = 5f;
    private float remainingTime;
    private bool heard = false;

    // Public values to use in shaders/particles/etc.
    public float micVolume;          // 0–1 range
    public float ambientLight;       // 0–1 from camera brightness
    public Vector3 acceleration;     // From accelerometer
    public Vector3 rotation;         // From gyroscope
    public Vector2 locationNoise;    // Fake gravity/randomness from GPS
    public float proceduralNoise;    // Generated per frame

    WebCamTexture camTexture;
    AudioClip micClip;
    string micDevice;

    [SerializeField] ParticleSystem voidParticles;
    [SerializeField] Material voidMaterial;

    void Start()
    {
        // Start sensors
        Input.gyro.enabled = true;
        Input.location.Start();

        camTexture = new WebCamTexture();
        camTexture.Play();

        if (Microphone.devices.Length > 0)
        {
            micDevice = Microphone.devices[0];
            micClip = Microphone.Start(micDevice, true, 1, 44100);
        }
    }

    public void HasBeenHeard()
    {
        heard = true;
        canvasText.text = "The Void Has Heard You And Will Now Depart.";
        remainingTime = delay;
    }
    void UpdateSensorData()
    {
        // Microphone Volume
        micVolume = GetMicVolume();

        // Camera Light (simple average brightness)
        ambientLight = GetCameraBrightness();

        // Accelerometer
        acceleration = Input.acceleration;

        // Gyroscope
        rotation = Input.gyro.rotationRateUnbiased;

        // Location (abstracted to pseudo-random based on lat/lon)
        if (Input.location.status == LocationServiceStatus.Running)
        {
            float lat = Input.location.lastData.latitude;
            float lon = Input.location.lastData.longitude;
            locationNoise = new Vector2(
                Mathf.PerlinNoise(lat, Time.time),
                Mathf.PerlinNoise(lon, Time.time * 0.5f)
            );
        }
        else
        {
            locationNoise = Vector2.zero;
        }

        // Procedural Noise (based on time and frame count)
        proceduralNoise = Mathf.PerlinNoise(Time.time * 0.2f, Mathf.Sin(Time.frameCount * 0.01f));
    }

    float GetMicVolume()
    {
        if (micClip == null || !Microphone.IsRecording(micDevice))
            return 0f;

        float[] samples = new float[128];
        int micPosition = Microphone.GetPosition(micDevice) - samples.Length + 1;
        if (micPosition < 0) return 0f;
        micClip.GetData(samples, micPosition);

        float sum = 0f;
        foreach (float sample in samples)
            sum += sample * sample;

        return Mathf.Clamp01(Mathf.Sqrt(sum / samples.Length) * 10f); // Scale to 0–1
    }

    float GetCameraBrightness()
    {
        if (camTexture == null || !camTexture.isPlaying) return 0f;

        Color32[] pixels = camTexture.GetPixels32();
        if (pixels.Length == 0) return 0f;

        float total = 0f;
        int count = 0;

        for (int i = 0; i < pixels.Length; i += 1000) // Sample every ~1000th pixel
        {
            Color32 c = pixels[i];
            total += (c.r + c.g + c.b) / (3f * 255f);
            count++;
        }

        return Mathf.Clamp01(total / count);
    }

    void Update()
    {
        if (!heard)
        {
            UpdateSensorData();
        }
        else
        {
            remainingTime -= Time.deltaTime;
            if (remainingTime <= 0)
            {
                voidParticles.Stop();
                StopAllSensors();
                SceneManager.LoadScene("LogoSplash");
            }
        }
    }

    void LateUpdate()
    {
        var main = voidParticles.main;
        main.startSize = Mathf.Lerp(0.1f, 1f, micVolume);
        main.startColor = new Color(ambientLight, 0.1f, micVolume, 0.6f);

        voidMaterial.SetFloat("_WarpAmount", proceduralNoise + micVolume);
        voidMaterial.SetVector("_MotionVector", acceleration + rotation);
        voidMaterial.SetFloat("_Shimmer", ambientLight);
    }

    void StopAllSensors()
    {
        Microphone.End(null);
        camTexture?.Stop();
        Input.gyro.enabled = false;
        if (Input.location.isEnabledByUser)
            Input.location.Stop();
    }
}
