using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Xml.Linq;
using OnlineBidding.DAL;
using OnlineBidding.Model;
using OnlineBidding.Helper;
using Microsoft.Practices.ServiceLocation;

namespace OnlineBidding.DataInitializer
{
    public static class TestDataHelper
    {
        public static Team CreateEmployeeWithValidData(int id = 0)
        {
            return new Team
            {
                ID = id,
                Name = "Brazil",
                Group = "A",
                Description = "",
                Disqualified = false
            };
        }

        public static void InitializeSchemaAndData(string filePath)
        {
            Database.Delete("OnlineBiddingContext");
            var initializer = new DatabaseContextInitializer(filePath);
            Database.SetInitializer(initializer);
            //initializer.InitializeDatabase(DependencyHelper.GetInstance<OnlineBiddingContext>());
            initializer.InitializeDatabase(new OnlineBiddingContext());
        }

        public static List<Team> GetTeamDataFromXML(string filePath)
        {
            XDocument xDoc = XDocument.Load(filePath);
            return (from xElement in xDoc.Descendants("Team")
                    select new Team
                    {
                        //Id = int.Parse(e.Element("Id").Value),
                        Name = xElement.GetStringValue("Name"),
                        Group = xElement.GetStringValue("Group"),
                        Description = xElement.GetStringValue("Description"),
                        Disqualified = xElement.GetBooleanValue("Disqualified").HasValue ? xElement.GetBooleanValue("Disqualified").Value : false
                    }).ToList();
        }
        public static List<User> GetUserDataFromXML(string filePath)
        {
            XDocument xDoc = XDocument.Load(filePath);
            return (from xElement in xDoc.Descendants("User")
                    select new User
                    {
                        //Id = int.Parse(e.Element("Id").Value),
                        FirstName = xElement.GetStringValue("FirstName"),
                        LastName = xElement.GetStringValue("LastName"),
                        UserName = xElement.GetStringValue("UserName"),
                        Password = xElement.GetStringValue("Password"),
                        Email = xElement.GetStringValue("Email"),
                        Phone = xElement.GetStringValue("Phone"),
                        DOB = xElement.GetDateTimeValue("DOB").HasValue ? xElement.GetDateTimeValue("DOB").Value : DateTime.MinValue,
                        RoleID = xElement.GetIntValue("RoleID").HasValue ? xElement.GetIntValue("RoleID").Value : -1,
                        Active = xElement.GetBooleanValue("Active").HasValue ? xElement.GetBooleanValue("Active").Value : false
                    }).ToList();
        }
    }
}

