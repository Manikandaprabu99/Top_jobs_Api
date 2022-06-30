
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PostJob.Api.Data;
using PostJob.Api.Models.DTO;
using PostJob.Api.Models.Entities;

namespace PostJob.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
   // [EnableCors("default")]

    public class ApiController : ControllerBase
    {
        
        private readonly ApiDbContext dbContext;

        public ApiController(ApiDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllPosts()
        {
            var posts = await dbContext.Posts.ToListAsync();

            return Ok(posts);

        }

        [HttpGet]
        [Route("{id:Guid}")]
        [ActionName("GetPostById")]
        public async Task<IActionResult> GetPostById(Guid id)
        {
          var post = await dbContext.Posts.FirstOrDefaultAsync(x => x.Id == id);

            if (post != null)
            {
                return Ok(post);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> AddPost(AddPostRequest addPostRequest)
        {
            //convert DTO to entity

            var post = new Post()
            {
                CompanyName = addPostRequest.CompanyName,
                JobTitle = addPostRequest.JobTitle,
                Location = addPostRequest.Location,
                Summary = addPostRequest.Summary,
                Salary = addPostRequest.Salary,
                UrlHandle = addPostRequest.UrlHandle,
                FeatureImageUrl = addPostRequest.FeatureImageUrl,
                Visible = addPostRequest.Visible,
                PublishDate = addPostRequest.PublishDate,
                UpdatedDate = addPostRequest.UpdatedDate
            };

            post.Id = Guid.NewGuid();
            await dbContext.Posts.AddAsync(post);
            await dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPostById), new { id = post.Id }, post);

        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdatePost([FromRoute] Guid id,UpdatePostRequest updatePostRequest)
        {
          
            //check exists

            var existingPost = await dbContext.Posts.FindAsync(id);

            if(existingPost != null)
            {
                existingPost.CompanyName = updatePostRequest.CompanyName;
                existingPost.JobTitle = updatePostRequest.JobTitle;
                existingPost.Location = updatePostRequest.Location;
                existingPost.Summary = updatePostRequest.Summary;
                existingPost.Salary = updatePostRequest.Salary;
                existingPost.UrlHandle = updatePostRequest.UrlHandle;
                existingPost.FeatureImageUrl = updatePostRequest.FeatureImageUrl;
                existingPost.Visible = updatePostRequest.Visible;
                existingPost.PublishDate = updatePostRequest.PublishDate;
                existingPost.UpdatedDate = updatePostRequest.UpdatedDate;

                await dbContext.SaveChangesAsync();

                return Ok(existingPost);
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeletePost(Guid id)
        {
            var existingPost = await dbContext.Posts.FindAsync(id);

            if (existingPost != null)
            {
                dbContext.Remove(existingPost);
                await dbContext.SaveChangesAsync();
                return Ok(existingPost);
            }
            return NotFound();
        }

        [HttpPost("CreateUser")]
        public IActionResult Create(User user)
        {
            if (dbContext.UserDetails.Where(u => u.Email == user.Email).FirstOrDefault() != null)
            {
                return Ok("Already Exists");
            }
            user.MemberSince = DateTime.Now;
            dbContext.UserDetails.Add(user);
            dbContext.SaveChanges();
            return Ok("Account Added");
        }

    }


}
