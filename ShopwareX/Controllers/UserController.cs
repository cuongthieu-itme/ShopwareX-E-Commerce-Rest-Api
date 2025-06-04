using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopwareX.Dtos.GeneralResponse;
using ShopwareX.Dtos.User;
using ShopwareX.Services.Abstracts;
using Swashbuckle.AspNetCore.Annotations;

namespace ShopwareX.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController(IUserService userService, IGenderService genderService)
        : ControllerBase
    {
        private readonly IUserService _userService = userService;
        private readonly IGenderService _genderService = genderService;

        /// <summary>
        /// Register a new user
        /// </summary>
        /// <param name="dto">User registration data</param>
        /// <returns>Created user information</returns>
        /// <response code="201">User created successfully</response>
        /// <response code="409">User with this email already exists</response>
        /// <response code="404">Gender ID not found</response>
        [HttpPost("add")]
        [SwaggerResponse(201, "User created successfully", typeof(ApiResponse<UserResponseDto>))]
        [SwaggerResponse(409, "User with this email already exists", typeof(ApiResponse<UserResponseDto>))]
        [SwaggerResponse(404, "Gender ID not found", typeof(ApiResponse<UserResponseDto>))]
        public async Task<ActionResult<ApiResponse<UserResponseDto>>>
            AddUserAsync([FromBody] UserCreateDto dto)
        {
            var existUserByEmail = await _userService.GetUserByEmailAsync(dto.Email);
            var existGender = await _genderService.GetGenderByIdAsync(dto.GenderId);

            ApiResponse<UserResponseDto> apiResponse;

            if (existUserByEmail is not null)
            {
                apiResponse = new ApiResponse<UserResponseDto>
                {
                    Message = "User already exists",
                    Response = null
                };

                return Conflict(apiResponse);
            }

            if (existGender is null)
            {
                apiResponse = new ApiResponse<UserResponseDto>
                {
                    Message = "Gender doesn't exist",
                    Response = null
                };

                return NotFound(apiResponse);
            }

            var newUser = await _userService.AddUserAsync(dto);

            apiResponse = new ApiResponse<UserResponseDto>
            {
                Message = "User was created successfully",
                Response = newUser
            };

            return Created($"api/user/get/{newUser.Id}", apiResponse);
        }

        /// <summary>
        /// Get all users (Admin only)
        /// </summary>
        /// <returns>List of all users</returns>
        /// <response code="200">Users retrieved successfully</response>
        /// <response code="401">Unauthorized - JWT token required</response>
        /// <response code="403">Forbidden - Admin role required</response>
        [Authorize(Roles = "Admin")]
        [HttpGet("all")]
        [SwaggerResponse(200, "Users retrieved successfully", typeof(ApiResponse<IEnumerable<UserResponseDto>>))]
        [SwaggerResponse(401, "Unauthorized - JWT token required")]
        [SwaggerResponse(403, "Forbidden - Admin role required")]
        public async Task<ActionResult<ApiResponse<IEnumerable<UserResponseDto>>>>
            GetAllUsersAsync()
        {
            var users = await _userService.GetAllUsersAsync();

            var apiResponse = new ApiResponse<IEnumerable<UserResponseDto>>
            {
                Message = "All users were fetched successfully",
                Response = users
            };

            return Ok(apiResponse);
        }

        /// <summary>
        /// Get user by ID
        /// </summary>
        /// <param name="id">User ID</param>
        /// <returns>User information</returns>
        /// <response code="200">User found and returned</response>
        /// <response code="404">User not found</response>
        /// <response code="401">Unauthorized - JWT token required</response>
        /// <response code="403">Forbidden - Admin or User role required</response>
        [Authorize(Roles = "Admin, User")]
        [HttpGet("get/{id:long}")]
        [SwaggerResponse(200, "User found and returned", typeof(ApiResponse<UserResponseDto>))]
        [SwaggerResponse(404, "User not found", typeof(ApiResponse<UserResponseDto>))]
        [SwaggerResponse(401, "Unauthorized - JWT token required")]
        [SwaggerResponse(403, "Forbidden - Admin or User role required")]
        public async Task<ActionResult<ApiResponse<UserResponseDto>>>
            GetUserByIdAsync([FromRoute] long id)
        {
            var existUser = await _userService.GetUserByIdAsync(id);
            ApiResponse<UserResponseDto> apiResponse;

            if (existUser is null)
            {
                apiResponse = new ApiResponse<UserResponseDto>
                {
                    Message = "User not found",
                    Response = null
                };

                return NotFound(apiResponse);
            }

            apiResponse = new ApiResponse<UserResponseDto>
            {
                Message = "User was fetched successfully",
                Response = existUser
            };

            return Ok(apiResponse);
        }

        /// <summary>
        /// Update user information
        /// </summary>
        /// <param name="id">User ID to update</param>
        /// <param name="dto">Updated user data</param>
        /// <returns>Updated user information</returns>
        /// <response code="200">User updated successfully</response>
        /// <response code="404">User or Gender not found</response>
        /// <response code="401">Unauthorized - JWT token required</response>
        /// <response code="403">Forbidden - User role required</response>
        [Authorize(Roles = "User")]
        [HttpPut("update/{id:long}")]
        [SwaggerResponse(200, "User updated successfully", typeof(ApiResponse<UserResponseDto>))]
        [SwaggerResponse(404, "User or Gender not found", typeof(ApiResponse<UserResponseDto>))]
        [SwaggerResponse(401, "Unauthorized - JWT token required")]
        [SwaggerResponse(403, "Forbidden - User role required")]
        public async Task<ActionResult<UserResponseDto>>
            UpdateUserAsync([FromRoute] long id, [FromBody] UserUpdateDto dto)
        {
            var existUser = await _userService.GetUserByIdAsync(id);
            var existGender = await _genderService.GetGenderByIdAsync(dto.GenderId);

            ApiResponse<UserResponseDto> apiResponse;

            if (existUser is null)
            {
                apiResponse = new ApiResponse<UserResponseDto>
                {
                    Message = "User not found",
                    Response = null
                };

                return NotFound(apiResponse);
            }

            if (existGender is null)
            {
                apiResponse = new ApiResponse<UserResponseDto>
                {
                    Message = "Gender doesn't exist",
                    Response = null
                };

                return NotFound(apiResponse);
            }

            var updatedUser = await _userService.UpdateUserAsync(id, dto);

            apiResponse = new ApiResponse<UserResponseDto>
            {
                Message = "User was updated successfully",
                Response = updatedUser
            };

            return Ok(apiResponse);
        }

        /// <summary>
        /// Delete user account
        /// </summary>
        /// <param name="id">User ID to delete</param>
        /// <returns>Deleted user information</returns>
        /// <response code="200">User deleted successfully</response>
        /// <response code="404">User not found</response>
        /// <response code="401">Unauthorized - JWT token required</response>
        /// <response code="403">Forbidden - User role required</response>
        [Authorize(Roles = "User")]
        [HttpDelete("delete/{id:long}")]
        [SwaggerResponse(200, "User deleted successfully", typeof(ApiResponse<UserResponseDto>))]
        [SwaggerResponse(404, "User not found", typeof(ApiResponse<UserResponseDto>))]
        [SwaggerResponse(401, "Unauthorized - JWT token required")]
        [SwaggerResponse(403, "Forbidden - User role required")]
        public async Task<ActionResult<UserResponseDto>> DeleteUserAsync([FromRoute] long id)
        {
            var existUser = await _userService.GetUserByIdAsync(id);
            ApiResponse<UserResponseDto> apiResponse;

            if (existUser is null)
            {
                apiResponse = new ApiResponse<UserResponseDto>
                {
                    Message = "User not found",
                    Response = null
                };

                return NotFound(apiResponse);
            }

            await _userService.DeleteUserByIdAsync(id);

            apiResponse = new ApiResponse<UserResponseDto>
            {
                Message = "User was deleted successfully",
                Response = existUser
            };

            return Ok(apiResponse);
        }
    }
}
