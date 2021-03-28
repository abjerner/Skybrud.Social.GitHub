using Microsoft.VisualStudio.TestTools.UnitTesting;
using Skybrud.Social.GitHub;

// ReSharper disable InconsistentNaming

namespace UnitTestProject1 {
    
    [TestClass]
    public class ServiceTests {

        [TestMethod]
        public void Constructor1() {

            GitHubService service = new GitHubService();

            Assert.IsNotNull(service.Client);
            Assert.IsNotNull(service.Commits);
            Assert.IsNotNull(service.Issues);
            Assert.IsNotNull(service.Organizations);
            Assert.IsNotNull(service.PullRequests);
            Assert.IsNotNull(service.Repositories);
            Assert.IsNotNull(service.Teams);
            Assert.IsNotNull(service.User);
            Assert.IsNotNull(service.Users);

        }

        [TestMethod]
        public void Constructor2() {

            GitHubService service = GitHubService.CreateFromAccessToken("1234");

            Assert.IsNotNull(service.Client);
            Assert.IsNotNull(service.Commits);
            Assert.IsNotNull(service.Issues);
            Assert.IsNotNull(service.Organizations);
            Assert.IsNotNull(service.PullRequests);
            Assert.IsNotNull(service.Repositories);
            Assert.IsNotNull(service.Teams);
            Assert.IsNotNull(service.User);
            Assert.IsNotNull(service.Users);

            Assert.AreEqual("1234", service.Client.AccessToken);

        }

    }

}