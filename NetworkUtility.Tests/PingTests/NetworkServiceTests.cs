using System;
using Xunit;
using NetworkUtility.Ping;
using FluentAssertions;
using FluentAssertions.Extensions;
using System.Net.NetworkInformation;
using FakeItEasy;
using NetworkUtility.DNS;

namespace NetworkUtility.Tests.PingTests
{
	public class NetworkServiceTests
	{
		private readonly NetworkService _pingService;
		private readonly IDNS _dNS;

		public NetworkServiceTests()
		{
			//Dependencies
			_dNS = A.Fake<IDNS>();


            //SUT
            _pingService = new NetworkService(_dNS);
		}

		[Fact]
		public void NetworkService_SendPing_ReturnString()
		{
			//Arrange - Variables, Classes, Mocks
			A.CallTo(() => _dNS.SendDNS()).Returns(true);


			//Act
			var result = _pingService.SendPing();

			// Assert
			result.Should().NotBeNullOrWhiteSpace();
			result.Should().Be("Success: Ping Sent!");
			result.Should().Contain("Success", Exactly.Once());

		}


		[Theory]
		[InlineData(1,1,2)]
		[InlineData(2,2,4)]
		public void NetworkService_PingTimeout_ReturnInt(int a,  int b, int expected)
		{
			// Arrange

			//Act
			var pingResult = _pingService.PingTimeout(a, b);

			//Assert
			pingResult.Should().Be(expected);
			pingResult.Should().BeGreaterThanOrEqualTo(2);
			pingResult.Should().NotBeInRange(-10000, 0);

		}


		[Fact]
		public void NetworkService_LastPingDate_ReturnDate()
		{
			//Arrange - Variables, Classes, Mocks

			//Act
			var result = _pingService.LastPingDate();

			// Assert
			result.Should().BeAfter(1.January(2010));
			result.Should().BeBefore(1.January(2030));

		}

		[Fact]
		public void etworkService_GetPingOptions_ReturnObject()
		{
			//Arrange
			var expected = new PingOptions()
			{
				DontFragment = true,
				Ttl = 1
			};

			//Act
			var result = _pingService.GetPingOptions();

			//Assert WARNING: "Be" Careful
			result.Should().BeOfType<PingOptions>();
			result.Should().BeEquivalentTo(expected);
			result.Ttl.Should().Be(1);

		}

		[Fact]
		public void etworkService_MostRecentPings_ReturnObject()
		{
			//Arrange
			var expected = new PingOptions()
			{
				DontFragment = true,
				Ttl = 1
			};

			//Act
			var result = _pingService.MostRecentPings();

			//Assert WARNING: "Be" Careful
			result.Should().BeAssignableTo<IEnumerable<PingOptions>>();
			result.Should().ContainEquivalentOf(expected);
			result.Should().Contain(x => x.DontFragment == true);

		}

	}
}

