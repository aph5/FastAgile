using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FastAgile.DomainModel.DomainObjects
{
    public class UserStory
    {
        private string _userStoryName;
        private string _userStoryContent;
        private UserStoryStatus _userStoryStatus;
        private EstimatedPoints _estimatedPoints;

        private User _createdByUser;
        private User _assignedToUser;
        private DateTime _createdAt;
    }

    public enum UserStoryStatus
    {
        None,
        Assigned,
        InProgress,
        Completed,
        Accepted
    }

    public enum EstimatedPoints
    {
        One = 1,
        Two = 2,
        Three = 3,
        Five = 5,
        Eight = 8,
        Thirteen = 13,
        Twenty = 20,
        Fourty = 40,
        Hundred = 100
    }
}
