namespace MB.Domain.CommentAgg
{
    public interface ICommentRepository
    {
        void CreateAndSave(Comment entity);
    }
}
