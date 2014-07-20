/***************************************************************************************

	Copyright 2013 Little Crab Solutions

	   Licensed under the Apache License, Version 2.0 (the "License");
	   you may not use this file except in compliance with the License.
	   You may obtain a copy of the License at

		 http://www.apache.org/licenses/LICENSE-2.0

	   Unless required by applicable law or agreed to in writing, software
	   distributed under the License is distributed on an "AS IS" BASIS,
	   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
	   See the License for the specific language governing permissions and
	   limitations under the License.
 
	File Name:		IJsonBoardPreferences.cs
	Namespace:		Manatee.Trello.Json
	Class Name:		IJsonBoardPreferences
	Purpose:		Defines the JSON structure for the BoardPreferences object.

***************************************************************************************/
namespace Manatee.Trello.Json
{
	/// <summary>
	/// Defines the JSON structure for the BoardPreferences object.
	/// </summary>
	public interface IJsonBoardPreferences
	{
		/// <summary>
		/// Gets or sets who may view the board.
		/// </summary>
		BoardPermissionLevel PermissionLevel { get; set; }
		/// <summary>
		/// Gets or sets who may vote on cards.
		/// </summary>
		BoardVotingPermission Voting { get; set; }
		/// <summary>
		/// Gets or sets who may comment on cards.
		/// </summary>
		BoardCommentPermission Comments { get; set; }
		/// <summary>
		/// Gets or sets who may extend invitations to join the board.
		/// </summary>
		BoardInvitationPermission Invitations { get; set; }
		/// <summary>
		/// Gets or sets whether any Trello member may join a board without an invitation.
		/// </summary>
		bool? SelfJoin { get; set; }
		/// <summary>
		/// Gets or sets whether card covers are shown on the board.
		/// </summary>
		bool? CardCovers { get; set; }
	}
}