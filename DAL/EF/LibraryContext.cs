using System;
using System.Data.Entity;
using DAL.Entities;

namespace DAL.EF
{
    /// <summary>
    ///  Data storage.
    /// </summary>
    public class LibraryContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<QuizGroup> QuizGroups { get; set; }
        public DbSet<TestQuestion> TestQuestions { get; set; }
        public DbSet<TestAnswer> TestAnswers { get; set; }

        static LibraryContext()
        {
            Database.SetInitializer<LibraryContext>(new LibraryDbInitializer());
        }
        public LibraryContext(string connectionString)
            : base(connectionString)
        {
        }
    }

    /// <summary>
    /// Class for creating data.
    /// </summary>
    public class LibraryDbInitializer : DropCreateDatabaseIfModelChanges<LibraryContext>
    {
        /// <summary>
        /// Method for creating data.
        /// </summary>
        protected override void Seed(LibraryContext db)
        {
            db.Articles.Add(new Article
            {
                Title = "Library",
                Text = "Many colleges and universities have large academic libraries. These libraries are for the use of college students, professors, and researchers. Academic libraries are used mainly for doing research like studying the solar system or how earthquakes happen. These libraries do not have the same types of books you would find in a public library. They usually do not have fiction books or books for children (unless they are being studied). Academic libraries can have many books, sometimes more than a million.",
                Date = DateTime.Today
            });
            db.SaveChanges();

            db.QuizGroups.Add(new QuizGroup
            {
                Title = "Poll",
                Name = "Yurii"
            });
            db.SaveChanges();

            db.TestQuestions.Add(new TestQuestion
            {
                Name = "Choose which genres of books you like:",
                QuizGroupId = 1,
                MultipleAnswer = false
            });
            db.TestQuestions.Add(new TestQuestion
            {
                Name = "Visit our site again?",
                QuizGroupId = 1,
                MultipleAnswer = false
            });
            db.SaveChanges();

            db.TestAnswers.Add(new TestAnswer { Name = "Adventure", TestQuestionId = 1 });
            db.TestAnswers.Add(new TestAnswer { Name = "Detective", TestQuestionId = 1 });
            db.TestAnswers.Add(new TestAnswer { Name = "Fantasy", TestQuestionId = 1 });
            db.TestAnswers.Add(new TestAnswer { Name = "Thriller", TestQuestionId = 1 });
            db.TestAnswers.Add(new TestAnswer { Name = "Drama", TestQuestionId = 1 });
            db.TestAnswers.Add(new TestAnswer { Name = "Biographies", TestQuestionId = 1 });
            db.TestAnswers.Add(new TestAnswer { Name = "Novels", TestQuestionId = 1 });
            db.TestAnswers.Add(new TestAnswer
            {
                Name = "Yes!",
                TestQuestionId = 2
            });
            db.TestAnswers.Add(new TestAnswer
            {
                Name = "No!",
                TestQuestionId = 2
            });
            db.SaveChanges();
        }
    }
}
