using AlbumReviews.Data;
using AlbumReviews.Models;
using FakeItEasy;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Text;


namespace TalkHubAPI.Tests.Repositories
{
    public class Seeder
    {


        public Seeder()
        {

        }

        public AlbumReviewsContext GetDatabaseContext()
        {
            var options = new DbContextOptionsBuilder<AlbumReviewsContext>().EnableSensitiveDataLogging(true)
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            AlbumReviewsContext context = new AlbumReviewsContext(options);

            context.Database.EnsureCreated();
            if (!context.Users.Any())
            {
                User user = new User
                {
                    Id = "3800c45c-ae61-4a82-be70-7fb1e8af6aef",
                    UserName = "test@mail.com",
                    NormalizedUserName = "TEST@MAIL.COM",
                    Email = "test@mail.com",
                    NormalizedEmail = "TEST@MAIL.COM",
                    PasswordHash = "sometesthash",
                };
                context.Add(user);
                context.SaveChanges();  
            }
            if (!context.Albums.Any())
            {
                Album user = new Album
                {
                    Title = "PISHKA",
                    Cover = "asd",
                    Genre = "text",
                    ReleaseYear = 1,
                    Artist = "azis"
                    
                };
                context.Add(user);
                context.SaveChanges();
            }
           

            return context;
        }
    }
}