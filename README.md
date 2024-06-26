# Racing Game

I implemented a prototype of a racing game like NFS/Forza Horizon arcade style type of game in Unity.



## Youtube Video

https://www.youtube.com/watch?v=I7c6Vi6ErKM&t=44s



## Materials and models

The race track is made of parts of roads from a free unity library.

The car is a free blender model.

The main menu is a photo from the internet.

Everything else (The Start Arch, The Flags, Menus UI) is made by me using unity's assets (Probuilder, TextMeshPro, etc.).

The soundtracks are free and downloaded from the internet.



## Scenes

The game has 2 scenes: MainMenuScene and GameScene.



## Main Menu

MainMenuScene has 2 functional 2D menus, with a background that is blended with a gray accent.

The menus are the main menu (with play, options and quit buttons) and the options menu (with buttons and a slider).

In this scene there is a sound track playing on loop that captivates the player.



## Game Scene

GameScene has a race track, a car for the player and a car for the AI.

The Game starts with a camera slide down and fixating behind the player's car.

Even though the car it's a free blender model, I had to manually separate the wheels from the car in order to have a functional car controller.

By researching how Unity's wheel colliders work and learning the technical side of how a car works using programming, I managed to program a car that is accelerating, breaking and steering using user inputs, in an arcade way that isn't predictable and makes the car fun to drive.

The hardest part of this project was definitely the implementation of a car AI in Unity. Using the power of google I researched how should I approach this problem and I settled to try and create a checkpoint system that the AI follows.

The checkpoints are linked to one another and to make it visually easier to see and to debug I used Gizmos to draw a line between the checkpoints which are a cube only with a collider and without a mesh. Additionally the checkpoints contain a speed limit that the AI has to respect.

The AI controller is similar to the normal car controller but it had to accelerate, brake and steer based on the checkpoints position and the speed limit.

In order to make it easier to debug I used Debug.DrawRay to see where the car is headed. I also dealt with collisions and made the AI car stop if it collides with another car using Phisics.Raycast.

A laps system had to be implemented and I chose to use the checkpoints that I made for the AI car to make all cars respect the race track and not skip checkpoints or do laps by turning in circles which is debugged by using print whenever it is a correct checkpoint or an incorrect checkpoint.

Additionally I tracked the lap, lap time, best lap, best lap time for each car to display them on the screen and to use at the end game menu.

When the player finishes the last lap he will see an end game menu that shows if he won or lost the race, his overall time, his best lap, the AI time if it finished and the player can choose to go back to main menu or to quit the game.

There is also a Pause Menu that pops up when we press 'P'. The time freezes and we can choose to resume, to go back to main menu or to quit the game.

For audio sources I made a soundtrack loop in the background and when holding the W key until it is released there is a car acceleration sound and when holding down the S or Space key until released there is a car breaking sound.



## Observations and plans for the future

My first game in Unity has been a tough challenge, I don't consider it a finished project but with the deadline comping up, I am proud with what I achieved so far.

I will surely continue to make it a deeper experience.

I have plans to make it a night experience with some emissive lights that will give a fast and furious vibe, make it more versatile and build a variety of tracks and worlds. 

For sure I will do a custom soundtrack and sounds for the cars to make it more fun and encapsulate the night ride vibe and experiment with music and sound effects programs.
