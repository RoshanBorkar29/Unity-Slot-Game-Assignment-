# Unity Slot Machine Game

## Overview

A simple slot machine game developed in Unity using object-oriented programming principles. The game features three spinning reels with randomized symbols, balance management, payout calculations, sound effects, and smooth reel-stop animations. Players win when all three reels display the same symbol.

---

## Features

* Three slot machine reels
* Random Number Generator (RNG) based outcomes
* Win detection system
* Balance and payout management
* Spin cost deduction
* Sound effects for spin, win, and lose events
* Reel stop bounce animation
* Animated result text
* WebGL build support
* Object-Oriented Programming (OOP) architecture

---

## Winning Logic

A player wins when all three reels display the same symbol.

Example:

7️⃣ 7️⃣ 7️⃣ → WIN

🍒 🍒 🍒 → WIN

🔔 🔔 🔔 → WIN

Any other combination results in a loss.

---

## Controls

| Action     | Control                   |
| ---------- | ------------------------- |
| Spin Reels | Click the **SPIN** button |

---

## Project Structure

```text
Assets
│
├── Scenes
├── Scripts
│   ├── SlotMachine.cs
│   ├── Reel.cs
│   ├── SlotSymbol.cs
│   └── AudioManager.cs
│
├── Prefabs
├── Animations
├── Sounds
├── UI
└── Sprites
```

---

## Scripts Overview

### SlotMachine.cs

Handles:

* Reel spinning logic
* Win detection
* Payout calculation
* Balance updates
* UI updates

### Reel.cs

Handles:

* Symbol display
* Random symbol generation
* Reel stop animation

### AudioManager.cs

Handles:

* Spin sound effects
* Win sound effects
* Lose sound effects

### SlotSymbol.cs

Stores:

* Symbol name
* Symbol sprite
* Payout value

---

## How to Run

### Unity Editor

1. Open the project in Unity 2022.3 LTS or newer.
2. Open the MainScene.
3. Press Play.

### WebGL Build

1. Navigate to:

```text
Build/WebGL
```

2. Open the generated WebGL build using a local web server or Unity Build & Run.

---

## Technical Details

* Engine: Unity 2022.3 LTS
* Platform: WebGL
* Language: C#
* Architecture: Object-Oriented Programming (OOP)

---

## Development Approach

The project was designed using a modular architecture to keep gameplay logic, reel behavior, audio management, and symbol data separated into independent components.

Random outcomes are generated using Unity's built-in RNG system. The reels visually spin using randomized symbol updates before stopping on pre-selected final symbols, ensuring consistent win detection and gameplay behavior.

---

## Future Improvements

* Advanced reel scrolling animations
* Jackpot system
* Additional symbols and payouts
* Particle effects
* Mobile support

---

## Author

Roshan Borkar
