# KITCHEN HERO
> A wicked problem is a problem that is difficult or impossible to solve because of incomplete, contradictory, and changing requirements that are often difficult to recognize. [Wikipedia](https://en.wikipedia.org/wiki/Wicked_problem)

## 1. Introduction
### 1.1 The topic
Our team [Roze Koeken](https://www.facebook.com/rozekoekenGGJ2019/) is presenting an approach to solve one of the wicked problems in the world, under the given topic of the Game Jam, "Food for Possible Futures". We focused on drawing attention to the problem of food waste.

### 1.2 Rationale
PSAs are important because they alarm the audience of the seriousness of problems. But not every alarms ring right next to your ears. PSAs can be educational, and games can also be educational. We decided to create a cooking game that instructs player a recipe and virtually introduce an opportunity to cook, store leftover ingredients, and dispose food wastes. Players will not only intuitively learn different ways to dispose food wastes by playing our game, but also acknowledge the consequence of not disposing them accordingly.

### 1.3 Ideas
> 1. Cooking recipes should be shown spontaneously.
> 2. The game should be interactive but different from an old-school cooking games.
>     1. Controllers should be supported to make the game physically interactive.
>     2. Ingredients should be automatically moved by a conveyor belt.
>     3. The genre of the game in general should be rhythm action.
> 3. Ways to dispose different food wastes should be informed.
>     1. Food wastes should be produced by every user action.
>         1. e.g.) Chop an onion by swinging a controller horizontally -> onion peel
>     2. This step should be shown as another minigame after the cooking phase.

### 1.4 Note
We later admitted that our game idea was under a great influence of [**Rhythm Heaven**](https://en.wikipedia.org/wiki/Rhythm_Heaven).

<hr/>

## 2. The Game

> This project is unfinished and was poorly graded in the final submission stage of the event.
Currently abandoned and is waiting to be finished in the future.

### 2.1 Screenshot
* <img src="https://i.imgur.com/ntxbTyf.png" width="374.3px" height="437px" title="" alt=""></img>
* <img src="https://media.giphy.com/media/KbTQEVj6jTB5b9yJ47/giphy.gif" width="700px" height="437px" title="" alt=""></img>
* <img src="https://media.giphy.com/media/XHAo0cJPJ9enK9UDyb/giphy.gif" width="700px" height="437px" title="" alt=""></img>

### 2.2 Gameplay
The game was **supposed to be** a rhythm action game that a player swings his controller according to each situation one encounter while cooking, such as chopping with knife, pouring water to cup, frying rice on pan, and wrapping ingredients with plastic bags. The actions should happen on specific timings along a background music, which is similar to most rhythm action games.

Controller support was implemented by using a mobile phone with Unity Remote 5 installed. The game uses the gyroscope & accelerometer sensor values to determine the user action. See [Assets/Scripts/UI/UiEvent.cs](https://github.com/sean-sanguk-lee/KitchenHero/blob/master/Project/GAGJ2019-07-43/Assets/Scripts/UI/UIEvent.cs).

### 2.3 Future Todos
1. Fix all animations
2. Adding ingredients to a cart
3. Storing leftover ingredients to a fridge
4. Rhythm game support (Might need restructuring of the entire game)
5. Food waste disposal minigame
6. More recipes

<hr/>

## 3. Credits
* Lead: [Sean (Sang-Uk) Lee](https://github.com/sean-sanguk-lee)
* Programmer: [Dongjun Kim](https://www.facebook.com/profile.php?id=100009739864418)
* Programmer: [김진형](https://www.facebook.com/profile.php?id=100013656583498)
* Musician: [Michiel De Groot](https://www.facebook.com/profile.php?id=100008298185504)
* Artist: [박정윤](https://www.facebook.com/profile.php?id=100004908069959)
* This readme is writen by Sean (Sang-Uk) Lee
