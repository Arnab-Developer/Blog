using System;
using System.Threading.Tasks;
using LinkDotNet.Blog.Web.Authentication;
using LinkDotNet.Blog.Web.Pages;

namespace LinkDotNet.Blog.UnitTests.Web.Pages;

public class LoginModelTests
{
    [Fact]
    public async Task ShouldLogin()
    {
        var loginManager = Substitute.For<ILoginManager>();
        var sut = new LoginModel(loginManager);
        const string redirectUrl = "newUrl";
        const string authorName = "Test Author";

        await sut.OnGet(redirectUrl, authorName);

        await loginManager.Received(1).SignInAsync(redirectUrl, authorName);
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(null)]
    public async Task ShouldThrowExceptionWhenAuthorNameIsNullOrEmpty(string? authorName)
    {
        var loginManager = Substitute.For<ILoginManager>();
        var sut = new LoginModel(loginManager);
        const string redirectUrl = "newUrl";

#pragma warning disable CS8604 // Possible null reference argument.
        var action = () => sut.OnGet(redirectUrl, authorName);
#pragma warning restore CS8604 // Possible null reference argument.

        await action.ShouldThrowAsync<ArgumentException>();
    }
}
