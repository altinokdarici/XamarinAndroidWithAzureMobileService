using System;
using Microsoft.WindowsAzure.MobileServices;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace BlogSample
{
	public class MobileServiceRepository
	{
		public static MobileServiceClient MobileServiceClient = new MobileServiceClient ("URL","APP KEY");

		private readonly IMobileServiceTable<Post> tableClient =null;

		public MobileServiceRepository ()
		{
			CurrentPlatform.Init ();
			tableClient = MobileServiceClient.GetTable<Post> ();
		}

		public async Task AddPost(string text)
		{
			await tableClient.InsertAsync (new Post () { Text = text });
		}

		public async Task<List<string>> GetPosts()
		{
			return await tableClient.Select (x => x.Text).ToListAsync ();
		}
	}
}

