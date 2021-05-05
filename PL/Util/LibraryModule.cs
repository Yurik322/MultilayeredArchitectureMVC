using BLL.Interfaces;
using BLL.Services;
using Ninject.Modules;

namespace PL.Util
{
    public class LibraryModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IArticleService>().To<ArticleService>();
            Bind<ICommentService>().To<CommentService>();
            Bind<ITestQuestionService>().To<TestQuestionService>();
            Bind<ITestAnswerService>().To<TestAnswerService>();
        }
    }
}