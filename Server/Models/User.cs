namespace Server.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public string? UserEnail { get; set; }

        // user can create multiple projects.
        public ICollection<Project>? Projects {get; set;}

        // projectmember relationship.
        public ICollection<ProjectMember>? projectMembers {get; set;}

        // user can create multiple task.
        public ICollection<TaskItem>? TaskItems {get; set;}

        // TaskAssignment Relationship
        public ICollection<TaskAssignment>? Assignments { get; set;}

        // Comments Relationship.
        public ICollection<Comment>? Comments {get; set;}

        // user roles
        public ICollection<UserRole>? UserRoles {get; set;}
    }
}
