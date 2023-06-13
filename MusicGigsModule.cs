using Microsoft.Extensions.Configuration;
using NetFabric.Hyperlinq;
using Statiq.Common;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoPitLive
{
    public class MusicGigsModule : Module
    {
        protected override async Task<IEnumerable<IDocument>> ExecuteContextAsync(IExecutionContext context)
        {
            var data = new MusicDataFetch().GetContentFromContentful<MusicGigsEntity>("gigs");

            List<IDocument> outputs = new List<IDocument>();

            foreach (var item in data)
            {
                var StringObject = new Dictionary<string, object>
                {
                    { nameof(item.Artist), item.Artist },
                    { nameof(item.Url), item.Url },
                    { nameof(item.GigDateDisplay), item.GigDateDisplay },
                    { nameof(item.GigMonth3), item.GigMonth3 },
                    { nameof(item.VenueDisplay), item.VenueDisplay },
                    { nameof(item.Venue), item.Venue },
                    { nameof(item.GigDateShortDisplay), item.GigDateShortDisplay },
                };

                var doc = context.CreateDocument(item.Artist, StringObject, item.VenueDisplay);

                outputs.Add(doc);
            }

            return outputs;
        }
    }
}
