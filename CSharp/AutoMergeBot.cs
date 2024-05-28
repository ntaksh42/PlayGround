using Microsoft.TeamFoundation.SourceControl.WebApi;
using Microsoft.VisualStudio.Services.Common;
using Microsoft.VisualStudio.Services.WebApi;

namespace AutoMergeBot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var uri = new Uri("https://dev.azure.com/myorg/");
            var personalAccessToken = "";
            var credentials = new VssBasicCredential(string.Empty, personalAccessToken);

            var connection = new VssConnection(uri, credentials);

            var gitClient = connection.GetClient<GitHttpClient>();

            var repos = gitClient.GetRepositoriesAsync().Result;
            var reposId = new Guid("");//ForkしたReposのID
            var pullRequest = new GitPullRequest
            {
                Title = "My Pull Request",
                Description = "This is a pull request created from C#",
                SourceRefName = "refs/heads/main",
                TargetRefName = "refs/heads/main",

                ForkSource = new GitForkRef
                {
                    Repository = new GitRepository
                    {
                        Id = new Guid(""),//Fork元のReposのID
                    },
                    Name = "refs/heads/main"
                }
            };
            var ret = gitClient.CreatePullRequestAsync(pullRequest, reposId);
        }
    }
}
