# Candy Crush Algorithm

## Overview
This repository contains an implementation of a simple **Candy Crush** algorithm in C#. The algorithm repeatedly finds and crushes candies, then shifts the remaining candies down until no more candies can be crushed.

## Rules:
The given board represents the state of the game following the player's move. Now, you need to restore the board to a stable state by crushing candies according to the following rules:
1. If three or more candies of the same type are adjacent vertically or horizontally, crush them all at the same time - these positions become empty.
2. After crushing all candies simultaneously, if an empty space on the board has candies on top of itself, then these candies will drop until they hit a candy or bottom at the same time. No new candies will drop outside the top boundary.
3. After the above steps, more candies may exist that can be crushed. If so, you need to repeat the above steps.
If there are no more candies that can be crushed, then return the current board.

## Features
- Identifies and crushes adjacent candies (horizontally and vertically)
- Handles shifting of candies after crushing
- Runs iteratively until no more candies can be crushed

## Implementation Details
The algorithm follows these main steps:
1. **Find candies to crush:** Locate groups of three or more adjacent candies (vertically or horizontally).
2. **Crush candies:** Set matched candies to zero.
3. **Shift candies down:** Move candies downward to fill empty spaces.
4. **Repeat** until no more candies can be crushed.

## Code Structure
- `CandyCrush(int[][] board)`: Main function that executes the crushing and shifting process iteratively.
- `FindCandyToCrush(int[][] board, int rows, int cols)`: Identifies candies to be crushed.
- `CrushCandy(int[][] board, HashSet<(int, int)> hashSet)`: Crushes identified candies by setting them to zero.
- `ShiftCandiesToEmptySpaces(int[][] board, int rows, int cols)`: Moves candies down to fill empty spaces.

## Example
### Input:
```csharp
board =
[
  [110,5,112,113,114],
  [210,211,5,213,214],
  [310,311,3,313,314],
  [410,411,412,5,414],
  [5,1,512,3,3],
  [610,4,1,613,614],
  [710,1,2,713,714],
  [810,1,2,1,1],
  [1,1,2,2,2],
  [4,1,4,4,1014]
]
```
### Output (after Candy Crush Algorithm runs):
```
[
  [0,0,0,0,0],
  [0,0,0,0,0],
  [0,0,0,0,0],
  [110,0,0,0,114],
  [210,0,0,0,214],
  [310,0,0,113,314],
  [410,0,0,213,414],
  [610,211,112,313,614],
  [710,311,412,613,714],
  [810,411,512,713,1014]
]
```

## Complexity Analysis
- **Time Complexity:** $$O(M^2 * N^2)$$
- **Space Complexity:** $$O(M * N)$$
