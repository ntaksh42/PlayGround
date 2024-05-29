using Microsoft.TeamFoundation.SourceControl.WebApi;
using Microsoft.VisualStudio.Services.Common;
using Microsoft.VisualStudio.Services.Licensing;
using Microsoft.VisualStudio.Services.WebApi;

namespace AutoMergeBot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var condition = PRCreateConditionDecider.Decide(ReposType.Fuga, string.Empty);
            var creator = new PullRequestCreator(Guid.NewGuid(), "", condition);

            creator.Create(out var errMessages);
            
            if (errMessages.Any()) 
            {
                errMessages.ForEach(m => Console.WriteLine(m));
            }
        }
    }

    internal class PullRequestCreator
    {
        private readonly Guid _repositoryId;
        private readonly GitHttpClient _gitHttpClient;
        private readonly IPRCreateCondition _condition;

        public PullRequestCreator(
            Guid repositoryId,
            string pat,
            IPRCreateCondition condition)
        {
            _repositoryId = repositoryId;

            var uri = new Uri("https://dev.azure.com/aksh0402/");
            var credentials = new VssBasicCredential(string.Empty, pat);
            var connection = new VssConnection(uri, credentials);
            _gitHttpClient = connection.GetClient<GitHttpClient>();
            
            _condition = condition;
        }

        public void Create(out IReadOnlyList<string> messageList)
        {
            var tmpMessageList = new List<string>();
            foreach(var dstBranchName in _condition.DstBranchNames)
            {
                var pullRequest = new GitPullRequest
                {
                    Title = "My Pull Request",
                    Description = "This is a pull request created from C#",
                    SourceRefName = $"refs/heads/{_condition.SrcBranchName}",
                    TargetRefName = $"refs/heads/{dstBranchName}",
                };
                try
                {
                    var result = _gitHttpClient.CreatePullRequestAsync(pullRequest, _repositoryId).Result;

                    if(result is not null)
                    {
                        tmpMessageList.Add($"PR Created: {result.Url}");
                    }
                }
                catch (Exception ex) 
                {
                    tmpMessageList.Add($"Create PR Failed!({_condition.SrcBranchName} To {dstBranchName}) Because {ex.Message}");
                }
            }
            messageList = tmpMessageList;
        }
    }

    internal enum ReposType
    {
        Fuga,
        Hoge,
    }

    internal static class PRCreateConditionDecider
    {
        public static IPRCreateCondition Decide(ReposType type, string srcBranchName)
        {
            switch (type)
            {
                case ReposType.Fuga:
                    return new FugaPRCreateCondition(srcBranchName);
                case ReposType.Hoge:
                    return new HogePRCreateCondition(srcBranchName);
                default:
                    break;
            }
            throw new ArgumentException();
        }
    }

    internal class FugaPRCreateCondition : IPRCreateCondition
    {
        private readonly IReadOnlyDictionary<string, string[]> _srcDstBranchNameDic = new Dictionary<string, string[]>
        {
            { "main", new List<string>{"" }.ToArray() },
            { "dev", new List<string>{"" }.ToArray() }
        };

        public FugaPRCreateCondition(string srcBranchName)
        {
            SrcBranchName = srcBranchName;
        }
        public string SrcBranchName { get; init; }

        public string[] DstBranchNames => throw new NotImplementedException();

        public string[] Reviewers => throw new NotImplementedException();
    }

    internal class HogePRCreateCondition : IPRCreateCondition
    {
        private readonly IReadOnlyDictionary<string, string[]> _srcDstBranchNameDic = new Dictionary<string, string[]>
        {
            { "main", new List<string>{"" }.ToArray() },
            { "dev", new List<string>{"" }.ToArray() }
        };

        public HogePRCreateCondition(string srcBranchName)
        {
            SrcBranchName = srcBranchName;
        }

        public string SrcBranchName { get; init; }

        public string[] DstBranchNames => _srcDstBranchNameDic[SrcBranchName];

        public string[] Reviewers { get; } = new List<string>
        {
            "a",
            "b"
        }.ToArray();
    }

    internal interface IPRCreateCondition
    {
        string SrcBranchName { get; init; }
        string[] DstBranchNames { get; }

        string[] Reviewers { get; }
    }
}
