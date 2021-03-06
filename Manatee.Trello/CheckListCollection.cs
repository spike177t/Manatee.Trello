﻿using System;
using System.Threading;
using System.Threading.Tasks;
using Manatee.Trello.Internal.DataAccess;
using Manatee.Trello.Internal.Validation;
using Manatee.Trello.Json;

namespace Manatee.Trello
{
	/// <summary>
	/// A collection of checklists.
	/// </summary>
	public class CheckListCollection : ReadOnlyCheckListCollection, ICheckListCollection
	{
		internal CheckListCollection(Func<string> getOwnerId, TrelloAuthorization auth)
			: base(getOwnerId, auth) {}

		/// <summary>
		/// Creates a new checklist, optionally by copying a checklist.
		/// </summary>
		/// <param name="name">The name of the checklist to add.</param>
		/// <param name="source">A checklist to use as a template.</param>
		/// <param name="ct">(Optional) A cancellation token for async processing.</param>
		/// <returns>The <see cref="ICheckList"/> generated by Trello.</returns>
		public async Task<ICheckList> Add(string name, ICheckList source = null, CancellationToken ct = default)
		{
			var error = NotNullOrWhiteSpaceRule.Instance.Validate(null, name);
			if (error != null)
				throw new ValidationException<string>(name, new[] { error });

			var json = TrelloConfiguration.JsonFactory.Create<IJsonCheckList>();
			json.Name = name;
			var jsonCard = TrelloConfiguration.JsonFactory.Create<IJsonCard>();
			jsonCard.Id = OwnerId;
			json.Card = jsonCard;
			if (source != null)
				json.CheckListSource = ((CheckList) source).Json;

			var endpoint = EndpointFactory.Build(EntityRequestType.Card_Write_AddChecklist);
			var newData = await JsonRepository.Execute(Auth, endpoint, json, ct);

			return new CheckList(newData, Auth);
		}
	}
}