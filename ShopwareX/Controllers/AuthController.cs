using Microsoft.AspNetCore.Mvc;
using ShopwareX.Dtos.GeneralResponse;
using ShopwareX.Dtos.Login;
using ShopwareX.Services.Abstracts;
using Swashbuckle.AspNetCore.Annotations;

namespace ShopwareX.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController(IAuthService authService) : ControllerBase
    {
        private readonly IAuthService _authService = authService;

        /// <param name="dto">Login credentials containing email and password</param>
        /// <returns>JWT token and user information if login successful</returns>
        /// <response code="200">Login successful - returns JWT token</response>
        /// <response code="401">Login failed - incorrect email or password</response>
        [HttpPost("login")]
        [SwaggerResponse(200, "Login successful", typeof(ApiResponse<LoginResponseDto>))]
        [SwaggerResponse(401, "Login failed - incorrect credentials", typeof(ApiResponse<LoginResponseDto>))]
        public async Task<ActionResult<ApiResponse<LoginResponseDto>>>
            LoginUserAsync([FromBody] LoginRequestDto dto)
        {
            var loginResponseDto = await _authService.LoginUserAsync(dto);
            ApiResponse<LoginResponseDto> apiResponse;

            if (loginResponseDto is null)
            {
                apiResponse = new ApiResponse<LoginResponseDto>
                {
                    Message = "Email or password is incorrect",
                    Response = null
                };

                return Unauthorized(apiResponse);
            }

            apiResponse = new ApiResponse<LoginResponseDto>
            {
                Message = "Login is successful",
                Response = loginResponseDto
            };

            return Ok(apiResponse);
        }
    }
}
