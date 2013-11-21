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
 
	File Name:		IEntityRepository.cs
	Namespace:		Manatee.Trello.Internal.DataAccess
	Class Name:		IEntityRepository
	Purpose:		Defines methods required to retrieve entities from Trello.

***************************************************************************************/

using System.Collections.Generic;

namespace Manatee.Trello.Internal.DataAccess
{
	/// <summary>
	/// Defines methods required to retrieve entities from Trello.
	/// </summary>
	/// <remarks>
	/// This interface is only exposed for unit testing purposes.
	/// </remarks>
	public interface IJsonRepository
	{
		/// <summary />
		T Execute<T>(Endpoint endpoint, IDictionary<string, object> parameters = null)
			where T : class;
	}
}