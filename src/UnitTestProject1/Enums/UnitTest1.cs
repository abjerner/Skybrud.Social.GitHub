using Microsoft.VisualStudio.TestTools.UnitTesting;
using Skybrud.Essentials.Enums;
using Skybrud.Social.GitHub.Models.Events;

// ReSharper disable InconsistentNaming

namespace UnitTestProject1.Enums {
    
    [TestClass]
    public class UnitTest1 {
       
        [TestMethod]
        public void AddedToProject() {
            Assert.AreEqual(GitHubEventType.AddedToProject, EnumUtils.ParseEnum<GitHubEventType>("added_to_project"));
        }

        [TestMethod]
        public void Assigned() {
            Assert.AreEqual(GitHubEventType.Assigned, EnumUtils.ParseEnum<GitHubEventType>("assigned"));
        }

        [TestMethod]
        public void AutomaticBaseChangeFailed() {
            Assert.AreEqual(GitHubEventType.AutomaticBaseChangeFailed, EnumUtils.ParseEnum<GitHubEventType>("automatic_base_change_failed"));
        }

        [TestMethod]
        public void AutomaticBaseChangeSucceeded() {
            Assert.AreEqual(GitHubEventType.AutomaticBaseChangeSucceeded, EnumUtils.ParseEnum<GitHubEventType>("automatic_base_change_succeeded"));
        }

        [TestMethod]
        public void BaseRefChanged() {
            Assert.AreEqual(GitHubEventType.BaseRefChanged, EnumUtils.ParseEnum<GitHubEventType>("base_ref_changed"));
        }

        [TestMethod]
        public void Closed() {
            Assert.AreEqual(GitHubEventType.Closed, EnumUtils.ParseEnum<GitHubEventType>("closed"));
        }

        [TestMethod]
        public void Commented() {
            Assert.AreEqual(GitHubEventType.Commented, EnumUtils.ParseEnum<GitHubEventType>("commented"));
        }

        [TestMethod]
        public void Committed() {
            Assert.AreEqual(GitHubEventType.Committed, EnumUtils.ParseEnum<GitHubEventType>("committed"));
        }

        [TestMethod]
        public void Connected() {
            Assert.AreEqual(GitHubEventType.Connected, EnumUtils.ParseEnum<GitHubEventType>("connected"));
        }

        [TestMethod]
        public void ConvertToDraft() {
            Assert.AreEqual(GitHubEventType.ConvertToDraft, EnumUtils.ParseEnum<GitHubEventType>("convert_to_draft"));
        }

        [TestMethod]
        public void ConvertedNoteToIssue() {
            Assert.AreEqual(GitHubEventType.ConvertedNoteToIssue, EnumUtils.ParseEnum<GitHubEventType>("converted_note_to_issue"));
        }

        [TestMethod]
        public void CrossReferenced() {
            Assert.AreEqual(GitHubEventType.CrossReferenced, EnumUtils.ParseEnum<GitHubEventType>("cross-referenced"));
        }

        [TestMethod]
        public void Demilestoned() {
            Assert.AreEqual(GitHubEventType.Demilestoned, EnumUtils.ParseEnum<GitHubEventType>("demilestoned"));
        }

        [TestMethod]
        public void Deployed() {
            Assert.AreEqual(GitHubEventType.Deployed, EnumUtils.ParseEnum<GitHubEventType>("deployed"));
        }

        [TestMethod]
        public void DeploymentEnvironmentChanged() {
            Assert.AreEqual(GitHubEventType.DeploymentEnvironmentChanged, EnumUtils.ParseEnum<GitHubEventType>("deployment_environment_changed"));
        }

        [TestMethod]
        public void Disconnected() {
            Assert.AreEqual(GitHubEventType.Disconnected, EnumUtils.ParseEnum<GitHubEventType>("disconnected"));
        }

        [TestMethod]
        public void HeadRefDeleted() {
            Assert.AreEqual(GitHubEventType.HeadRefDeleted, EnumUtils.ParseEnum<GitHubEventType>("head_ref_deleted"));
        }

        [TestMethod]
        public void HeadRefRestored() {
            Assert.AreEqual(GitHubEventType.HeadRefRestored, EnumUtils.ParseEnum<GitHubEventType>("head_ref_restored"));
        }

        [TestMethod]
        public void Labeled() {
            Assert.AreEqual(GitHubEventType.Labeled, EnumUtils.ParseEnum<GitHubEventType>("labeled"));
        }

        [TestMethod]
        public void Locked() {
            Assert.AreEqual(GitHubEventType.Locked, EnumUtils.ParseEnum<GitHubEventType>("locked"));
        }

        [TestMethod]
        public void Mentioned() {
            Assert.AreEqual(GitHubEventType.Mentioned, EnumUtils.ParseEnum<GitHubEventType>("mentioned"));
        }

        [TestMethod]
        public void MarkedAsDuplicate() {
            Assert.AreEqual(GitHubEventType.MarkedAsDuplicate, EnumUtils.ParseEnum<GitHubEventType>("marked_as_duplicate"));
        }

        [TestMethod]
        public void Merged() {
            Assert.AreEqual(GitHubEventType.Merged, EnumUtils.ParseEnum<GitHubEventType>("merged"));
        }

        [TestMethod]
        public void Milestoned() {
            Assert.AreEqual(GitHubEventType.Milestoned, EnumUtils.ParseEnum<GitHubEventType>("milestoned"));
        }

        [TestMethod]
        public void MovedColumnsInProject() {
            Assert.AreEqual(GitHubEventType.MovedColumnsInProject, EnumUtils.ParseEnum<GitHubEventType>("moved_columns_in_project"));
        }

        [TestMethod]
        public void Pinned() {
            Assert.AreEqual(GitHubEventType.Pinned, EnumUtils.ParseEnum<GitHubEventType>("pinned"));
        }

        [TestMethod]
        public void ReadyForReview() {
            Assert.AreEqual(GitHubEventType.ReadyForReview, EnumUtils.ParseEnum<GitHubEventType>("ready_for_review"));
        }

        [TestMethod]
        public void Referenced() {
            Assert.AreEqual(GitHubEventType.Referenced, EnumUtils.ParseEnum<GitHubEventType>("referenced"));
        }

        [TestMethod]
        public void RemovedFromProject() {
            Assert.AreEqual(GitHubEventType.RemovedFromProject, EnumUtils.ParseEnum<GitHubEventType>("removed_from_project"));
        }

        [TestMethod]
        public void Renamed() {
            Assert.AreEqual(GitHubEventType.Renamed, EnumUtils.ParseEnum<GitHubEventType>("renamed"));
        }

        [TestMethod]
        public void Reopened() {
            Assert.AreEqual(GitHubEventType.Reopened, EnumUtils.ParseEnum<GitHubEventType>("reopened"));
        }

        [TestMethod]
        public void ReviewDismissed() {
            Assert.AreEqual(GitHubEventType.ReviewDismissed, EnumUtils.ParseEnum<GitHubEventType>("review_dismissed"));
        }

        [TestMethod]
        public void ReviewRequested() {
            Assert.AreEqual(GitHubEventType.ReviewRequested, EnumUtils.ParseEnum<GitHubEventType>("review_requested"));
        }

        [TestMethod]
        public void ReviewRequestRemoved() {
            Assert.AreEqual(GitHubEventType.ReviewRequestRemoved, EnumUtils.ParseEnum<GitHubEventType>("review_request_removed"));
        }

        [TestMethod]
        public void Reviewed() {
            Assert.AreEqual(GitHubEventType.Reviewed, EnumUtils.ParseEnum<GitHubEventType>("reviewed"));
        }

        [TestMethod]
        public void Subscribed() {
            Assert.AreEqual(GitHubEventType.Subscribed, EnumUtils.ParseEnum<GitHubEventType>("subscribed"));
        }

        [TestMethod]
        public void Transferred() {
            Assert.AreEqual(GitHubEventType.Transferred, EnumUtils.ParseEnum<GitHubEventType>("transferred"));
        }

        [TestMethod]
        public void Unassigned() {
            Assert.AreEqual(GitHubEventType.Unassigned, EnumUtils.ParseEnum<GitHubEventType>("unassigned"));
        }

        [TestMethod]
        public void Unlabeled() {
            Assert.AreEqual(GitHubEventType.Unlabeled, EnumUtils.ParseEnum<GitHubEventType>("unlabeled"));
        }

        [TestMethod]
        public void Unlocked() {
            Assert.AreEqual(GitHubEventType.Unlocked, EnumUtils.ParseEnum<GitHubEventType>("unlocked"));
        }

        [TestMethod]
        public void UnmarkedAsDuplicate() {
            Assert.AreEqual(GitHubEventType.UnmarkedAsDuplicate, EnumUtils.ParseEnum<GitHubEventType>("unmarked_as_duplicate"));
        }

        [TestMethod]
        public void Unpinned() {
            Assert.AreEqual(GitHubEventType.Unpinned, EnumUtils.ParseEnum<GitHubEventType>("unpinned"));
        }

        [TestMethod]
        public void Unsubscribed() {
            Assert.AreEqual(GitHubEventType.Unsubscribed, EnumUtils.ParseEnum<GitHubEventType>("unsubscribed"));
        }

        [TestMethod]
        public void UserBlocked() {
            Assert.AreEqual(GitHubEventType.UserBlocked, EnumUtils.ParseEnum<GitHubEventType>("user_blocked"));
        }

        [TestMethod]
        public void Other() {
            Assert.AreEqual(GitHubEventType.Other, EnumUtils.ParseEnum("nope", GitHubEventType.Other));
        }

    }

}