using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MB.Domain.ArticleAgg;

namespace MB.Domain.CommentAgg
{
    public class Comment
    {
        public long Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Message { get; private set; } 
        public int Status  { get; private set; }// new = 0 , Confirmed = 1,Canceled = 2
        public DateTime CreationDate { get; private set; }
        public long ArticleId { get; set; }
        public Article Article { get; set; }

        protected Comment()
        {
            
        }
        public Comment(string name, string email, string message, long articleId)
        {
            Name = name;
            Email = email;
            Message = message;
            ArticleId = articleId;
            CreationDate = DateTime.Now;
            Status = Statuses.New;
        }

    }
}
