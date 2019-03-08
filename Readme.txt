The solution has two layers
Domain, and api

Domai: 	
	Executes the game via commands and enforces game rules.
	
	Start: Game setups the board with number of squares, number of players, number of ladders and snakes with their heights from configuration.
		The setup involves some validation when ladders and snakes are placed on the board 
			At this time the only rule is that if you step on a ladder or snake you do not end up outside the board.
			But there is no check  if a snake and a ladder will get into a circular move.
	Roll a die: Game will 
		Check if its the turn for the player that rolls. 
		If so, will assign moves to players token (but not move it). 
			Check whether there is a ladder or snake on the square the token will move and returns a result indicating how many squares the token will move
		Otherwise, will return a result reflecting idempoent nature of rolling a die every time you want

	Move: 	The game will check remaining moves of token for the player and move the token to the right square. 
		If the square has a ladder or snake, assigns the range and direction to the tokens remaining moves returns a result indicating player has more moves 

		in which case player can call move again

Api: 
	Receives commands from ANY type of lient on any typ of platform as http requests and passes them to game library.
	Not all commands have endpoints at this time
	Api is not restful
	Does not chose error codes and return in response

Tests: 
	Decent coerage on some classes.
	Poor coverage on Game class

Remarks: 
	There is no data storage, no repository layer ergo, no service layer. 
	There are no feature branches for features on kata page, it's all done on master
	GameSettings not hooked to json... Just hardcoded in igamesettigns implementation
	Ioc container not in place.. 
	But..Hey, those are just the kindof things for a pairing exercise.

Fun exercise.. Way more than 2 hours to deliver a quarter baked solution)

	

	



