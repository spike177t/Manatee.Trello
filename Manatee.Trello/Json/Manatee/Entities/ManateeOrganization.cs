﻿/***************************************************************************************

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
 
	File Name:		ManateeOrganization.cs
	Namespace:		Manatee.Trello.Json.Manatee.Entities
	Class Name:		ManateeOrganization
	Purpose:		Implements IJsonOrganization for Manatee.Json.

***************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Manatee.Json;
using Manatee.Json.Enumerations;
using Manatee.Json.Extensions;
using Manatee.Json.Serialization;

namespace Manatee.Trello.Json.Manatee.Entities
{
	internal class ManateeOrganization : IJsonOrganization, IJsonCompatible
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public string DisplayName { get; set; }
		public string Desc { get; set; }
		public string Url { get; set; }
		public string Website { get; set; }
		public string LogoHash { get; set; }
		public List<int> PowerUps { get; set; }

		public void FromJson(JsonValue json)
		{
			if (json.Type != JsonValueType.Object) return;
			var obj = json.Object;
			Id = obj.TryGetString("id");
			Name = obj.TryGetString("name");
			DisplayName = obj.TryGetString("displayName");
			Desc = obj.TryGetString("desc");
			Url = obj.TryGetString("url");
			Website = obj.TryGetString("website");
			LogoHash = obj.TryGetString("logoHash");
			PowerUps = obj.TryGetArray("powerUps").Select(j => (int) j.Number).ToList();
		}
		public JsonValue ToJson()
		{
			return new JsonObject
			       	{
			       		{"id", Id},
			       		{"name", Name},
			       		{"displayName", DisplayName},
			       		{"desc", Desc},
			       		{"url", Url},
			       		{"website", Website},
			       		{"logoHash", LogoHash},
			       		{"powerUps", PowerUps.Cast<double>().ToJson()},
			       	};
		}
	}
}
