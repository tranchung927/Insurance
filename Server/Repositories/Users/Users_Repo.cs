using Server.Data.Users;
using Server.Helpers;
using Server.Models.Users;
using Server.Repositories.Users.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Server.Repositories.Users
{
    public class Users_Repo : IUsers_Repo
    {
        // UserManager là một lớp generic được sử dụng để quản lý người dùng
        private readonly UserManager<UserEntity> userManager;

        // SignInManager là một lớp generic. Nó được sử dụng để quản lý quá trình đăng nhập của người dùng
        private readonly SignInManager<UserEntity> signInManager;

        // IConfiguration là một giao diện trong ASP.NET Core được sử dụng để đọc cấu hình ứng dụng từ
        // nhiều nguồn khác nhau như JSON files, environment variables, command line arguments,
        // và nhiều nguồn cấu hình khác.
        private readonly IConfiguration configuration;

        // roleManager được sử dụng để thực hiện các thao tác liên quan đến quản lý vai trò,
        // chẳng hạn như tạo mới vai trò, kiểm tra sự tồn tại của vai trò, và thêm vai trò cho người dùng.
        private readonly RoleManager<IdentityRole> roleManager;


        public Users_Repo(
            UserManager<UserEntity> userManager,
            SignInManager<UserEntity> signInManager,
            IConfiguration configuration,
            RoleManager<IdentityRole> roleManager
            )
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.configuration = configuration;
            this.roleManager = roleManager;
        }


        async Task<string> IUsers_Repo.GetIdByNameIdentifier(string NameIdentifier)
        {
            var user = await userManager.FindByNameAsync(NameIdentifier);
            return user.Id;
        }

        async Task<string> IUsers_Repo.SignIn(SignInModel model)
        {
            // FindByNameAsync được sử dụng để tìm kiếm một người dùng
            var user = await userManager.FindByNameAsync(model.UserName);

            Console.WriteLine("tìm user bằng username: " + user);

            if (user == null)
            {
                return string.Empty; // Hoặc trả về lỗi đăng nhập không hợp lệ
            }


            // Phương thức CheckPasswordAsync được sử dụng để kiểm tra tính hợp lệ
            // của mật khẩu của một người dùng so với mật khẩu được cung cấp
            var passwordValid = await userManager.CheckPasswordAsync(user, model.Password);
            Console.WriteLine("kiểm tra password: " + passwordValid);

            if (!passwordValid)
            {
                Console.WriteLine("vào đây");
                return string.Empty;
            }

            // Một Claim đại diện cho một thông tin xác thực cụ thể về người dùng hoặc quyền hạn của họ.
            // Ví dụ, nó có thể chứa thông tin như tên người dùng, địa chỉ email, quyền hạn, v.v.
            var authClaims = new List<Claim>
            {
                // trường username là một định danh duy nhất của người dùng trong hệ thống.
                new Claim(ClaimTypes.NameIdentifier, model.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            // lấy danh sách các vai trò (roles) của một người dùng cụ thể
            var userRoles = await userManager.GetRolesAsync(user);

            // thêm vào list authClaims
            foreach (var role in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, role.ToString()));
            }

            // Chuyển đổi chuỗi JWT:Secret từ cấu hình thành một mảng byte bằng cách sử dụng mã hóa UTF-8.
            var authenKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(configuration["JWT:Secret"])
                );

            // tạo token chữ ký
            var token = new JwtSecurityToken(
                    // Các thông tin về đơn vị phát hành và đối tượng mà token được phát cho.

                    // Đây là định danh của người phát hành (server hoặc dịch vụ) tạo ra token.
                    // Khi bên nhận nhận được token, nó sẽ kiểm tra trường issuer để đảm bảo
                    // rằng token được tạo ra bởi một người phát hành được tin cậy. Nói cách khác,
                    // trường issuer giúp đảm bảo tính xác minh và nguồn gốc của token.
                    issuer: configuration["JWT:ValidIssuer"],

                    // Đây là đối tượng mà token được tạo ra để sử dụng. Trường audience xác định
                    // rằng token chỉ được sử dụng bởi người nhận được, và không nên được chấp nhận bởi
                    // bất kỳ ứng dụng hoặc dịch vụ nào khác. Điều này giúp đảm bảo tính bảo mật và ngăn
                    // chặn việc sử dụng token cho mục đích khác nhau.
                    audience: configuration["JWT:ValidAudience"],

                    // Thời điểm hết hạn của token, ở đây là sau 1 ngày.
                    expires: DateTime.Now.AddDays(1),

                    // Danh sách các khẳng định được thêm vào token.
                    // Trong trường hợp này, authClaims là danh sách các khẳng định
                    // bao gồm địa chỉ username và một chuỗi duy nhất (JTI).
                    claims: authClaims,

                    // Đối tượng này xác định cách token sẽ được ký 
                    signingCredentials: new SigningCredentials(authenKey, SecurityAlgorithms.HmacSha256)
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        async Task<IdentityResult> IUsers_Repo.SignUp(SignUpModel SignUpModel)
        {
            var user = new UserEntity
            {
                FirstName = SignUpModel.FirstName,
                UserName = SignUpModel.UserName,
                LastName = SignUpModel.LastName,
                Email = SignUpModel.Email,
                Address = SignUpModel.Address,
                Status = SignUpModel.Status,
            };

            // CreateAsync là một phương thức mặc định được cung cấp bởi UserManager<TUser>
            // trong Microsoft.AspNetCore.Identity.
            // Phương thức này được sử dụng để tạo một người dùng mới và lưu vào cơ sở dữ liệu.
            var result = await userManager.CreateAsync(user, SignUpModel.Password);

            if (result.Succeeded)
            {
                // Kiểm tra xem vai trò "Customer" đã tồn tại hay chưa
                if (!await roleManager.RoleExistsAsync(AppRole.Customer))
                {
                    // Nếu nó chưa tồn tại, thì nó sẽ tạo mới vai trò đó.
                    await roleManager.CreateAsync(new IdentityRole(AppRole.Customer));
                }

                // Sau khi có vai trò "Customer" (đã tồn tại hoặc mới tạo),
                // người dùng mới được thêm vào vai trò "Customer"
                await userManager.AddToRoleAsync(user, AppRole.Customer);
            }
            return result;
        }
    }
}
