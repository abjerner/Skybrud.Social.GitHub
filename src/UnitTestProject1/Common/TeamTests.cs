using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Enums;
using Skybrud.Social.GitHub.Models.Common;
using Skybrud.Social.GitHub.Models.Teams;

// ReSharper disable once InconsistentNaming

namespace UnitTestProject1.Common {

    [TestClass]
    public class PermissionLevelTests {

        [TestMethod]
        public void GetEnumValues() {

            Assert.AreEqual(8, EnumUtils.GetEnumValues<GitHubPermissionLevel>().Length);

            Assert.AreEqual(-1, (int) GitHubPermissionLevel.Unrecognized);
            Assert.AreEqual(+0, (int) GitHubPermissionLevel.Unspecified);
            Assert.AreEqual(+1, (int) GitHubPermissionLevel.None);
            Assert.AreEqual(+2, (int) GitHubPermissionLevel.Pull);
            Assert.AreEqual(+3, (int) GitHubPermissionLevel.Push);
            Assert.AreEqual(+4, (int) GitHubPermissionLevel.Read);
            Assert.AreEqual(+5, (int) GitHubPermissionLevel.Write);
            Assert.AreEqual(+6, (int) GitHubPermissionLevel.Admin);

        }

        [TestMethod]
        public void Unrecognized() {

            JObject json = new JObject {
                { "permission", "nope" }
            };

            GitHubTeamItem team = GitHubTeamItem.Parse(json);

            Assert.AreEqual(GitHubPermissionLevel.Unrecognized, team.Permission);

        }

        [TestMethod]
        public void Unspecified() {

            JObject json = new JObject();

            GitHubTeamItem team = GitHubTeamItem.Parse(json);

            Assert.AreEqual(GitHubPermissionLevel.Unspecified, team.Permission);

        }

        [TestMethod]
        public void None() {

            JObject json = new JObject {
                { "permission", "none" }
            };

            GitHubTeamItem team = GitHubTeamItem.Parse(json);

            Assert.AreEqual(GitHubPermissionLevel.None, team.Permission);

        }

        [TestMethod]
        public void Pull() {

            JObject json = new JObject {
                { "permission", "pull" }
            };

            GitHubTeamItem team = GitHubTeamItem.Parse(json);

            Assert.AreEqual(GitHubPermissionLevel.Pull, team.Permission);

        }

        [TestMethod]
        public void Push() {

            JObject json = new JObject {
                { "permission", "push" }
            };

            GitHubTeamItem team = GitHubTeamItem.Parse(json);

            Assert.AreEqual(GitHubPermissionLevel.Push, team.Permission);

        }

        [TestMethod]
        public void Read() {

            JObject json = new JObject {
                { "permission", "read" }
            };

            GitHubTeamItem team = GitHubTeamItem.Parse(json);

            Assert.AreEqual(GitHubPermissionLevel.Read, team.Permission);

        }

        [TestMethod]
        public void Write() {

            JObject json = new JObject {
                { "permission", "write" }
            };

            GitHubTeamItem team = GitHubTeamItem.Parse(json);

            Assert.AreEqual(GitHubPermissionLevel.Write, team.Permission);

        }

        [TestMethod]
        public void Admin() {

            JObject json = new JObject {
                { "permission", "admin" }
            };

            GitHubTeamItem team = GitHubTeamItem.Parse(json);

            Assert.AreEqual(GitHubPermissionLevel.Admin, team.Permission);

        }

    }

}