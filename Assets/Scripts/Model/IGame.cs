using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
///  This interface provides read-only access to a Tic-tac-toe game state.
/// </summary>
/// <remarks>
///  <para>
///   The <c>IGame</c> interface describes the state of a Tic-tac-toe game, but does not provide any methods for 
///   changing this state. That makes it safe for passing to application components that are not supposed to modify the 
///   game state directly, such as game view or computer player components.
///  </para>
///  <para>
///   All mutations to the model outside of it should be made through <see cref="">IGameController</see> requests. 
///   By having such centralized approach it's more easy to reason about the whole system behavior.
///  </para>
/// </remarks>
public interface IGame
{

    /// <summary>
    ///  This property describes the number of columns of the game board.
    /// </summary>
    /// <remarks>
    ///  It is unlikely that game board size will ever change during the game. In fact current realization supports 
    ///  only one board size that has 3 columns and 3 rows.
    /// </remarks>
    /// <value>The number of columns of the game board.</value>
    int ColumnsAmount { get; }

    /// <summary>
    ///  This property describes the number of rows of the game board.
    /// </summary>
    /// <remarks>
    ///  It is unlikely that game board size will ever change during the game. In fact current realization supports 
    ///  only one board size that has 3 columns and 3 rows.
    /// </remarks>
    /// <value>The number of rows of the game board.</value>
    int RowsAmount { get; }
    
    /// <summary>
    ///  This method returns the mark on board on given position.
    /// </summary>
    /// <param name="column">The index of the column.</param>
    /// <param name="row">The index of the row.</param>
    /// <returns>The mark on given position if position is valid, otherwise the method behavior is undefined.</returns>
    Mark GetMark(int column, int row);

    /// <summary>
    ///  This method returns the mark witch should be put next on the game board. 
    ///  Possible values are either <see cref="Mark.Cross"/> or <see cref="Mark.Nought"/>.
    /// </summary>
    /// <returns>
    ///  Either <see cref="Mark.Cross"/> or <see cref="Mark.Nought"/> depending on which player should make a move.
    /// </returns>
    Mark GetCurrentTurn();

    /// <summary>
    ///  <para>
    ///   This method indicates if the game is overred. Once the game is overred, it does not change its state.
    ///  </para>
    ///  <para>
    ///   There are two ways for a game to become overred. 
    ///  </para>
    ///  <para>
    ///   One is when one of players puts three mark in a line.
    ///   In this case he becomes a winner, and his mark as well as the winning line become accessible as properties of
    ///   this interface.
    ///  </para>
    ///  <para>
    ///   Other way is when all positions on the game board have been marked so there are no possible 
    ///   movements for any player left. This is a draw situation when no one wins or looses.
    ///  </para>
    /// </summary>
    /// <returns><c>true</c> if the game is overred, otherwise <c>false</c>.</returns>
    /// <seealso cref="HasWinner"/>
    bool IsOverred();

    /// <summary>
    ///  This method indicates if the game overred after one player put three marks in a line. If it's true then 
    ///  <see cref="WinnerMark"/> and <see cref="WinningLine"/> properties are available and represent information about the winner
    ///  and the winning line.
    /// </summary>
    /// <returns><c>true</c> if the game is overred and there is a winner, otherwise <c>false</c>.</returns>
    /// <seealso cref="IsOverred"/>>
    bool HasWinner();

    /// <summary>
    ///  This property contains the mark of the player who has won the game.
    ///  It makes sense only when the game is overred (<see cref="IsOverred"/>) and it has a winner 
    ///  (<see cref="HasWinner"/>).
    /// </summary>
    Mark WinnerMark { get; }

    /// <summary>
    ///  This property represents the line which ended the game. 
    ///  It makes sense only when the game is overred (<see cref="IsOverred"/>) and it has a winner 
    ///  (<see cref="HasWinner"/>).
    /// </summary>
    Line WinningLine { get; }

}
