using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Enums;
using Skybrud.Social.GitHub.Models.Teams;

// ReSharper disable once InconsistentNaming

namespace UnitTestProject1.Teams {
    
    [TestClass]
    public class TeamTests {

        [TestMethod]
        public void PrivacyLevelEnum() {
            
            Assert.AreEqual(4, EnumUtils.GetEnumValues<GitHubTeamPrivacy>().Length);
            
            Assert.AreEqual(-1, (int) GitHubTeamPrivacy.Unrecognized);
            Assert.AreEqual(+0, (int) GitHubTeamPrivacy.Unspecified);
            Assert.AreEqual(+1, (int) GitHubTeamPrivacy.Secret);
            Assert.AreEqual(+2, (int) GitHubTeamPrivacy.Closed);

        }

        [TestMethod]
        public void PrivacyLevelUnspecified() {

            JObject json = new JObject();

            GitHubTeamItem team = GitHubTeamItem.Parse(json);

            Assert.AreEqual(GitHubTeamPrivacy.Unspecified, team.Privacy);

        }

        [TestMethod]
        public void PrivacyLevelClosed() {

            JObject json = new JObject {
                { "privacy", "closed" }
            };

            GitHubTeamItem team = GitHubTeamItem.Parse(json);

            Assert.AreEqual(GitHubTeamPrivacy.Closed, team.Privacy);

        }

        [TestMethod]
        public void PrivacyLevelSecret() {

            JObject json = new JObject {
                { "privacy", "secret" }
            };

            GitHubTeamItem team = GitHubTeamItem.Parse(json);

            Assert.AreEqual(GitHubTeamPrivacy.Secret, team.Privacy);

        }

        [TestMethod]
        public void PrivacyLevelUnrecognized() {

            JObject json = new JObject {
                { "privacy", "nope" }
            };

            GitHubTeamItem team = GitHubTeamItem.Parse(json);

            Assert.AreEqual(GitHubTeamPrivacy.Unrecognized, team.Privacy);

        }

    }

}