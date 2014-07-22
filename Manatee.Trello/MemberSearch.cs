﻿/***************************************************************************************

	Copyright 2014 Greg Dennis

	   Licensed under the Apache License, Version 2.0 (the "License");
	   you may not use this file except in compliance with the License.
	   You may obtain a copy of the License at

		 http://www.apache.org/licenses/LICENSE-2.0

	   Unless required by applicable law or agreed to in writing, software
	   distributed under the License is distributed on an "AS IS" BASIS,
	   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
	   See the License for the specific language governing permissions and
	   limitations under the License.
 
	File Name:		MemberSearch.cs
	Namespace:		Manatee.Trello
	Class Name:		MemberSearch
	Purpose:		Represents a member search.

***************************************************************************************/

using System.Collections.Generic;
using Manatee.Trello.Internal;
using Manatee.Trello.Internal.Synchronization;
using Manatee.Trello.Internal.Validation;

namespace Manatee.Trello
{
	public class MemberSearch
	{
		private readonly Field<Board> _board;
		private readonly Field<int?> _limit;
		private readonly Field<Organization> _organization;
		private readonly Field<string> _query;
		private readonly Field<bool?> _restrictToOrganization;
		private readonly Field<IEnumerable<MemberSearchResult>> _results;
		private readonly MemberSearchContext _context;

		public IEnumerable<MemberSearchResult> Results { get { return _results.Value; } }

		private Board Board
		{
			get { return _board.Value; }
			set { _board.Value = value; }
		}
		private int? Limit
		{
			get { return _limit.Value; }
			set { _limit.Value = value; }
		}
		private Organization Organization
		{
			get { return _organization.Value; }
			set { _organization.Value = value; }
		}
		private string Query
		{
			get { return _query.Value; }
			set { _query.Value = value; }
		}
		private bool? RestrictToOrganization
		{
			get { return _restrictToOrganization.Value; }
			set { _restrictToOrganization.Value = value; }
		}

		public MemberSearch(string query, int? limit = null, Board board = null, Organization organization = null, bool? restrictToOrganization = null)
		{
			_context = new MemberSearchContext();

			_board = new Field<Board>(_context, () => Board);
			_limit = new Field<int?>(_context, () => Limit);
			_limit.AddRule(NullableHasValueRule<int>.Instance);
			_limit.AddRule(new NumericRule<int> { Min = 1, Max = 20 });
			_organization = new Field<Organization>(_context, () => Organization);
			_query = new Field<string>(_context, () => Query);
			_query.AddRule(NotNullOrWhiteSpaceRule.Instance);
			_restrictToOrganization = new Field<bool?>(_context, () => RestrictToOrganization);
			_results = new Field<IEnumerable<MemberSearchResult>>(_context, () => Results);

			Query = query;
			Limit = limit;
			Board = board;
			Organization = organization;
			RestrictToOrganization = restrictToOrganization;
		}
	}
}