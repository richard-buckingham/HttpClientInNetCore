using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using SettledBets;
using System.Threading.Tasks;

namespace SettledBets.Test
{
    public class SettledBetsIntegrationTests
    {
        [Fact]
        public async Task Test1Async()
        {
            // arrange
            var tealiumClient = new TealiumService();

            // act
            var result = await tealiumClient.PostMessage();

            // assert
            Assert.True(result);
        }

    }
}
