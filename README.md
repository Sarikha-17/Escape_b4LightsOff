Escape b4 Lights Out is a psychological horror experience developed during a 24-hour sprint for Gamethon 2026. The game follows a protagonist returning to his abandoned home to solve the mystery of his wife’s disappearance, only to confront the fractured reality of his own memory.

This repository contains the Vertical Slice (Floor 1), demonstrating the core environmental interaction and puzzle-solving mechanics.

The Narrative
Years after his wife vanished, a man returns to his former home, driven by a sudden urge to find the truth. As he navigates the house, the atmosphere shifts. On the first floor, he must confront a literal and metaphorical "reflection" of the past. 
The Twist:As the player progresses toward the upper floors, they discover that the protagonist's mental disorder has obscured a dark reality—he is the one responsible for the tragedy he is investigating.

Technical Implementation (Floor 1)
As the sole developer, I implemented the following systems in **Unity (C#)**:

1. State-Gated Progression
The transition to the next level is locked behind a Boolean Logic Gate. The player cannot access the "Door Trigger" until the Mirror Puzzle state is set to True.

2. Environmental Interaction & Physics
* Destructible Elements: Players must use physical objects (e.g., a log) to break the mirror mesh.
* Raycast Interaction: A crosshair-based raycasting system allows for precise interaction with world-space objects.

3. Decoupled UI Systems
World-Space Canvas: The input field for the puzzle is mapped to the 3D wall behind the mirror, ensuring immersive interaction.
Event-Driven Logic: Used OnEndEdit listeners to bridge the TMP (TextMeshPro) input buffer with the FloorProgression controller.

Key Scripts
MirrorPuzzle.cs: Handles string validation and case-insensitive answer checking.
FloorProgression.cs: Manages the scene transition logic and the `isUnlocked` state of the level.
PlayerController: Custom FPS controller adapted for high-tension horror movement.


How to Play
1.  Explore: Search the first floor for clues.
2.  Interact: Find the object needed to break the mirror.
3.  Reveal:Access the hidden input field revealed behind the glass.
4.  Solve: Enter the correct answer to unlock the exit.
5.  Progress: Enter the door trigger to ascend to the second floor.

Hackathon Achievements
Duration: 24 Hours
Role:Lead Developer (Solo)
Outcome: Provisional Internship Offer from **Distinct Systems & Technologies Pvt. Ltd.
