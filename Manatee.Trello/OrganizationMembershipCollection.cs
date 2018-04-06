﻿using System;
using System.Collections.Generic;
using Manatee.Trello.Internal.DataAccess;
using Manatee.Trello.Internal.Validation;
using Manatee.Trello.Json;

namespace Manatee.Trello
{
	/// <summary>
	/// A collection of organization memberships.
	/// </summary>
	public class OrganizationMembershipCollection : ReadOnlyOrganizationMembershipCollection, IOrganizationMembershipCollection
	{
		internal OrganizationMembershipCollection(Func<string> getOwnerId, TrelloAuthorization auth)
			: base(getOwnerId, auth) {}

		/// <summary>
		/// Adds a member to an organization with specified privileges.
		/// </summary>
		/// <param name="member">The member to add.</param>
		/// <param name="membership">The membership type.</param>
		public void Add(IMember member, OrganizationMembershipType membership)
		{
			var error = NotNullRule<IMember>.Instance.Validate(null, member);
			if (error != null)
				throw new ValidationException<IMember>(member, new[] {error});

			var json = TrelloConfiguration.JsonFactory.Create<IJsonOrganizationMembership>();
			json.Member = ((Member) member).Json;
			json.MemberType = membership;

			var endpoint = EndpointFactory.Build(EntityRequestType.Organization_Write_AddOrUpdateMember, new Dictionary<string, object> {{"_id", OwnerId}, {"_memberId", member.Id}});
			JsonRepository.Execute(Auth, endpoint, json);
		}
		/// <summary>
		/// Removes a member from an organization.
		/// </summary>
		/// <param name="member">The member to remove.</param>
		public void Remove(IMember member)
		{
			var error = NotNullRule<IMember>.Instance.Validate(null, member);
			if (error != null)
				throw new ValidationException<IMember>(member, new[] {error});

			var json = TrelloConfiguration.JsonFactory.Create<IJsonParameter>();
			json.String = member.Id;

			var endpoint = EndpointFactory.Build(EntityRequestType.Organization_Write_RemoveMember, new Dictionary<string, object> {{"_id", OwnerId}, {"_memberId", member.Id}});
			JsonRepository.Execute(Auth, endpoint, json);
		}
	}
}