# The Void

**“Speak your truth. The Void listens, but never remembers.”**

The Void is a privacy-first, digital ritual space where users can speak into their device, knowing that nothing is recorded, stored, or analyzed. All sensor data is consumed in real-time and transformed into ephemeral, abstract visuals — cast into the void, and then forgotten.

---

## Concept

The Void is a response to our over-surveilled digital reality. It creates a temporary, sacred space where users can speak freely and experience sensory-driven visuals without leaving a trace.

- No recording.
- No saving.
- No analysis.
- No cloud.
- No tracking.

Everything disappears when the session ends.

---

## Features

| Feature | Description |
|--------|-------------|
| Microphone | Captures audio volume (not content) to drive particle behavior |
| Camera | Reads ambient light to affect shimmer and visual glow |
| Motion Sensors | Accelerometer and gyroscope drive visual distortion |
| Location (Optional) | Adds procedural randomness, discarded instantly |
| Visuals | Shader-based particle field reacting to real-time inputs |
| Privacy | No data stored, no network access, no tracking |
| Platform | Built in Unity for Android |

---

## Sensor Mapping

| Sensor         | Mapped To                                  |
|----------------|--------------------------------------------|
| Microphone     | Volume → Particle turbulence, visual intensity |
| Camera         | Ambient light → Glow and shimmer           |
| Accelerometer  | Motion → Field distortion                  |
| Gyroscope      | Rotation → Field tilt                      |
| Location       | Pseudo-random offsets → Visual entropy     |
| Time           | Modulates animation and fade transitions   |

---

## Screens & Flow

1. **Title Screen**
   - App title: "The Void"
   - Buttons:
     - "Enter The Void" → Starts session
     - "Privacy Statement" → Shows data policy

2. **Privacy Statement**
   - Explanation of data usage (or lack thereof)
   - No data collection or identifiers used

3. **Session Mode**
   - Real-time sensor-based abstract visuals
   - No waveform, no speech display, no saving
   - Particle field responds to your presence

4. **End Session**
   - “The Void has heard you and will now depart.”
   - Sensors are released, everything disappears

---

## Installation / Build (Unity)

### Requirements
- Unity 2022.3+ (URP enabled)
- Android Build Support (or Desktop)
- Microphone & Camera permissions

### To Build:
1. Open the project in Unity
2. Ensure `VoidScene` is in build settings
3. Build to Android (or test in Editor with mock sensors)
4. Disable Internet permission in Player Settings for offline-only mode

---

## Privacy & Ethics

> “Your secret is safe in the void.”

| Principle | Implementation |
|----------|----------------|
| No storage | Audio, video, and sensor data are never saved |
| No analysis | No speech-to-text, no AI, no cloud |
| No network | Internet permissions are stripped from the build |
| No identifiers | No user ID, account, or analytics present |
| Open-source | Codebase is transparent to build trust |

---

## License

This project is intended to be open-source and privacy-centered. You are encouraged to review, modify, and redistribute responsibly.

---

## Credits & Tech Stack

- **Engine:** Unity (URP)
- **Visuals:** Shader Graph, Particle Systems
- **Input:** Microphone, Camera, Accelerometer, Gyroscope, GPS
- **Code:** C#, Unity APIs
- **UI:** Canvas-based, minimal

---

## Contributing

Contributions, forks, and transparency reviews are welcome. Submit pull requests or issues if you’d like to expand the visual system, support more platforms, or improve accessibility.

---

## Final Word

**The Void is not an app. It’s a ritual.**  
When you're overwhelmed, unheard, or just need to release something without consequence —  
**step into the Void.**

---
