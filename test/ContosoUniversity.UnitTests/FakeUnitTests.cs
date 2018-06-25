using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ContosoUniversity.UnitTests
{
	[TestClass]
	public class FakeUnitTests
	{
		[TestMethod]
		public void ShouldPass()
		{
			true.Should().BeTrue();
		}
	}
}
