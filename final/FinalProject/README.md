# ASCII Timed Survival Game

## Table of Contents
- [Overview](#overview)
- [Features](#features)
- [Installation](#installation)
- [Usage](#usage)
- [Controls](#controls)
- [Gameplay Instructions](#gameplay-instructions)
- [Development](#development)
- [License](#license)

## Overview
This is a 2D open world game that runs purely in the terminal using plain C#. The goal of the game is to survive for one minute, avoiding a growing swarm of enemies. The game features menus, multiple enemy types with different behaviors, and a map with obstacles like forests, lakes, and pathways.

## Features
- **Main Menu**: Options to start the game, view instructions, or quit the program.
- **Pause Menu**: Options to resume or quit the current game.
- **Survival Gameplay**: Survive for one minute while enemies spawn and follow the player.
- **Enemy Types**: Multiple enemy types, each with unique movement patterns and lifespans.
- **Map Features**: Landscapes such as forests and lakes that affect both player and enemy movement.

## Installation
1. **Clone the Repository**:
    ```bash
    svn checkout https://github.com/MahonriReynolds/cse210-hw/trunk/final/FinalProject 2d-terminal-open-world-game
    cd 2d-terminal-open-world-game
    ```
2. **Build the Project**:
    - Open the project in your preferred C# IDE (e.g., Visual Studio).
    - Build the solution.

## Usage
1. **Run the Game**:
    - Execute the compiled binary from your terminal or run the project from your IDE.

2. **Main Menu**:
    - **Start Game**: Begin a new game session.
    - **Instructions**: Display gameplay instructions.
    - **Quit**: Exit the program.

3. **Pause Menu**:
    - **Resume**: Resume the current game session.
    - **Main Menu**: Quit the current game and return to the main menu.

## Controls
- **Movement**: Use the arrow keys (`↑`, `↓`, `←`, `→`) to move the player character.
- **Pausing**: Use `Esc` to pause the game.

## Gameplay Instructions
- **Objective**: Survive for one minute while avoiding enemies.
- **Enemies**: Different types of enemies will spawn and follow the player. Each type of enemy has unique movement behavior and lifespan.
- **Map Obstacles**: You are unable to enter forests and lakes. Enemies get lost in lakes and forests.

