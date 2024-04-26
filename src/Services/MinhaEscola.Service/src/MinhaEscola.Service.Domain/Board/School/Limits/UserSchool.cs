using MinhaEscola.Service.Domain.Base.Entitie;

namespace MinhaEscola.Service.Domain.Board.School.Limits
{
    public class UserSchool : Entity
    {
        public UserSchool() { }

        public UserSchool(string user)
        {
            UserId= user;
        }

        public string UserId { get; set; }
        public long SchoolId { get; set; }

        public School School { get; set; }
    }
}
