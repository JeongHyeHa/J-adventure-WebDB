using HitBallWebServer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// 테이블 Score의 CRUD(Create, Read, Update, Delete) 작업 처리
namespace HitBallWebServer
{
    [ApiController]
    [Route("api/[controller]")]
    public class ScoresController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ScoresController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/scores/5
        // 특정 user_id의 데이터 조회(로그인 처리)
        [HttpGet("{id}")]
        public async Task<ActionResult<Score>> GetScore(int id)
        {
            var score = await _context.Scores.FindAsync(id);

            // user_id가 존재하지 않으면 회원가입 진행
            if (score == null)
            {
                return NotFound("User ID not found.");
            }

            _context.Entry(score).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok(score);
        }

        // POST: api/scores/signup
        // 회원가입 처리  
        [HttpPost("signup")]
        public async Task<ActionResult<Score>> PostScore(Score score)
        {
            // 이미 존재하는 사용자 여부 확인
            var existingScore = await _context.Scores.FindAsync(score.user_id);
            if (existingScore != null)
            {
                return BadRequest("User ID already exists. Please log in.");
            }

            score.tryCount = 0;

            _context.Scores.Add(score);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetScore), new { id = score.user_id }, score);
        }

        // POST: api/scores/updateScore
        // 점수 업데이트 처리   
        [HttpPost("updateScore")]
        public async Task<IActionResult> PostScore([FromBody] ScoreUpdateRequest request)
        {
            var score = await _context.Scores.FindAsync(request.user_id);

            if (score == null)
            {
                return NotFound("User ID not found.");
            }

            score.user_score = request.gameScore;
            _context.Entry(score).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok("Score updated.");
        }

        // POST: api/scores/updateTryCount
        [HttpPost("updateTryCount")]
        public async Task<IActionResult> PostTryCount([FromBody] ScoreUpdateRequest request)
        {
            // 데이터베이스에서 user_id에 해당하는 Score 객체 찾기
            var score = await _context.Scores.FindAsync(request.user_id);

            if (score == null)
            {
                return NotFound("User ID not found.");
            }
            
            // Score 객체의 tryCount 필드를 업데이트
            score.tryCount = request.tryCount;

            // 수정된 Score 객체를 데이터베이스에 반영
            _context.Entry(score).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok("Try count updated.");
        }

        public class ScoreUpdateRequest
        {
            public int user_id { get; set; }
            public int gameScore { get; set; }
            public int tryCount { get; set; }
        }
    }
}
