using Infrastructure;
using MediatR;
using Moq;
using Persistance.Entities;
using Xunit;

namespace Api.Tests.Controllers
{
    public class UserControllerTests
    {
        private Mock<IRepository<User>> _repositoryMock;
        private Mock<IMediator> _mediatorMock;
        
        public UserControllerTests()
        {
            
        }
    }
}