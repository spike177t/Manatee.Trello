﻿using System;
using System.Collections.Generic;

namespace Manatee.Trello
{
	/// <summary>
	/// Documents all of the activities in Trello.
	/// </summary>
	public interface IAction : ICacheable
	{
		/// <summary>
		/// Gets the creation date of the action.
		/// </summary>
		DateTime CreationDate { get; }

		/// <summary>
		/// Gets the member who performed the action.
		/// </summary>
		IMember Creator { get; }

		/// <summary>
		/// Gets any data associated with the action.
		/// </summary>
		IActionData Data { get; }

		/// <summary>
		/// Gets the date and time at which the action was performed.
		/// </summary>
		DateTime? Date { get; }

		/// <summary>
		/// Gets the type of action.
		/// </summary>
		ActionType? Type { get; }

		/// <summary>
		/// Raised when data on the action is updated.
		/// </summary>
		event Action<IAction, IEnumerable<string>> Updated;

		/// <summary>
		/// Deletes the card.
		/// </summary>
		/// <remarks>
		/// This permanently deletes the card from Trello's server, however, this object will
		/// remain in memory and all properties will remain accessible.
		/// </remarks>
		void Delete();
	}
}