# Tetris Shooter

A hybrid puzzle-shooter game built with **Unity 6** that combines Tetris-style block mechanics with turret shooting gameplay.

## Overview

Tetris Shooter blends two classic game concepts:
- **Tetris** — blocks fall and fill the stage in rows
- **Shooter** — control a turret and fire bullets to clear incoming blocks

Manage your ammo, choose your shots wisely, and survive as long as possible while the blocks pile up.

## Gameplay

| Phase | Description |
|-------|-------------|
| **Puzzle Phase** | Position and aim your turret at the falling blocks |
| **Shoot Phase** | Fire a burst of bullets to destroy blocks and clear lines |
| **Stage Update** | The stage advances — surviving blocks drop down |
| **Game Over** | Blocks reach the danger zone |

### Key Mechanics
- 🎯 **Turret** — rotate and shoot bullets toward the block grid
- 💥 **Line Clear** — destroying a full row scores points and triggers effects
- 🎁 **Presents** — special blocks that grant bonus items
- ⚙️ **Items** — power-ups that modify bullets, damage, or the stage
- 🔄 **Reroll** — refresh available items for a cost

## Screenshots
<img width="1852" height="1042" alt="Video Project 10" src="https://github.com/user-attachments/assets/c02b963b-4438-4816-8b62-150f7b4a77c8" />

| Title Screen | Gameplay | Game Over |
|:---:|:---:|:---:|
| *(coming soon)* | *(coming soon)* | *(coming soon)* |

## Controls

| Input | Action |
|-------|--------|
| **Mouse Move** | Aim turret |
| **Left Click** | Shoot |
| **UI Buttons** | Select items / Reroll |

## Built With

- [Unity 6000.3.2f1](https://unity.com/)
- Universal Render Pipeline (URP)
- TextMesh Pro
- Cartoon FX Remaster
- Skybox Cubemap Extended (BOXOPHOBIC)

## Project Structure

```
Assets/
├── Script/          # Core game logic
│   ├── Taiho.cs         — Turret shooting controller
│   ├── Stage.cs         — Block grid and stage management
│   ├── Bullet.cs        — Bullet behaviour
│   ├── TurnPhaseController.cs — Game loop / turn phases
│   ├── ScoreManager.cs  — Score tracking
│   ├── ItemManager.cs   — Item system
│   └── Block/           — Block types and behaviour
├── Kano/            # UI animations and effects
└── BOXOPHOBIC/      # Third-party skybox assets
```

## License

This project is provided as-is for portfolio and educational purposes.
