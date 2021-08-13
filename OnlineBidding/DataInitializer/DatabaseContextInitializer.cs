using System.Collections.Generic;
using System.Data.Entity;
using OnlineBidding.DAL;
using OnlineBidding.Model;

namespace OnlineBidding.DataInitializer
{
    public class DatabaseContextInitializer : DropCreateDatabaseIfModelChanges<OnlineBiddingContext>
    {
        string _testDataFilePath;
        public DatabaseContextInitializer(string testDataFilePath)
        {
            _testDataFilePath = testDataFilePath;
        }

        protected override void Seed(OnlineBiddingContext context)
        {
            List<Team> teams = TestDataHelper.GetTeamDataFromXML(_testDataFilePath);
            teams.ForEach(t => context.Team.Add(t));

            List<User> users = TestDataHelper.GetUserDataFromXML(_testDataFilePath);
            users.ForEach(u => context.User.Add(u));
        }
    }
}