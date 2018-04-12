﻿using System.Threading;
using System.Threading.Tasks;
using Manatee.Trello.Internal.Caching;
using Manatee.Trello.Internal.Synchronization;

namespace Manatee.Trello
{
	/// <summary>
	/// A read-only collection of image previews for attachments.
	/// </summary>
	public class ReadOnlyAttachmentPreviewCollection : ReadOnlyCollection<IImagePreview>
	{
		private readonly AttachmentContext _context;

		internal ReadOnlyAttachmentPreviewCollection(AttachmentContext context, TrelloAuthorization auth)
			: base(() => context.Data.Id, auth)
		{
			_context = context;
		}

		/// <summary>
		/// Implement to provide data to the collection.
		/// </summary>
		public sealed override async Task Refresh(CancellationToken ct = default(CancellationToken))
		{
			await _context.Synchronize(ct);
			if (_context.Data.Previews == null) return;
			Items.Clear();
			foreach (var jsonPreview in _context.Data.Previews)
			{
				var preview = jsonPreview.GetFromCache<ImagePreview>(Auth);
				Items.Add(preview);
			}
		}
	}
}