using Microsoft.Extensions.Configuration;
using Statiq.Common;
using Statiq.Core;
using Statiq.Markdown;
using Statiq.Yaml;
using System;
using System.Text;

namespace PhotoPitLive
{
    public class MusicGigsPipeline : Pipeline
    {
        public MusicGigsPipeline()
        {
            DependencyOf.Add(nameof(Statiq.Web.Pipelines.Inputs));
            DependencyOf.Add(nameof(Statiq.Web.Pipelines.Content));

            InputModules = new ModuleList{
              new MusicGigsModule(),
            };

            ProcessModules = new ModuleList {
                new SetContent(Config.FromDocument(doc => doc.GetString("Artist")), MediaTypes.Markdown),
                new RenderMarkdown(),
                new SetDestination(Config.FromDocument(doc => new NormalizedPath($"gigs2/{doc.GetString("GigMonth3")}.html").OptimizeFileName()))};

            OutputModules = new ModuleList {
              new WriteFiles()
          };
        }
    }
}
