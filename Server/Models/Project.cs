namespace Server.Models
{
    public class Project
    {
        public int ProjectId {  get; set; }
        public string? ProjectName { get; set; }
        public string? ProjectDescriiption { get; set; }


        // User Can Create Project.
        public int CreatorId { get; set; }
        public User? Creator { get; set; }

        // task
        public ICollection<TaskItem>? TaskItems { get; set; }
        // projectmember relationship
        public ICollection<ProjectMember>? ProjectMembers { get; set; }

    }
}
