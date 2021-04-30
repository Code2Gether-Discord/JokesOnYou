using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JokesOnYou.Web.Api.Models
{
    public class JokeMap
    {
        public JokeMap(EntityTypeBuilder<Joke> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.ToTable("joke");

            entityBuilder.Property(x => x.Id).HasColumnName("id");
            entityBuilder.Property(x => x.Premise).HasColumnName("premise");
            entityBuilder.Property(x => x.Punchline).HasColumnName("punchline");
            entityBuilder.Property(x => x.Author).HasColumnName("author");
            entityBuilder.Property(x => x.UploadDate).HasColumnName("uploadDate");
            entityBuilder.Property(x => x.TimesFlagged).HasColumnName("timesFlagged");
            entityBuilder.Property(x => x.Likes).HasColumnName("likes");
            entityBuilder.Property(x => x.Dislikes).HasColumnName("dislikes");
        }
    }
}