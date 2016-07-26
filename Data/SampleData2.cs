using LolApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace SkinApp.Data
{
    public class SampleData2
    {
        public static void Initialize(IServiceProvider sp)
        {
            var db = sp.GetService<ApplicationDbContext>();
            db.Database.EnsureCreated();

            if (!db.ForumPosts.Any())
            {
                var forumPosts = new ForumPost[]
                    {
                        new ForumPost
                        {
                            Topic = "PROJECT: Fizz",
                            Body = "I think a project Fizz skin would be awesome. Anyone agree?",
                            TimeCreated = DateTime.UtcNow,
                            Category = "Skin idea",
                            Votes = 0,
                            Views = 0,
                            Replies = new List<Reply>
                            {
                                new Reply { Message = "I totally agree! PROJECT: Fizz would be amazing!", TimeCreated = DateTime.UtcNow, Votes = 0},
                                new Reply { Message = "You're an idiot. Fizz doesn't deserve a PROJECT skin.", TimeCreated = DateTime.UtcNow, Votes = 0},
                                new Reply { Message = "Fizz definitely needs a more serious skin, this would be cool.", TimeCreated = DateTime.UtcNow, Votes = 0}
                            }

                        },
                        new ForumPost
                        {
                            Topic = "Soul Reaver Talon",
                            Body = "This is the best Talon skin concept out there, let's make it happen!",
                            TimeCreated = DateTime.UtcNow,
                            Category = "Skin idea",
                            Votes = 0,
                            Views = 0,
                            Replies = new List<Reply>
                            {
                                new Reply { Message = "Talon needs at least one good skin, his others are awful!", TimeCreated = DateTime.UtcNow, Votes = 0},
                                new Reply { Message = "Talon has enough skins. Shut up, nerd.", TimeCreated = DateTime.UtcNow, Votes = 0},
                                new Reply { Message = "This would make me so happy.", TimeCreated = DateTime.UtcNow, Votes = 0}
                            }

                        },
                        new ForumPost
                        {
                            Topic = "Void Gnar Concept Art",
                            Body = "This is a concept skin for Gnar I created.  Hope you like :)",
                            TimeCreated = DateTime.UtcNow,
                            Category = "Concept Art",
                            Votes = 0,
                            Views = 0,
                            Replies = new List<Reply>
                            {
                                new Reply { Message = "This is awesome! I would love a Void skin for Gnar.", TimeCreated = DateTime.UtcNow, Votes = 0},
                                new Reply { Message = "Wow, great job. I love this skin.", TimeCreated = DateTime.UtcNow, Votes = 0},
                                new Reply { Message = "This is so perfect for Gnar. Rito, please.", TimeCreated = DateTime.UtcNow, Votes = 0}
                            }

                        }
                    };
                db.ForumPosts.AddRange(forumPosts);
                db.SaveChanges();
            }

        }
    }
}
