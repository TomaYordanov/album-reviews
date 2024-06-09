using AlbumReviews.Data;
using AlbumReviews.Models;
using AlbumReviews.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalkHubAPI.Tests.Repositories;

namespace AlbumReviews.UnitTests
{
    public class AlbumTests
    {
        private readonly Seeder seeder;

        public AlbumTests()
        {
            seeder = new Seeder();

        }

        [Test]
        public async Task AlbumService_GetAlbumsAsync_ReturnsNotNull()
        {
            string name = "IORDAAAAAAAAAAN";
            AlbumReviewsContext context = seeder.GetDatabaseContext();
            AlbumService userRepository = new AlbumService(context);

            var result = await userRepository.GetAlbumsAsync();

            Assert.IsNotNull(result); 
            
        }
        [Test]
        public async Task AlbumService_GetAlbumsQueryable_ReturnsNotNull()
        {
            string name = "IORDAAAAAAAAAAN";
            AlbumReviewsContext context = seeder.GetDatabaseContext();
            AlbumService userRepository = new AlbumService(context);

            var result = userRepository.GetAlbumsQueryable();

            Assert.IsNotNull(result);

        }



        }
    }
